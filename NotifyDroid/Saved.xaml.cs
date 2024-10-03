using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Storage;
using System.ComponentModel;

namespace notifyd
{
    public partial class Saved : ContentPage, INotifyPropertyChanged
    {
        // Define properties for each saved text
        private string _savedText0;
        public string SavedText0
        {
            get => _savedText0;
            set
            {
                _savedText0 = value;
                OnPropertyChanged(nameof(SavedText0));
            }
        }

        private string _savedText1;
        public string SavedText1
        {
            get => _savedText1;
            set
            {
                _savedText1 = value;
                OnPropertyChanged(nameof(SavedText1));
            }
        }

        private string _savedText2;
        public string SavedText2
        {
            get => _savedText2;
            set
            {
                _savedText2 = value;
                OnPropertyChanged(nameof(SavedText2));
            }
        }

        private string _savedText3;
        public string SavedText3
        {
            get => _savedText3;
            set
            {
                _savedText3 = value;
                OnPropertyChanged(nameof(SavedText3));
            }
        }

        private string _savedText4;
        public string SavedText4
        {
            get => _savedText4;
            set
            {
                _savedText4 = value;
                OnPropertyChanged(nameof(SavedText4));
            }
        }

        private string _savedText5;
        public string SavedText5
        {
            get => _savedText5;
            set
            {
                _savedText5 = value;
                OnPropertyChanged(nameof(SavedText5));
            }
        }

        private string _savedText6;
        public string SavedText6
        {
            get => _savedText6;
            set
            {
                _savedText6 = value;
                OnPropertyChanged(nameof(SavedText6));
            }
        }

        private string _savedText7;
        public string SavedText7
        {
            get => _savedText7;
            set
            {
                _savedText7 = value;
                OnPropertyChanged(nameof(SavedText7));
            }
        }

        private string _savedText8;
        public string SavedText8
        {
            get => _savedText8;
            set
            {
                _savedText8 = value;
                OnPropertyChanged(nameof(SavedText8));
            }
        }

        private string _savedText9;
        public string SavedText9
        {
            get => _savedText9;
            set
            {
                _savedText9 = value;
                OnPropertyChanged(nameof(SavedText9));
            }
        }
        private string _recentText1;
        public string recentText1
        {
            get => _recentText1;
            set
            {
                _recentText1 = value;
                OnPropertyChanged(nameof(recentText1));
            }
        }
        private string _recentText2;
        public string recentText2
        {
            get => _recentText2;
            set
            {
                _recentText2 = value;
                OnPropertyChanged(nameof(recentText2));
            }
        }
        private string _recentText3;
        public string recentText3
        {
            get => _recentText3;
            set
            {
                _recentText3 = value;
                OnPropertyChanged(nameof(recentText3));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Saved()
        {
            InitializeComponent();

            // Set the BindingContext for data binding
            BindingContext = this;

            // Load saved preferences into the properties
            LoadSavedData();
        }

        private void LoadSavedData()
        {
            // Load data from Preferences and set the binding properties
            for (int i = 0; i < 10; i++)
            {
                string savedText = Preferences.Get($"savedText{i}", "No saved text");
                switch (i)
                {
                    case 0: SavedText0 = savedText; break;
                    case 1: SavedText1 = savedText; break;
                    case 2: SavedText2 = savedText; break;
                    case 3: SavedText3 = savedText; break;
                    case 4: SavedText4 = savedText; break;
                    case 5: SavedText5 = savedText; break;
                    case 6: SavedText6 = savedText; break;
                    case 7: SavedText7 = savedText; break;
                    case 8: SavedText8 = savedText; break;
                    case 9: SavedText9 = savedText; break;
                    
                }
                if (i > 0 && i < 4)
                {

                    string recentText = Preferences.Get($"recentText{i}", "No saved text");
                    switch (i)
                    {
                        case 1: recentText1 = recentText; break;
                        case 2: recentText2 = recentText; break;
                        case 3: recentText3 = recentText; break;
                    }
                }
                if (string.IsNullOrEmpty(recentText1)) recentText1 = "No recent text";
                if (string.IsNullOrEmpty(recentText2)) recentText2 = "No recent text";
                if (string.IsNullOrEmpty(recentText3)) recentText3 = "No recent text";
            }
        }

        // Clear all saved preferences when the "Clear Saved" button is clicked
        private void CA(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                Preferences.Remove($"savedText{i}");
                Preferences.Remove($"savedTextT{i}");
                Preferences.Remove($"recentTitle{i}");
                Preferences.Remove($"recentText{i}");
                Preferences.Remove($"noOfEntry{i}"); // Clear the entry count as well
            }
            LoadSavedData(); // Refresh the UI after clearing
        }

        private void CS(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                Preferences.Remove($"savedText{i}");
                Preferences.Remove($"savedTextT{i}");
                Preferences.Remove($"noOfEntry{i}"); // Clear the entry count as well
            }
        }
        private void CR(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                Preferences.Remove($"recentTitle{i}");
                Preferences.Remove($"recentText{i}");
            }
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadSavedData(); // Refresh the data whenever the page appears
        }

        // Event handlers for button clicks to show saved text in a popup
        private async void S0(object sender, EventArgs e)
        {
            sendNotification(Preferences.Get("savedTextT0", ""), Preferences.Get("savedText0", ""));
        }

        private async void S2(object sender, EventArgs e)
        {
            sendNotification(Preferences.Get("savedTextT2", ""), Preferences.Get("savedText2", ""));
        }

        private async void S3(object sender, EventArgs e)
        {
            sendNotification(Preferences.Get("savedTextT3", ""), Preferences.Get("savedText3", ""));
        }

        private async void S4(object sender, EventArgs e)
        {
            sendNotification(Preferences.Get("savedTextT4", ""), Preferences.Get("savedText4", ""));
        }

        private async void S5(object sender, EventArgs e)
        {
            sendNotification(Preferences.Get("savedTextT5", ""), Preferences.Get("savedText5", ""));
        }

        private async void S6(object sender, EventArgs e)
        {
            sendNotification(Preferences.Get("savedTextT6", ""), Preferences.Get("savedText6", ""));
        }

        private async void S7(object sender, EventArgs e)
        {
            sendNotification(Preferences.Get("savedTextT7", ""), Preferences.Get("savedText7", ""));
        }

        private async void S8(object sender, EventArgs e)
        {
            sendNotification(Preferences.Get("savedTextT8", ""), Preferences.Get("savedText8", ""));
        }

        private async void S9(object sender, EventArgs e)
        {
            sendNotification(Preferences.Get("savedTextT9", ""), Preferences.Get("savedText9", ""));
        }
        private async void R1(object sender, EventArgs e)
        {
            sendNotification(Preferences.Get("recentTitle1", ""), Preferences.Get("recentText1", ""));
        }
        private async void R2(object sender, EventArgs e)
        {
            sendNotification(Preferences.Get("recentTitle2", ""), Preferences.Get("recentText2", ""));
        }
        private async void R3(object sender, EventArgs e)
        {
            sendNotification(Preferences.Get("recentTitle3", ""), Preferences.Get("recentText3", ""));
        }

        public void sendNotification(string title, string message)
        {
            if (string.IsNullOrEmpty(title) && string.IsNullOrEmpty(message))
            {

            }
            else
            {
                // Send the message to the MainActivity using MessagingCenter
                MessagingCenter.Send(this, "SendNotification", (title, message)); // Pass title and message as a tuple

                // Clear the text inputs after sending the notification

            }
        }
    }
}
