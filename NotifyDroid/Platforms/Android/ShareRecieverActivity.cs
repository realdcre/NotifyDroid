using Android.App;
using Android.Content;
using Android.OS;
using Microsoft.Maui.Controls;

namespace notifyd.Platforms.Android
{
    [Activity(Label = "ShareReceiverActivity")]
    public class ShareReceiverActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Retrieve the shared text
            var sharedText = Intent.GetStringExtra(Intent.ExtraText);

            // Call the IShareReceiver interface method (through DependencyService)
            var shareReceiver = DependencyService.Get<IShareReceiver>();
            shareReceiver?.HandleSharedText(sharedText);

            // Finish the activity after processing the shared text
            Finish();
        }
    }
}
