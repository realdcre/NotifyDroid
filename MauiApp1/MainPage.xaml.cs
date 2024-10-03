using Microsoft.Maui.Controls;
using System;
using System.ComponentModel;
using Microsoft.Maui.Storage;

namespace notifyd
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
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

        public MainPage()
        {
            InitializeComponent();
        }

        void WriteToNextSaved(string title, string message)
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

        public int GetMostRecentPath()
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
        

        
        private void SaveNextRecent(string message, string title)
        {
            Preferences.Set("recentText3", Preferences.Get("recentText2", ""));
            Preferences.Set("recentTitle3", Preferences.Get("recentTitle2", ""));
            Preferences.Set("recentText2", Preferences.Get("recentText1", ""));
            Preferences.Set("recentTitle2", Preferences.Get("recentTitle1", ""));
            Preferences.Set("recentText1", message);
            Preferences.Set("recentTitle1", title);
           
        }


        
        private async void SendNotClicked(object sender, EventArgs e)
        {
            string title = titlen.Text;
            string message = contentn.Text;

            if (string.IsNullOrEmpty(title) && string.IsNullOrEmpty(message))
            {
                await DisplayAlert("Error", "Please enter a message", "OK");
            }
            else
            {
                // Send the message to the MainActivity using MessagingCenter
                MessagingCenter.Send(this, "SendNotification", (title, message)); // Pass title and message as a tuple
                SaveNextRecent(message, title);
                // Clear the text inputs after sending the notification
                titlen.Text = string.Empty;
                contentn.Text = string.Empty;
            }
        }

        private async void Saved(object sender, EventArgs e)
        {
            string title = titlen.Text;
            string content = contentn.Text;

            if (string.IsNullOrEmpty(title) && string.IsNullOrEmpty(content))
            {
                await DisplayAlert("Error", "Please enter a message\n(Saving Titles only is not yet supported)", "OK");
            }
            else if (string.IsNullOrEmpty(content))
            {
                await DisplayAlert("Error", "Message content cannot be empty", "OK");
            }
            else
            {
                // Save the title and content using WriteToNextSaved method
                WriteToNextSaved(title, content);
            }

            // Clear the text inputs after saving the message
            titlen.Text = string.Empty;
            contentn.Text = string.Empty;
        }
    }
}
