using ExpenseTracker.Views;

namespace ExpenseTracker;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new OnBoardingPage());
	}
}
