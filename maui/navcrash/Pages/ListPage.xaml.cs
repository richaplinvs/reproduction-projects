namespace NavCrash.Pages;

public partial class ListPage : ContentPage
{
    public ListPage()
    {
        InitializeComponent();
        Content = BuildPage();
    }

    private static View BuildPage()
    {
        var page = new Grid
        {
            RowDefinitions =
            {
                new RowDefinition(GridLength.Auto),
                new RowDefinition(new GridLength(50)),
                new RowDefinition(new GridLength(55)),
                new RowDefinition(GridLength.Star)
            }
        };

        page.Add(new Label
        {
            Text = "Status",
            Margin = new Thickness(16, 8, 16, 0)
        }, 0, 0);
        page.Add(new Label
        {
            Text = "List",
            FontSize = 22,
            FontAttributes = FontAttributes.Bold,
            HorizontalTextAlignment = TextAlignment.Center,
            VerticalTextAlignment = TextAlignment.Center
        }, 0, 1);
        page.Add(new Border
        {
            Margin = new Thickness(16, 4),
            StrokeThickness = 0,
            BackgroundColor = Color.FromArgb("#78909C"),
            Content = new Label
            {
                Text = "Summary band",
                TextColor = Colors.White,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            }
        }, 0, 2);

        var stack = new VerticalStackLayout { Spacing = 8 };
        stack.Add(BuildHeader());
        for (var index = 0; index < 60; index++)
        {
            stack.Add(BuildRow());
        }

        stack.Add(new CollectionView
        {
            ItemsSource = BuildRows(40),
            ItemTemplate = new DataTemplate(() => BuildRow()),
            HeightRequest = 640
        });
        page.Add(new ScrollView { Content = stack }, 0, 3);
        return page;
    }

    private static View BuildHeader()
    {
        var cards = new CollectionView
        {
            ItemsSource = Enumerable.Range(1, 12).Select(index => $"Card {index}").ToList(),
            HeightRequest = 220,
            ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Horizontal) { ItemSpacing = 8 },
            ItemTemplate = new DataTemplate(() => BuildCard())
        };

        return new VerticalStackLayout
        {
            Spacing = 8,
            Padding = new Thickness(0, 8, 0, 8),
            Children =
            {
                new Label { Text = "12 cards", Margin = new Thickness(16, 0) },
                cards
            }
        };
    }

    private static View BuildCard()
    {
        var stack = new VerticalStackLayout { Spacing = 6, Padding = 12, WidthRequest = 240 };
        for (var line = 0; line < 8; line++)
        {
            stack.Add(new Label { Text = $"Card line {line}" });
        }

        stack.Add(new BoxView { HeightRequest = 48, Color = Color.FromArgb("#455A64") });
        return new Border
        {
            Margin = new Thickness(8, 0),
            StrokeThickness = 0,
            BackgroundColor = Color.FromArgb("#E8EEF0"),
            Content = stack
        };
    }

    private static View BuildRow()
    {
        var grid = new Grid
        {
            Padding = new Thickness(8),
            ColumnDefinitions =
            {
                new ColumnDefinition(new GridLength(16)),
                new ColumnDefinition(new GridLength(36)),
                new ColumnDefinition(new GridLength(64)),
                new ColumnDefinition(GridLength.Star),
                new ColumnDefinition(new GridLength(28))
            },
            RowDefinitions =
            {
                new RowDefinition(GridLength.Auto),
                new RowDefinition(GridLength.Auto),
                new RowDefinition(GridLength.Auto)
            }
        };

        var marker = new BoxView { Color = Color.FromArgb("#78909C"), WidthRequest = 8 };
        grid.Add(marker, 0, 0);
        grid.SetRowSpan(marker, 3);
        grid.Add(new Label { Text = "A", FontAttributes = FontAttributes.Bold, HorizontalTextAlignment = TextAlignment.Center }, 1, 0);
        grid.Add(new Label { Text = "Ready", FontAttributes = FontAttributes.Bold }, 2, 0);

        var detail = new VerticalStackLayout { Spacing = 2 };
        detail.Add(new Label { Text = "Primary line", FontAttributes = FontAttributes.Bold });
        detail.Add(new Label { Text = "Secondary line with a longer piece of text" });
        detail.Add(new Label { Text = "Third line" });
        grid.Add(detail, 3, 0);
        grid.SetRowSpan(detail, 2);

        var chevron = new Label { Text = ">", VerticalTextAlignment = TextAlignment.Center };
        grid.Add(chevron, 4, 0);
        grid.SetRowSpan(chevron, 3);

        var inner = new Border
        {
            Margin = new Thickness(0, 4, 0, 0),
            Padding = new Thickness(6),
            StrokeThickness = 0,
            BackgroundColor = Colors.White,
            Content = new Label { Text = "Nested block" }
        };
        grid.Add(inner, 2, 2);
        Grid.SetColumnSpan(inner, 2);

        return new Border
        {
            Margin = new Thickness(10, 4),
            HeightRequest = 96,
            StrokeThickness = 0,
            BackgroundColor = Color.FromArgb("#546E7A"),
            Content = grid
        };
    }

    private static List<ListRow> BuildRows(int count)
    {
        return Enumerable.Range(1, count)
            .Select(index => new ListRow($"Item {index}", $"Line {index}", index % 2 == 0 ? "Even" : "Odd"))
            .ToList();
    }
}

public sealed class ListRow
{
    public ListRow(string title, string subtitle, string note)
    {
        Title = title;
        Subtitle = subtitle;
        Note = note;
    }

    public string Title { get; }

    public string Subtitle { get; }

    public string Note { get; }
}
