using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;

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
				fonts.AddFont("Rubik-Black.ttf", "RubikBlack");
				fonts.AddFont("Rubik-Bold.ttf", "RubikBold");
				fonts.AddFont("Rubik-Medium.ttf", "RubikMedium");
				fonts.AddFont("Rubik-Regular.ttf", "RubikRegular");
			})
			.ConfigureLifecycleEvents(events =>
            {
#if ANDROID
            				events.AddAndroid(android => android.OnCreate((activity, bundle) => MakeStatusBarTranslucent(activity)));

                            static void MakeStatusBarTranslucent(Android.App.Activity activity)
                            {
            					activity.Window.SetFlags(Android.Views.WindowManagerFlags.LayoutNoLimits, Android.Views.WindowManagerFlags.LayoutNoLimits);
            					activity.Window.ClearFlags(Android.Views.WindowManagerFlags.TranslucentStatus);
            					activity.Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
                            }
#endif
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

		RegisterViewModels(builder.Services);

		return builder.Build();
	}

    private static void RegisterViewModels(IServiceCollection services)
    {
		services.AddSingleton<OnBoardingScreenViewModel>();
    }
}
