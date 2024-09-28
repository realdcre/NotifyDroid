using Microsoft.Maui.Controls; // Ensure you have the correct using directive
using System;
using System.Globalization;

namespace notifyd
{
    public partial class MainPage : ContentPage
    {
        


        public MainPage()
        {
            
            InitializeComponent();
        }

        private void SendNotClicked(object sender, EventArgs e)
        {
            string title = titlen.Text;
            string message = contentn.Text;

            // Send the message to the MainActivity
            MessagingCenter.Send(this, "SendNotification", (title, message));
            
            titlen.Text = string.Empty;
            contentn.Text = string.Empty;
        }
    }
}