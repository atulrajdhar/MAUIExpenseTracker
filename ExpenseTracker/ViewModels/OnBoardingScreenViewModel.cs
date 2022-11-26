namespace ExpenseTracker.ViewModels;
public partial class OnBoardingScreenViewModel : AppViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<OnBoardingScreenModel> onBoardingScreens;

    public OnBoardingScreenViewModel()
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
    }
}
