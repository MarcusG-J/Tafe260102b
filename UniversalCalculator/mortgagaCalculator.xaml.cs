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
	/// </summary>
	public sealed partial class mortgagaCalculator : Page
	{
		public mortgagaCalculator()
		{
			this.InitializeComponent();
		}

		public static double Calculation(double principalBorrow, double monthlyInterestRate, int numberOfPayments)
		{
			double numerator = principalBorrow * Math.Pow(1 + monthlyInterestRate, numberOfPayments) * monthlyInterestRate;
			double denominator = Math.Pow(1 + monthlyInterestRate, numberOfPayments) - 1;
			double monthlyRepayment = numerator / denominator;
			return monthlyRepayment;
		}
		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainMenu));
		}

		private void CalculateButton_Click(object sender, RoutedEventArgs e)
		{
			repaymentTextBox.Text = "";
			double yearlyIntrest = double.Parse(annualTextBox.Text);
			double principleBorrow = double.Parse(borrowedTextBox.Text);
			int Years = int.Parse(yearsTextBox.Text);
			int andMonths = int.Parse(monthsTextBox.Text);
			double monthlyIntrestRate = yearlyIntrest / 12.0;
			monthlyIntrestRate = monthlyIntrestRate * 0.01;

			monthlyTextBox.Text = monthlyIntrestRate.ToString();

			int numberOfPayments = Years * 12 + andMonths;

			//double numerator = principleBorrow * Math.Pow(1 + monthlyIntrestRate, numberOfPayments) * monthlyIntrestRate;
			//double denominator = Math.Pow(1 + monthlyIntrestRate, numberOfPayments) - 1;
			//double monthlyRepayment = numerator / denominator;
			//monthlyTextBox.Text = monthlyIntrestRate.ToString();

			repaymentTextBox.Text = Calculation(principleBorrow, monthlyIntrestRate, numberOfPayments).ToString();
		}
    }
}
