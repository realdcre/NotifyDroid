using Microsoft.Maui.Controls;
using System;
using System.ComponentModel;
using Microsoft.Maui.Storage;
using notifyd;

namespace notifyd
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        SettingsRepository settingsRepo = new SettingsRepository("home");

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int FindMinIndex(int[] noOfEntries)
        {
            int minIndex = 0;
            for (int i = 1; i < noOfEntries.Length; i++)
            {
                if (noOfEntries[i] < noOfEntries[minIndex])
                {
                    minIndex = i;
                }
            }
            return minIndex;
        }

        public bool SQL = Preferences.Get("SQL(E)", false);

        void SaveNextRecent(string m, string t)
        {
            if (SQL)
            {
                SaveNextRecentSQLE(m, t);
            }
            else
            {
                SaveNextRecentLEG(m, t);
            }
        }

        void WriteToNextSaved(string m, string t)
        {
            if (SQL)
            {
                WriteToNextSavedSQLE(m, t);
            }
            else
            {
                WriteToNextSavedLEG(m, t);
            }
        }

        void SetString(string key, string value)
        {
            settingsRepo.SetString(key, value);
        }

        string GetString(string key)
        {
            return settingsRepo.GetString(key);
        }

        private int FindMax(int[] noOfEntries)
        {
            int maxNoOfEntry = noOfEntries[0];
            for (int i = 1; i < noOfEntries.Length; i++)
            {
                if (noOfEntries[i] > maxNoOfEntry)
                {
                    maxNoOfEntry = noOfEntries[i];
                }
            }
            return maxNoOfEntry;
        }

        public void refreshImage()
        {
            bool var = Preferences.Get("IOH", true);
            if (var == false)
            {
                image.IsVisible = false;
            }
            else
            {
                image.IsVisible = true;
            }
        }

        public MainPage()
        {
            InitializeComponent();
            refreshImage();
        }

        private async void NavSavedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Saved());
        }

        private async void NavSettingsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserPreferences());
        }

        void WriteToNextSavedLEG(string title, string message)
        {
            int[] noOfEntries = new int[10];

            // Initialize noOfEntries array by loading values from Preferences
            for (int i = 0; i < 10; i++)
            {
                noOfEntries[i] = Preferences.Get($"noOfEntry{i}", 0);
            }

            // Find the index of the least used entry (minIndex) and maximum value of saved entries (maxNoOfEntry)
            int minIndex = FindMinIndex(noOfEntries);
            int maxNoOfEntry = FindMax(noOfEntries);

            // Always save to the first spot if the entries were cleared
            if (maxNoOfEntry == 0)
            {
                maxNoOfEntry = 1; // Start from 1 if all entries are cleared
                minIndex = 0; // Reset to save at the first index
            }

            // Set the next entry number to be one more than the highest saved entry number
            int setNo = maxNoOfEntry + 1;

            // Save the message and title at the minIndex (next available slot)
            Preferences.Set($"nrOfSavedEntry{minIndex}", setNo);   // Track the saved entry number
            Preferences.Set($"savedTextT{minIndex}", title);       // Save the title with the same index
            Preferences.Set($"savedText{minIndex}", message);      // Save the message with the same index

            // Save the updated entry number in Preferences to keep track
            Preferences.Set($"noOfEntry{minIndex}", setNo);
        }

        public int GetMostRecentPathLEG()
        {
            // Retrieve the number of saved entries for three specific entries (for example)
            int noOfEntry1 = Preferences.Get("nrOfSavedEntry1", 0);
            int noOfEntry2 = Preferences.Get("nrOfSavedEntry2", 0);
            int noOfEntry3 = Preferences.Get("nrOfSavedEntry3", 0);

            // Find the highest number among the three entries to get the most recent one
            int highestNumber = Math.Max(Math.Max(noOfEntry3, noOfEntry2), noOfEntry1);

            if (highestNumber == noOfEntry1)
            {
                return 1;
            }
            else if (highestNumber == noOfEntry2)
            {
                return 2;
            }
            else if (highestNumber == noOfEntry3)
            {
                return 3;
            }
            return 0;
        }

        private void SaveNextRecentLEG(string message, string title)
        {
            Preferences.Set("recentText3", Preferences.Get("recentText2", ""));
            Preferences.Set("recentTitle3", Preferences.Get("recentTitle2", ""));
            Preferences.Set("recentText2", Preferences.Get("recentText1", ""));
            Preferences.Set("recentTitle2", Preferences.Get("recentTitle1", ""));
            Preferences.Set("recentText1", message);
            Preferences.Set("recentTitle1", title);
        }

        private void SaveNextRecentSQLE(string message, string title)
        {
            SetString("recentText3", GetString("recentText2"));
            SetString("recentTitle3", GetString("recentTitle2"));
            SetString("recentText2", GetString("recentText1"));
            SetString("recentTitle2", GetString("recentTitle1"));
            SetString("recentText1", message);
            SetString("recentTitle1", title);
        }

        public int GetMostRecentPathSQLE()
        {
            int noOfEntry1 = int.Parse(GetString("nrOfSavedEntry1"));
            int noOfEntry2 = int.Parse(GetString("nrOfSavedEntry2"));
            int noOfEntry3 = int.Parse(GetString("nrOfSavedEntry3"));

            int highestNumber = Math.Max(Math.Max(noOfEntry3, noOfEntry2), noOfEntry1);

            if (highestNumber == noOfEntry1) return 1;
            if (highestNumber == noOfEntry2) return 2;
            if (highestNumber == noOfEntry3) return 3;
            return 0;
        }

        void WriteToNextSavedSQLE(string title, string message)
        {
            int[] noOfEntries = new int[10];

            for (int i = 0; i < 10; i++)
            {
                noOfEntries[i] = int.Parse(GetString($"noOfEntry{i}"));
            }

            int minIndex = FindMinIndex(noOfEntries);
            int maxNoOfEntry = FindMax(noOfEntries);

            if (maxNoOfEntry == 0)
            {
                maxNoOfEntry = 1;
                minIndex = 0;
            }

            int setNo = maxNoOfEntry + 1;

            SetString($"nrOfSavedEntry{minIndex}", setNo.ToString());
            SetString($"savedTextT{minIndex}", title);
            SetString($"savedText{minIndex}", message);
            SetString($"noOfEntry{minIndex}", setNo.ToString());
        }
    }
}
