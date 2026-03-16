using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// Author Marcus Moore  feature trip price
	/// </summary>
	public sealed partial class TripCalculator : Page
	{
		public TripCalculator()
		{
			this.InitializeComponent();
		}

		private void dateHireButton_Click(object sender, RoutedEventArgs e)
		{

			dateHireDatePicker.SelectedDate = DateTime.Today;


		}

		private void CalulatorButton_Click(object sender, RoutedEventArgs e)
		{
			const int PER_KILO = 2;
			const int PER_DAY = 150;
			int startKilo = 0;
			int endKilo = 0;
			int totalKilo = 0;
			int amountToPay = 0;
			int daysHired = 0;


			string endKiloText = null;
			string startKiloText = null;
			string daysHiredText = null;

			endKiloText = endKTextBox.Text;
			endKilo = Int32.Parse(endKiloText);
			startKiloText = startingKTextBox.Text;
			startKilo = Int32.Parse(startKiloText);

			totalKilo = endKilo - startKilo;

			daysHiredText = dayHiredTextox.Text;
			daysHired = Int32.Parse(daysHiredText);


			amountToPay = (PER_KILO * totalKilo) + (PER_DAY * daysHired);



			amountTOPayTeckBox.Text = amountToPay.ToString();

		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainMenu));
		}

	}
}
