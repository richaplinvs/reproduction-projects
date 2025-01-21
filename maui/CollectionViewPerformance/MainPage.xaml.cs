namespace ListPerformanceIssue;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	 private async void OnNavigateToMyListPageClicked(object sender, EventArgs e)
     {
     	await Navigation.PushAsync(new MyListPage());
     }
}

