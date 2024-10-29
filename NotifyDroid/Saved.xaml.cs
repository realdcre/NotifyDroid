using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using System.ComponentModel;
using Xamarin.KotlinX.Coroutines;

namespace notifyd
{
    public partial class Saved : ContentPage, INotifyPropertyChanged
    {
        SettingsRepository settingsRepo = new SettingsRepository();  // Allowing Access to SettingsRepo and SQLE-Functions

       // Define and Bind Values
        private string _savedText0;
        public string SavedText0
        {
            get => _savedText0;
            set { _savedText0 = value; OnPropertyChanged(nameof(SavedText0)); }
        }

        private string _savedText1;
        public string SavedText1
        {
            get => _savedText1;
            set { _savedText1 = value; OnPropertyChanged(nameof(SavedText1)); }
        }

        private string _savedText2;
        public string SavedText2
        {
            get => _savedText2;
            set { _savedText2 = value; OnPropertyChanged(nameof(SavedText2)); }
        }

        private string _savedText3;
        public string SavedText3
        {
            get => _savedText3;
            set { _savedText3 = value; OnPropertyChanged(nameof(SavedText3)); }
        }

        private string _savedText4;
        public string SavedText4
        {
            get => _savedText4;
            set { _savedText4 = value; OnPropertyChanged(nameof(SavedText4)); }
        }

        private string _savedText5;
        public string SavedText5
        {
            get => _savedText5;
            set { _savedText5 = value; OnPropertyChanged(nameof(SavedText5)); }
        }

        private string _savedText6;
        public string SavedText6
        {
            get => _savedText6;
            set { _savedText6 = value; OnPropertyChanged(nameof(SavedText6)); }
        }

        private string _savedText7;
        public string SavedText7
        {
            get => _savedText7;
            set { _savedText7 = value; OnPropertyChanged(nameof(SavedText7)); }
        }

        private string _savedText8;
        public string SavedText8
        {
            get => _savedText8;
            set { _savedText8 = value; OnPropertyChanged(nameof(SavedText8)); }
        }

        private string _savedText9;
        public string SavedText9
        {
            get => _savedText9;
            set { _savedText9 = value; OnPropertyChanged(nameof(SavedText9)); }
        }
        
        private string _recentText1;
        public string RecentText1
        {
            get => _recentText1;
            set { _recentText1 = value; OnPropertyChanged(nameof(RecentText1)); }
        }

        private string _recentText2;
        public string RecentText2
        {
            get => _recentText2;
            set { _recentText2 = value; OnPropertyChanged(nameof(RecentText2)); }
        }

        private string _recentText3;
        public string RecentText3
        {
            get => _recentText3;
            set { _recentText3 = value; OnPropertyChanged(nameof(RecentText3)); }
        }
        
        // Setup functions

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public bool sqle = Preferences.Get("SQL(E)", false);

        public Saved()
        {
            InitializeComponent();
            BindingContext = this;
            if (sqle) { LoadSavedDataSQLE(); }
            else { LoadSavedDataLEG(); }
        }

       
       

        

        private void SetSavedTextProperty(int index, string value)
        {
            switch (index)
            {
                case 0: SavedText0 = value; break;
                case 1: SavedText1 = value; break;
                case 2: SavedText2 = value; break;
                case 3: SavedText3 = value; break;
                case 4: SavedText4 = value; break;
                case 5: SavedText5 = value; break;
                case 6: SavedText6 = value; break;
                case 7: SavedText7 = value; break;
                case 8: SavedText8 = value; break;
                case 9: SavedText9 = value; break;
            }
        }

        private void SetRecentTextProperty(int index, string value)
        {
            switch (index)
            {
                case 1: RecentText1 = value; break;
                case 2: RecentText2 = value; break;
                case 3: RecentText3 = value; break;
            }
        }

        private void EnsureDefaultRecentTexts()
        {
            if (string.IsNullOrEmpty(RecentText1)) RecentText1 = "No recent text";
            if (string.IsNullOrEmpty(RecentText2)) RecentText2 = "No recent text";
            if (string.IsNullOrEmpty(RecentText3)) RecentText3 = "No recent text";
        }

       // Event Handlers for Buttons
     
        private async void S0(object sender, EventArgs e) => sendNotification(0, 's');
        private async void S2(object sender, EventArgs e) => sendNotification(2, 's');
        private async void S3(object sender, EventArgs e) => sendNotification(3, 's');
        private async void S4(object sender, EventArgs e) => sendNotification(4, 's');
        private async void S5(object sender, EventArgs e) => sendNotification(5, 's');
        private async void S6(object sender, EventArgs e) => sendNotification(6, 's');
        private async void S7(object sender, EventArgs e) => sendNotification(7, 's');
        private async void S8(object sender, EventArgs e) => sendNotification(8, 's');
        private async void S9(object sender, EventArgs e) => sendNotification(9, 's');
        
        
        private async void R1(object sender, EventArgs e) => sendNotification(1, 'r');
        private async void R2(object sender, EventArgs e) => sendNotification(2, 'r');
        private async void R3(object sender, EventArgs e) => sendNotification(3, 'r');

        

        

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadSavedData();

        }

        // Functions Related to PREF-Storage

