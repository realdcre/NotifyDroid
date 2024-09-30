using Microsoft.Maui.Controls;
using System;
using System.ComponentModel;
using Microsoft.Maui.Storage;
using System.Linq;


namespace notifyd
{
    public partial class App : Application
    {

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

            
            MainPage = new AppShell();
        }
    }
}
