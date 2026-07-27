namespace GlyphRecycledBitmapRepro;

public partial class MainPage : ContentPage
{
    private const int GeneratedButtonCount = 12;
    private static readonly string[] Glyphs =
        ["D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O"];

    private int churnCount;

    public MainPage()
    {
        InitializeComponent();
        AddGeneratedButtons();
    }

    /// <summary>
    /// A grid of glyph-icon buttons. Volume matters: the more glyph bitmaps that pass
    /// through Glide's pool, the more likely a pooled bitmap is reused (and therefore
    /// recycled) while an existing MaterialButton icon still references it.
    /// </summary>
    private void AddGeneratedButtons()
    {
        for (var index = 0; index < GeneratedButtonCount; index++)
        {
            GeneratedButtons.Add(new Button
            {
                Text = $"Glyph {Glyphs[index]}",
                ContentLayout = new Button.ButtonContentLayout(Button.ButtonContentLayout.ImagePosition.Left, 10),
                ImageSource = CreateGlyph(Glyphs[index], Colors.Purple)
            });
        }
    }

    /// <summary>
    /// Reassigns every glyph icon. Each reassignment disposes the previous
    /// ImageSourceServiceResult, which clears the Glide request and returns the old
    /// bitmap to the pool, then immediately decodes new glyphs that can reuse it.
    /// </summary>
    private void OnChurnClicked(object? sender, EventArgs e)
    {
        churnCount++;
        var colour = churnCount % 2 == 0 ? Colors.Orange : Colors.Teal;

        foreach (var button in GeneratedButtons.Children.OfType<Button>())
        {
            var glyph = button.Text.Replace("Glyph ", string.Empty);
            button.ImageSource = CreateGlyph(glyph, colour);
        }

        StatusLabel.Text = $"Churned glyph cache {churnCount} time(s). Now background the app and reopen it.";
    }

    private static FontImageSource CreateGlyph(string glyph, Color colour) => new()
    {
        FontFamily = "OpenSansRegular",
        Glyph = glyph,
        Size = 35,
        Color = colour
    };
}
