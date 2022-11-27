#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif

namespace ExpenseTracker;

public partial class App : Application
{
    const int WindowWidth = 540;
    const int WindowHeight = 1000;

    private readonly ISettingsService _settingsService;
	public App(ISettingsService settingsService)
	{
		InitializeComponent();

        // Enable version tracking
        VersionTracking.Track();

        // Set app size on MS Windows
        Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
        {
#if WINDOWS
            var mauiWindow = handler.VirtualView;
            var nativeWindow = handler.PlatformView;
            nativeWindow.Activate();
            IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
            WindowId windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(windowHandle);
            AppWindow appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
            appWindow.Resize(new SizeInt32(WindowWidth, WindowHeight));
#endif
        });


        _settingsService = settingsService;
		bool showOnBoardingScreen = LoadPreferences().Result;
		if (showOnBoardingScreen)
			MainPage = new NavigationPage(new OnBoardingScreen());
		else
			MainPage = new NavigationPage(new LoginScreen());
	}

	private async Task<bool> LoadPreferences()
	{
        return await _settingsService.Get<bool>("ShowOnBoardingScreen", true);
    }
}
