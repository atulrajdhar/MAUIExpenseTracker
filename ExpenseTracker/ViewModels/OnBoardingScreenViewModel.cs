namespace ExpenseTracker.ViewModels;
public partial class OnBoardingScreenViewModel : AppViewModelBase
{

    private readonly ISettingsService _settingsService;

    [ObservableProperty]
    private ObservableCollection<OnBoardingScreenModel> onBoardingScreens;

    public OnBoardingScreenViewModel(ISettingsService settingsService)
    {
        OnBoardingScreens = new ObservableCollection<OnBoardingScreenModel>
        {
                new OnBoardingScreenModel
                {
                    Image = "safe.png",
                    Title = "SAFE AND SECURE",
                    Description = "No bank password or account number."
                },

                new OnBoardingScreenModel
                {
                    Image = "reminders.png",
                    Title = "BILL REMINDERS",
                    Description = "Automatic bill detection. No more late fees."
                },

                new OnBoardingScreenModel
                {
                    Image = "simple.png",
                    Title = "YOUR MONEY MADE SIMPLE",
                    Description = "Transform your SMS inbox into a daily interactive reports."
                }
        };

        this._settingsService = settingsService;
    }

    [RelayCommand]
    private async Task StartApp()
    {
        await _settingsService.Save("ShowOnBoardingScreen", false);        
        await NavigationService.PushAsync(new LoginScreen());
    }
}
