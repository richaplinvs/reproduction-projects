namespace PopopOnAppearingIssue;

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Extensions;

public partial class MainPage : ContentPage, INotifyPropertyChanged
{
	public MainPage()
	{
		InitializeComponent();
		BindingContext = this;
	}

	private int _count;
	public int Count
	{
		get => _count;
		set
		{
			if (_count == value) return;
			_count = value;
			OnPropertyChanged();
		}
	}

	override protected void OnAppearing()
	{
		base.OnAppearing();
		Console.WriteLine($"OnAppearing Called: {++Count}");
	}

	public async Task DisplayAutomaticallyClosingPopup(TimeSpan displayTimeSpan, CancellationToken token)
	{
		var popup = new SimplePopup();

		// This Popup is closed programmatically after 2 seconds
		this.ShowPopup(popup, new PopupOptions
		{
			CanBeDismissedByTappingOutsideOfPopup = false
		});

		await Task.Delay(displayTimeSpan, token);

		await this.ClosePopupAsync(token);
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		_ = DisplayAutomaticallyClosingPopup(TimeSpan.FromSeconds(2), CancellationToken.None);
	}
}
