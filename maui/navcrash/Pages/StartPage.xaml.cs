using NavCrash;

namespace NavCrash.Pages;

public partial class StartPage : ContentPage
{
    public StartPage()
    {
        InitializeComponent();
    }

    private async void OnOpenClicked(object? sender, EventArgs e)
    {
        LoopNavigationRenderer.ArmLayoutLoop = true;
        await Navigation.PushAsync(new TabsPage());
    }
}
