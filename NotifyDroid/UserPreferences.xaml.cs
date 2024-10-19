namespace notifyd;

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
    private void PrefIOH(object sender, CheckedChangedEventArgs e)
    {
        
    }


}


