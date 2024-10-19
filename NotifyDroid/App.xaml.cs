using Microsoft.Maui.Controls;
using System;
using System.ComponentModel;
using Microsoft.Maui.Storage;
using System.Linq;
using notifyd.Platforms.Android; // Update the namespace to match the file location

namespace notifyd
{
    public partial class App : Application
    {
        private readonly notifyd.SettingsRepository _settingsRepository; // Update the namespace to match the file location

        public App(string dbPath)
        {
            _settingsRepository = new notifyd.SettingsRepository(dbPath); // Update the namespace to match the file location
        }
        public App()
        {
            InitializeComponent();
            async void requestNotifications()
            {
                if (OperatingSystem.IsAndroidVersionAtLeast(33)) // Android 13+
                {
                    var status = await Permissions.RequestAsync<Permissions.PostNotifications>();
                    if (status != PermissionStatus.Granted)
                    {
                        // Handle permission not granted scenario
                        return;

                    }
                }
                requestNotifications();
            }


            MainPage = new NavigationPage(new MainPage());
        }
    }
}