using Android.App;
using Android.Content;
using Android.OS;
using AndroidX.Core.App;
using Microsoft.Maui.Controls;
using static Android.Icu.Text.CaseMap;

namespace notifyd.Platforms.Android
{
    public class ShareReceiver : IShareReceiver
    {
        private readonly Context _context;

        public ShareReceiver(Context context)
        {
            _context = context;
            CreateNotificationChannel();
        }

        public void HandleSharedText(string sharedText)
        {
            
            
            
            
            // Handle the shared text and send a notification with it
            SendNotification("Shared Text", sharedText);
            Preferences.Set("recentText3", Preferences.Get("recentText2", ""));
            Preferences.Set("recentTitle3", Preferences.Get("recentTitle2", ""));
            Preferences.Set("recentText2", Preferences.Get("recentText1", ""));
            Preferences.Set("recentTitle2", Preferences.Get("recentTitle1", ""));
            Preferences.Set("recentText1", sharedText);

        }

        int id = 0;
        const string CHANNEL_ID = "NotifyDroidShared";

        private void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                var channel = new NotificationChannel(CHANNEL_ID, "NotifyDroidShared", NotificationImportance.Default)
                {
                    Description = "Sends Shared Text through NotifyDroid"
                };
                var notificationManager = (NotificationManager)_context.GetSystemService(Context.NotificationService);
                notificationManager.CreateNotificationChannel(channel);
            }
        }

        public void SendNotification(string title, string message)
        {
            var notificationManager = (NotificationManager)_context.GetSystemService(Context.NotificationService);

            // Use the correct resource reference for the icon
            var notificationBuilder = new NotificationCompat.Builder(_context, CHANNEL_ID)
                .SetContentTitle(title)
                .SetContentText(message)
                .SetSmallIcon(_Microsoft.Android.Resource.Designer.Resource.Drawable.useappicon) // Make sure the correct icon is used
                .SetAutoCancel(true) // Auto-cancel the notification
                .SetStyle(new NotificationCompat.BigTextStyle().BigText(message)); // Use BigTextStyle for large messages

            // Show the notification
            notificationManager.Notify(id++, notificationBuilder.Build());
        }
    }
}
