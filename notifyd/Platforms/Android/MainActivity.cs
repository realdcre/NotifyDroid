using Android.App;
using Android.Content.PM;
using Android.OS;
using AndroidX.Core.App; // Make sure this is added for NotificationCompat
using Microsoft.Maui.Controls;


namespace notifyd
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        int id = 0;

        const string CHANNEL_ID = "NotifyDroid";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            CreateNotificationChannel();

            // Subscribe to the message
            MessagingCenter.Subscribe < MainPage, (string title, string message)>(this, "SendNotification", (sender, args) =>
            {
                SendNotification(args.title, args.message);
            });
            MessagingCenter.Subscribe<Saved, (string title, string message)>(this, "SendNotification", (sender, args) =>
            {
                SendNotification(args.title, args.message);
            });
        }

        private void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                var channel = new NotificationChannel(CHANNEL_ID, "NotifyDroid", NotificationImportance.Default)
                {
                    Description = "Sends your Notifydroid Reminders"
                };
                var notificationManager = (NotificationManager)GetSystemService(NotificationService);
                notificationManager.CreateNotificationChannel(channel);
            }
        }

        public void SendNotification(string title, string message)
        {
            var notificationManager = (NotificationManager)GetSystemService(NotificationService);

            // Use NotificationCompat.Builder instead of Notification.Builder
            var notificationBuilder = new NotificationCompat.Builder(this, CHANNEL_ID)
                .SetContentTitle(title)
                .SetContentText(message)
                .SetSmallIcon(Microsoft.Maui.Resource.Drawable.useappicon)
                .SetAutoCancel(false) // Set to true to auto-cancel the notification
                .SetStyle(new NotificationCompat.BigTextStyle().BigText(message)); // Use BigTextStyle for large messages

            // Show the notification
            notificationManager.Notify(id++, notificationBuilder.Build());
        }
    }
}
