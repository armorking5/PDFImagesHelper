using Microsoft.Extensions.Logging;

namespace PDFImagesHelper;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
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

#if WINDOWS
        builder.Services.AddTransient<IFolderPicker, Platforms.Windows.MAUIFolderPicker>();
#elif MACCATALYST
        builder.Services.AddTransient<IFolderPicker, Platforms.MacCatalyst.MAUIFolderPicker>();
#endif
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<App>();


        return builder.Build();
	}
}
