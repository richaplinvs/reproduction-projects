using Microsoft.Extensions.Logging;

namespace TitleViewPopCrash;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		AppDomain.CurrentDomain.UnhandledException += (_, args) =>
			Console.WriteLine(args.ExceptionObject);

		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
