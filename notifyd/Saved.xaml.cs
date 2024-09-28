namespace notifyd;

public partial class Saved : ContentPage
{
    private string _savedText1 = Preferences.Get("savedText1", " ");
    public string SavedText1
    {
        get => _savedText1;
        set
        {
            _savedText1 = value;
            OnPropertyChanged(nameof(SavedText1));
        }
    }

    private string _savedText2 = Preferences.Get("savedText2", " ");
    public string SavedText2
    {
        get => _savedText2;
        set
        {
            _savedText2 = value;
            OnPropertyChanged(nameof(SavedText2));
        }
    }

    private string _savedText3 = Preferences.Get("savedText3", " ");
    public string SavedText3
    {
        get => _savedText3;
        set
        {
            _savedText3 = value;
            OnPropertyChanged(nameof(SavedText3));
        }
    }

    private string _savedText4 = Preferences.Get("savedText4", " ");
    public string SavedText4
    {
        get => _savedText4;
        set
        {
            _savedText4 = value;
            OnPropertyChanged(nameof(SavedText4));
        }
    }

    private string _savedText5 = Preferences.Get("savedText5", " ");
    public string SavedText5
    {
        get => _savedText5;
        set
        {
            _savedText5 = value;
            OnPropertyChanged(nameof(SavedText5));
        }
    }

    private string _savedText6 = Preferences.Get("savedText6", " ");
    public string SavedText6
    {
        get => _savedText6;
        set
        {
            _savedText6 = value;
            OnPropertyChanged(nameof(SavedText6));
        }
    }

    private string _savedText7 = Preferences.Get("savedText7", " ");
    public string SavedText7
    {
        get => _savedText7;
        set
        {
            _savedText7 = value;
            OnPropertyChanged(nameof(SavedText7));
        }
    }

    private string _savedText8 = Preferences.Get("savedText8", " ");
    public string SavedText8
    {
        get => _savedText8;
        set
        {
            _savedText8 = value;
            OnPropertyChanged(nameof(SavedText8));
        }
    }

    private string _savedText9 = Preferences.Get("savedText9", " ");
    public string SavedText9
    {
        get => _savedText9;
        set
        {
            _savedText9 = value;
            OnPropertyChanged(nameof(SavedText9));
        }
    }

    private string _savedText0 = Preferences.Get("savedText0", " ");
    public string SavedText0
    {
        get => _savedText0;
        set
        {
            _savedText0 = value;
            OnPropertyChanged(nameof(SavedText0));
        }
    }

    // Properties for recent texts
    private string _recentText1 = Preferences.Get("recentText1", " ");
    public string RecentText1
    {
        get => _recentText1;
        set
        {
            _recentText1 = value;
            OnPropertyChanged(nameof(RecentText1));
        }
    }

    private string _recentText2 = Preferences.Get("recentText2", " ");
    public string RecentText2
    {
        get => _recentText2;
        set
        {
            _recentText2 = value;
            OnPropertyChanged(nameof(RecentText2));
        }
    }

    private string _recentText3 = Preferences.Get("recentText3", " ");
    public string RecentText3
    {
        get => _recentText3;
        set
        {
            _recentText3 = value;
            OnPropertyChanged(nameof(RecentText3));
        }
    }

    public Saved()
    {
        

        InitializeComponent();
    }
}