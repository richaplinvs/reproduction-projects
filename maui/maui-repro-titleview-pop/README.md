# Title view pop crash

Popping a page whose `NavigationPage.TitleView` is an `Image`, back to a page with `NavigationPage.HasNavigationBar="False"`, terminates the iOS app.

```
System.InvalidOperationException: PlatformView cannot be null here
   at Microsoft.Maui.Handlers.ViewHandler`2.get_PlatformView()
   at Microsoft.Maui.Handlers.ImageHandler.OnWindowChanged()
   at Microsoft.Maui.Platform.MauiImageView.MovedToWindow()
```

MAUI disconnects the image handler while popping. UIKit only removes the title image after the navigation-bar hide animation finishes. `MovedToWindow` then reads `PlatformView`, and the getter throws because the handler is already disconnected.

Popping back to a page that still shows the navigation bar does not throw. Set `NavigationPage.HasNavigationBar="True"` on `HomePage` to see that path.

## Environment

- .NET MAUI 10.0.110 (`Microsoft.Maui.Controls`)
- `net10.0-ios27.1`
- iOS 27.2

## Steps

1. Run the iOS app.
2. Tap **Open**.
3. Tap **Back**.

## Expected

The first page returns.

## Actual

The process terminates with `PlatformView cannot be null here`.

## Workaround

`HandlerProperties.DisconnectPolicy="Manual"` on the title `Image` keeps that handler connected until the native view has left the window, so the late `MovedToWindow` call does not throw. It is commented out in `DetailsPage.xaml`, so the crash still happens.
