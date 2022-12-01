namespace ExpenseTracker.ViewModels
{
    public partial class LoginScreenViewModel:AppViewModelBase
    {
        [RelayCommand]
        private async Task ForgotPassword()
        {
            await NavigationService.PushAsync(new ResetPasswordScreen());
        }

        [RelayCommand]
        private async Task RegisterUser()
        {
            await NavigationService.PushAsync(new RegisterUserScreen());
        }
    }
}
