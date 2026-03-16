using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainMenu : Page
	{
		public MainMenu()
		{
			InitializeComponent();
		}

		private void mathCalcButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainPage));
		}

		private void currencyCalcButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(CurrencyConverter));
		}

		private void mortgageCalcButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(mortgagaCalculator));
		}

		private void tripCalcButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(TripCalculator));
		}

		private void ExitButton_Click(object sender, RoutedEventArgs e)
		{
			CoreApplication.Exit();


		}
	}
}
