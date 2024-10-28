namespace notifyd;
using Microsoft.Maui.Storage;

public partial class UserPreferences : ContentPage
{
	public UserPreferences()
	{
		InitializeComponent();
	}
    public void openlink(string url)
    {
        Browser.OpenAsync(url);
    }

    private void Git(Object sender, EventArgs e)
    {
        openlink("https://github.com/realdcre");

    }
    private void X(object sender, EventArgs e)
    {
        openlink("https://x.com/real_dcre");
    }
    private void OnIOHChange(object sender, CheckedChangedEventArgs e)
    {
        if (PrefIOH.IsChecked == true)
        {
            Preferences.Set("IOH", true);
        }
        else
        {
            Preferences.Set("IOH", false);
        }
    }
    private void OnSIBChange(object sender, CheckedChangedEventArgs e)
    {
        if (PrefSIB.IsChecked == true)
        {
            Preferences.Set("SIB", true);
        }
        else
        {
            Preferences.Set("SIB", false);
        }
    }
    private void OnSQLEChange(object sender, CheckedChangedEventArgs e)
    {
        if (PrefIOH.IsChecked == true)
        {
            Preferences.Set("SQL(E)", true);
        }
        else
        {
            Preferences.Set("SQL(E)", false);
        }
    }


}


