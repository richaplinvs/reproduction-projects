using CoreGraphics;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using UIKit;

namespace NavCrash;

// On iOS 27, assigning the navigation controller's view frame from inside
// ViewWillLayoutSubviews recalculates the safe area and starts the layout again.
// Open arms this before the next page is pushed.
public class LoopNavigationRenderer : NavigationRenderer
{
    public static bool ArmLayoutLoop { get; set; }

    public override void ViewWillLayoutSubviews()
    {
        base.ViewWillLayoutSubviews();
        if (!ArmLayoutLoop || View is null)
        {
            return;
        }

        var frame = View.Frame;
        frame.Width = (nfloat)Math.Max(1, frame.Width - 1);
        View.Bounds = frame;
        View.SetNeedsLayout();
    }
}
