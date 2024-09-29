using Microsoft.Maui.Storage;
using System.Timers;
using System.ComponentModel;
using Microsoft.Maui.Controls;

namespace notifyd;

public partial class Saved : ContentPage, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private System.Timers.Timer _timer;

    private string[] _savedTexts = new string[10];

    public string[] SavedTexts
    {
        get => _savedTexts;
        set
        {
            _savedTexts = value;
            OnPropertyChanged(nameof(SavedTexts));
        }
    }

    public Saved()
    {
        InitializeComponent();
        BindingContext = this; // Add this line
        _timer = new System.Timers.Timer(10000); // 10 seconds interval
        _timer.Elapsed += UpdateValues;
        _timer.Start();

        // Force reload of all saved values
        ReloadSavedValues();

        // Subscribe to the UpdateRecentNotifications message
        MessagingCenter.Subscribe<MainPage>(this, "UpdateRecentNotifications", (sender) =>
        {
            /*ReloadRecentNotifications();*/
        });
    }

    private void ReloadSavedValues()
    {
        for (int i = 0; i < 10; i++)
        {
            _savedTexts[i] = Preferences.Get($"savedText{i}", " ");
        }

        OnPropertyChanged(nameof(SavedTexts));
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Force reload of all saved values when the page appears
        ReloadSavedValues();
    }

    private void sendNotification(string title, string message)
    {
        MessagingCenter.Send(this, "SendNotification", (title, message));
    }

    private void UpdateValues(object source, ElapsedEventArgs e)
    {
        for (int i = 0; i < 10; i++)
        {
            _savedTexts[i] = Preferences.Get($"savedText{i}", " ");
        }

        OnPropertyChanged(nameof(SavedTexts));
    }

    private void S0(object sender, EventArgs e)
    {
        string title = Preferences.Get("savedTextT0", "");
        string text = Preferences.Get("savedText0", "");
        if (!string.IsNullOrEmpty(text))
        {
            sendNotification(title, text);
        }
    }
    private void S2(object sender, EventArgs e)
    {
        string title = Preferences.Get("savedTextT2", "");
        string text = Preferences.Get("savedText2", "");
        if (!string.IsNullOrEmpty(text))
        {
            sendNotification(title, text);
        }
    }
    private void S3(object sender, EventArgs e)
    {
        string title = Preferences.Get("savedTextT3", "");
        string text = Preferences.Get("savedText3", "");
        if (!string.IsNullOrEmpty(text))
        {
            sendNotification(title, text);
        }
    }
    private void S4(object sender, EventArgs e)
    {
        string title = Preferences.Get("savedTextT4", "");
        string text = Preferences.Get("savedText4", "");
        if (!string.IsNullOrEmpty(text))
        {
            sendNotification(title, text);
        }
    }
    private void S5(object sender, EventArgs e)
    {
        string title = Preferences.Get("savedTextT5", "");
        string text = Preferences.Get("savedText5", "");
        if (!string.IsNullOrEmpty(text))
        {
            sendNotification(title, text);
        }
    }
    private void S6(object sender, EventArgs e)
    {
        string title = Preferences.Get("savedTextT6", "");
        string text = Preferences.Get("savedText6", "");
        if (!string.IsNullOrEmpty(text))
        {
            sendNotification(title, text);
        }
    }
    private void S7(object sender, EventArgs e)
    {
        string title = Preferences.Get("savedTextT7", "");
        string text = Preferences.Get("savedText7", "");
        if (!string.IsNullOrEmpty(text))
        {
            sendNotification(title, text);
        }
    }
    private void S8(object sender, EventArgs e)
    {
        string title = Preferences.Get("savedTextT8", "");
        string text = Preferences.Get("savedText8", "");
        if (!string.IsNullOrEmpty(text))
        {
            sendNotification(title, text);
        }
    }
    private void S9(object sender, EventArgs e)
    {
        string title = Preferences.Get("savedTextT9", "");
        string text = Preferences.Get("savedText9", "");
        if (!string.IsNullOrEmpty(text))
        {
            sendNotification(title, text);
        }
    }
    private async void CA(object sender, EventArgs e)
    {


        bool result = await DisplayAlert("Confirmation", "Delete all Saved Entries?", "OK", "Cancel");

        if (result)
        {
            Preferences.Set("savedTextT0", "");
            Preferences.Set("savedTextT2", "");
            Preferences.Set("savedTextT3", "");
            Preferences.Set("savedTextT4", "");
            Preferences.Set("savedTextT5", "");
            Preferences.Set("savedTextT6", "");
            Preferences.Set("savedTextT7", "");
            Preferences.Set("savedTextT8", "");
            Preferences.Set("savedTextT9", "");
            Preferences.Set("savedText0", "");
            Preferences.Set("savedText2", "");
            Preferences.Set("savedText3", "");
            Preferences.Set("savedText4", "");
            Preferences.Set("savedText5", "");
            Preferences.Set("savedText6", "");
            Preferences.Set("savedText7", "");
            Preferences.Set("savedText8", "");
            Preferences.Set("savedText9", "");
        }
        else
        {
            // Cancel button was clicked
        }

    }
}