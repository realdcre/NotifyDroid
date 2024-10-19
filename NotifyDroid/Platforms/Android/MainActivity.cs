using Android.App;
using Android.Content.PM;
using Android.OS;
using AndroidX.Core.App;
using Microsoft.Maui.Controls;

namespace notifyd.Platforms.Android
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        int id = 0;
        const string CHANNEL_ID = "NotifyDroid";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create the notification channel
            CreateNotificationChannel();

            // Subscribe to messages from MainPage or other pages to send notifications
            MessagingCenter.Subscribe<MainPage, (string title, string message)>(this, "SendNotification", (sender, args) =>
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
                    Description = "Sends your NotifyDroid Reminders"
                };
                var notificationManager = (NotificationManager)GetSystemService(NotificationService);
                notificationManager.CreateNotificationChannel(channel);
            }
        }

        public void SendNotification(string title, string message)
        {
            var notificationManager = (NotificationManager)GetSystemService(NotificationService);

            // Use correct resource reference for the icon
            var notificationBuilder = new NotificationCompat.Builder(this, CHANNEL_ID)
                .SetContentTitle(title)
                .SetContentText(message)
                .SetSmallIcon(Resource.Drawable.useappicon) // Make sure the correct icon is used
                .SetAutoCancel(true) // Auto-cancel the notification
                .SetStyle(new NotificationCompat.BigTextStyle().BigText(message)); // Use BigTextStyle for larger messages

            // Show the notification
            notificationManager.Notify(id++, notificationBuilder.Build());
        }
    }
}
