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

        public MainPage()
        {
            InitializeComponent();
        }

        void WriteToNextSaved(string title, string message)
        {
            int[] noOfEntries = new int[10];

            // Initialize noOfEntries array
            for (int i = 0; i < 10; i++)
            {
                noOfEntries[i] = Preferences.Get($"noOfEntry{i}", 0);
            }

            int minIndex = FindMinIndex(noOfEntries);
            int maxNoOfEntry = FindMax(noOfEntries);

            int setNo = maxNoOfEntry + 1;
            Preferences.Set($"nrOfSavedEntry{minIndex}", setNo);
            Preferences.Set($"savedTextT{setNo}", title);
            Preferences.Set($"savedText{setNo}", message);

            // Update the saved text properties
            for (int i = 0; i < 10; i++)
            {
                if (Preferences.Get($"savedText{i}", " ") == " ")
                {
                    Preferences.Set($"savedText{i}", message);
                    break;
                }
            }
        }

        public int GetMostRecentPath()
        {
            int noOfEntry1 = Preferences.Get("nrOfSavedEntry1", 0);
            int noOfEntry2 = Preferences.Get("nrOfSavedEntry2", 0);
            int noOfEntry3 = Preferences.Get("nrOfSavedEntry3", 0);

            int lowestNumber = Math.Min(Math.Min(noOfEntry1, noOfEntry2), noOfEntry3);
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
                // Send the message to the MainActivity
                MessagingCenter.Send(this, "SendNotification", (title, message)); // Pass title and message as a tuple

                titlen.Text = string.Empty;
                contentn.Text = string.Empty;
            }
        }

        private async void Saved(object sender, EventArgs e)
        {
            string title = titlen.Text;
            string content = contentn.Text;

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(content))
            {
                await DisplayAlert("Error", "Please enter a message\n(Saving Titles only is not yet supported)", "OK");
            }
            else
            {
                WriteToNextSaved(title, content);
            }

            titlen.Text = string.Empty;
            contentn.Text = string.Empty;
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
    }
}