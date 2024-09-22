using Microsoft.Maui.Controls; // Ensure you have the correct using directive
using System;
using System.Globalization;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.ApplicationModel;





namespace notifyd;

public partial class About : ContentPage
{
	public About()
	{
		InitializeComponent();
	}
	public void openlink(string url)
	{
		Browser.OpenAsync(url);
	}

	private void Git(Object sender, EventArgs e) {
		openlink("https://github.com/realdcre");

    }
	private void X(object sender, EventArgs e)
	{
		openlink("https://x.com/real_dcre");
	}
}
