namespace TitleViewPopCrash;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

	private async void OnOpenClicked(object? sender, EventArgs e) =>
		await Navigation.PushAsync(new DetailsPage());
}
