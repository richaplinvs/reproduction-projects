using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;

namespace TabbedSelectionIssue;

public partial class MyTabbedPage : Microsoft.Maui.Controls.TabbedPage
{
	public MyTabbedPage()
	{
		// Regardless of color setttings then toolbar placement makes the colours change as expected.
		// On<Microsoft.Maui.Controls.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
		
		UnselectedTabColor = Colors.Red;
		SelectedTabColor = Colors.Orange;
		BarBackgroundColor = Colors.HotPink;

		InitializeComponent();

		
	}
}