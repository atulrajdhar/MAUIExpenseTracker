#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif

using Android.Content.Res;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;

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

        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
{

#if ANDROID
    handler.PlatformView.BackgroundTintList = ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
#elif IOS || MACCATALYST
// TODO: REPLACE THIS CODE WITH IOS AND MACCATALYST NATIVE CODE
        handler.PlatformView.EditingDidBegin += (s, e) =>
        {
            handler.PlatformView.PerformSelector(new ObjCRuntime.Selector("selectAll"), null, 0.0f);
        };
#elif WINDOWS
// TODO: REPLACE THIS CODE WITH WINDOWS NATIVE CODE
        handler.PlatformView.GotFocus += (s, e) =>
        {
            handler.PlatformView.SelectAll();
        };
#endif
    
});
	}

	private async Task<bool> LoadPreferences()
	{
        return await _settingsService.Get<bool>("ShowOnBoardingScreen", true);
    }
}
