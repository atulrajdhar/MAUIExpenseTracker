using Microsoft.Extensions.Logging;

namespace ExpenseTracker;

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

		RegisterViewModels(builder.Services);

		return builder.Build();
	}

    private static void RegisterViewModels(IServiceCollection services)
    {
		services.AddSingleton<OnBoardingPageViewModel>();
    }
}
