using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Media;
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
            MessagingCenter.Subscribe<MainPage, (string title, string message)>(this, "SendNotification", (sender, args) =>
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

            var notificationBuilder = new Notification.Builder(this, CHANNEL_ID)
                .SetContentTitle(title)
                .SetContentText(message)
                .SetSmallIcon(Resource.Drawable.useappicon) // Ensure this drawable resource exists
                                                            //.SetPriority(NotificationPriority.Default)
                .SetAutoCancel(false); // Set to true to auto-cancel the notification

            // Show the notification
            notificationManager.Notify(id++, notificationBuilder.Build());
        }
    }
}