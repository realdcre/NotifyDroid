using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using System.ComponentModel;

namespace notifyd
{
    public partial class Saved : ContentPage, INotifyPropertyChanged
    {
        SettingsRepository settingsRepo = new SettingsRepository("home");

        #region Saved Text Properties
        private string _savedText0;
        public string SavedText0
        {
            get => _savedText0;
            set { _savedText0 = value; OnPropertyChanged(nameof(SavedText0)); }
        }
        // Similar properties for SavedText1 to SavedText9

        private string _savedText1;
        public string SavedText1
        {
            get => _savedText1;
            set { _savedText1 = value; OnPropertyChanged(nameof(SavedText1)); }
        }
        // Repeat for other saved text properties
        #endregion

        #region Recent Text Properties
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
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public Saved()
        {
            InitializeComponent();
            BindingContext = this;
            LoadSavedDataLEG();
        }

        #region Load and Clear Saved Data
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
        #endregion

        #region Event Handlers for Button Clicks
        private async void S0(object sender, EventArgs e) =>
            await ShowNotification("savedTextT0", "savedText0");

        // Other S event handlers (S2, S3, etc.) follow the same pattern.

        private async void R1(object sender, EventArgs e) =>
            await ShowNotification("recentTitle1", "recentText1");

        private async void R2(object sender, EventArgs e) =>
            await ShowNotification("recentTitle2", "recentText2");

        private async void R3(object sender, EventArgs e) =>
            await ShowNotification("recentTitle3", "recentText3");

        private async Task ShowNotification(string titleKey, string textKey)
        {
            var title = Preferences.Get(titleKey, string.Empty);
            var message = Preferences.Get(textKey, string.Empty);
            sendNotification(title, message);
        }
        #endregion

        public void sendNotification(string title, string message)
        {
            if (!string.IsNullOrEmpty(title) || !string.IsNullOrEmpty(message))
            {
                MessagingCenter.Send(this, "SendNotification", (title, message));
            }
            else
            {
                // Optionally provide feedback here if both title and message are empty
                Console.WriteLine("Notification title and message are empty.");
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadSavedDataLEG();
        }
    }
}