        private void LoadSavedDataLEG()
        {
            for (int i = 0; i < 10; i++)
            {
                string savedText = Preferences.Get($"savedText{i}", "No saved text");
                SetSavedTextProperty(i, savedText);

                if (i > 0 && i < 4)
                {
                    string recentText = Preferences.Get($"recentText{i}", "No saved text");
                    SetRecentTextProperty(i, recentText);
                }
            }

            EnsureDefaultRecentTexts();
        }
        private void ClearAllData(bool includeRecentTexts)
        {
            for (int i = 0; i < 10; i++)
            {
                Preferences.Remove($"savedText{i}");
                Preferences.Remove($"savedTextT{i}");
                Preferences.Remove($"noOfEntry{i}");

                if (includeRecentTexts)
                {
                    Preferences.Remove($"recentTitle{i}");
                    Preferences.Remove($"recentText{i}");
                }
            }
            LoadSavedDataLEG();
        }

        private void CALEG()
        {
            ClearPreferences(includeRecent: true, includeSaved: true);
            LoadSavedDataLEG();
        }

        private void CRLEG() => ClearPreferences(includeRecent: true, includeSaved: false);
        private void CSLEG() => ClearPreferences(includeRecent: false, includeSaved: true);

       
        

        private void ClearPreferences(bool includeRecent, bool includeSaved)
        {
            for (int i = 0; i < 10; i++)
            {
                if (includeSaved)
                {
                    Preferences.Remove($"savedText{i}");
                    Preferences.Remove($"savedTextT{i}");
                    Preferences.Remove($"noOfEntry{i}");
                }

                if (includeRecent)
                {
                    Preferences.Remove($"recentTitle{i}");
                    Preferences.Remove($"recentText{i}");
                }
            }
        }

        private void LoadSavedDataSQLE()
        {
            for (int i = 0; i < 10; i++)
            {
                string savedText = settingsRepo.GetString($"savedText{i}") ?? "No saved text";
                SetSavedTextProperty(i, savedText);

                if (i > 0 && i < 4)
                {
                    string recentText = settingsRepo.GetString($"recentText{i}") ?? "No recent text";
                    SetRecentTextProperty(i, recentText);
                }
            }

            EnsureDefaultRecentTexts();
        }

        // Functions related to SQLE-Storage

        private void CASQLE()
        {
            ClearSQLData(includeRecent: true, includeSaved: true);
            LoadSavedDataSQLE();
        }

        private void CRSQLE() => ClearSQLData(includeRecent: false, includeSaved: true);
        private void CSSQLE() => ClearSQLData(includeRecent: true, includeSaved: false);


        private void ClearSQLData(bool includeRecent, bool includeSaved)
        {
            for (int i = 0; i < 10; i++)
            {
                if (includeSaved)
                {
                    settingsRepo.SetString($"savedText{i}", null);
                    settingsRepo.SetString($"savedTextT{i}", null);
                    settingsRepo.SetString($"noOfEntry{i}", null);
                }

                if (includeRecent)
                {
                    settingsRepo.SetString($"recentTitle{i}", null);
                    settingsRepo.SetString($"recentText{i}", null);
                }
            }
        }

        // Base Functionality Functions

        public void sendAndroidNotification(string title, string message)
        {
            if (!string.IsNullOrEmpty(title) || !string.IsNullOrEmpty(message))
            {
                MessagingCenter.Send(this, "SendNotification", (title, message));
            }
            else
            {
                Console.WriteLine("Notification title and message are empty.");
            }
        }

        // Functions handling the switch between SQLE and PREF System

        private async void sendNotification(int i, char m)
        {
            string text = "";
            string title = "";
            if (m == 'r')
            {
                if (sqle)
                {
                     text = settingsRepo.GetString($"recentText{i}");
                     title = settingsRepo.GetString($"recentTitle{i}");
                }
                else
                {
                     text = Preferences.Get($"recentText{i}", "");
                     title = Preferences.Get($"recentTitle{i}", "");
                }
            } else if (m == 's')
            {
                if (sqle)
                {
                     text = settingsRepo.GetString($"savedText{i}");
                     title = settingsRepo.GetString($"savedTextT{i}");
                }
                else
                {
                     text = Preferences.Get($"savedText{i}", "");
                     title = Preferences.Get($"savedTextT{i}", "");
                }
            }

            sendAndroidNotification(title, text);


        }
        private async void sendNotification(string message, string title)
        {
            sendAndroidNotification(title, message);
        }

        private void LoadSavedData()
        {
            if (sqle)
            {
                LoadSavedDataSQLE();
            }
            else
            {
                LoadSavedDataLEG();
            }

        }

        private void CS(object sender, EventArgs e)
        {
            if (sqle)
            {
                ClearSQLData(false, true);
            }
            else
            {
                ClearPreferences(false, true);
            }
        }
        private void CR(object sender, EventArgs e)
        {
            if (sqle)
            {
                ClearSQLData(true, false);
            }
            else
            {
                ClearPreferences(true, false);
            }
        }
        private void CA(object sender, EventArgs e)
        {
            if (sqle)
            {
                ClearSQLData(true, true);
            }
            else
            {
                ClearPreferences(true, true);
            }
        }

















    }
}
