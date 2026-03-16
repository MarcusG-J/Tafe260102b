using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Globalization;
using Windows.UI.Popups;
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
	public sealed partial class CurrencyConverter : Page
	{
		public CurrencyConverter()
		{
			this.InitializeComponent();
		}

		private async void CalculateButton_Click(object sender, RoutedEventArgs e)
		{
			double outputAmount;
			double outputCalc;
			string outputAmountSymbol;
			string outputCalcSymbol;

			// Input validation for price
			try
			{
				outputAmount = double.Parse(amountTextBox.Text);
			}
			catch
			{
				var dialog = new MessageDialog("Pleas enter a valid amount");
				await dialog.ShowAsync();
				amountTextBox.Focus(FocusState.Programmatic);
				amountTextBox.SelectAll();
				return;
			}

			// Applying correct symbol to outputAmountTextBlock
			if (fromCurrencyComboBox.SelectedIndex == 0)
			{
				outputAmountSymbol = "$";
			}
			else if (fromCurrencyComboBox.SelectedIndex == 1)
			{
				outputAmountSymbol = "€";
			}
			else if (fromCurrencyComboBox.SelectedIndex == 2)
			{
				outputAmountSymbol = "£";
			}
			else
			{
				outputAmountSymbol = "₹";
			}

			outputAmountTextBlock.Text = outputAmountSymbol + outputAmount.ToString() + " =";

			// Applying correct currency icon to outputCalcTextBlock
			if (toCurrencyComboBox.SelectedIndex == 0)
			{
				outputCalcSymbol = "$";
			}
			else if (toCurrencyComboBox.SelectedIndex == 1)
			{
				outputCalcSymbol = "€";
			}
			else if (toCurrencyComboBox.SelectedIndex == 2)
			{
				outputCalcSymbol = "£";
			}
			else
			{
				outputCalcSymbol = "₹";
			}


			// Calling methods based on which FROM combo box item is selected
			if (fromCurrencyComboBox.SelectedIndex == 0)
			{
				outputCalc = ConvertFromUSD(outputAmount);
				outputCalcTextBlock.Text = outputCalcSymbol + String.Format("{0:F2}", outputCalc);
			}
			else if (fromCurrencyComboBox.SelectedIndex == 1)
			{
				outputCalc = ConvertFromEUR(outputAmount);
				outputCalcTextBlock.Text = outputCalcSymbol + String.Format("{0:F2}", outputCalc);
			}
			else if (fromCurrencyComboBox.SelectedIndex == 2)
			{
				outputCalc = ConvertFromGBP(outputAmount);
				outputCalcTextBlock.Text = outputCalcSymbol + String.Format("{0:F2}", outputCalc);
			}
			else
			{
				outputCalc = ConvertFromINR(outputAmount);
				outputCalcTextBlock.Text = outputCalcSymbol + String.Format("{0:F2}", outputCalc);
			}

			// Nested ifs to display the correct values in fromToTextBlock and toFromTextBlock
			if (fromCurrencyComboBox.SelectedIndex == 0) // USD
			{
				if (toCurrencyComboBox.SelectedIndex == 0) // USD
				{
					fromToTextBlock.Text = "1 USD = 1 USD";
					toFromTextBlock.Text = "1 USD = 1 USD";
				}
				else if (toCurrencyComboBox.SelectedIndex == 1) // EUR
				{
					fromToTextBlock.Text = "1 USD = 0.85189982 Euros";
					toFromTextBlock.Text = "1 Euro = 1.1739732 USD";
				}
				else if (toCurrencyComboBox.SelectedIndex == 2) // GBP
				{
					fromToTextBlock.Text = "1 USD = 0.72872436 British Pounds";
					toFromTextBlock.Text = "1 British Pound = 1.371907 USD";
				}
				else // INR
				{
					fromToTextBlock.Text = "1 USD = 74.257327 Indian Rupees";
					toFromTextBlock.Text = "1 Indian Rupee = 0.011492628 USD";
				}
			}
			else if (fromCurrencyComboBox.SelectedIndex == 1) // EUR
			{
				if (toCurrencyComboBox.SelectedIndex == 0) // USD
				{
					fromToTextBlock.Text = "1 Euro = 1.1739732 USD";
					toFromTextBlock.Text = "1 USD = 0.85189982 Euros";
				}
				else if (toCurrencyComboBox.SelectedIndex == 1) // EUR
				{
					fromToTextBlock.Text = "1 Euro = 1 Euro";
					toFromTextBlock.Text = "1 Euro = 1 Euro";
				}
				else if (toCurrencyComboBox.SelectedIndex == 2) // GBP
				{
					fromToTextBlock.Text = "1 Euro = 0.8556672 British Pounds";
					toFromTextBlock.Text = "1 British Pound = 1.1686692 Euros";
				}
				else // INR
				{
					fromToTextBlock.Text = "1 Euro = 87.00755 Indian Rupees";
					toFromTextBlock.Text = "1 Indian Rupee = 0.0013492774 Euros";
				}
			}
			else if (fromCurrencyComboBox.SelectedIndex == 2) // GBP
			{
				if (toCurrencyComboBox.SelectedIndex == 0) // USD
				{
					fromToTextBlock.Text = "1 British Pound = 1.371907 USD";
					toFromTextBlock.Text = "1 USD = 0.72872436 British Pounds";
				}
				else if (toCurrencyComboBox.SelectedIndex == 1) // EUR
				{
					fromToTextBlock.Text = "1 British Pound = 1.1686692 Euros";
					toFromTextBlock.Text = "1 Euro = 0.8556672 British Pounds";
				}
				else if (toCurrencyComboBox.SelectedIndex == 2) // GBP
				{
					fromToTextBlock.Text = "1 British Pound = 1 British Pound";
					toFromTextBlock.Text = "1 British Pound = 1 British Pound";
				}
				else // INR
				{
					fromToTextBlock.Text = "1 British Pound = 101.686692 Indian Rupees";
					toFromTextBlock.Text = "1 Indian Rupee = 0.0098339397 British Pounds";
				}
			}
			else
			{
				if (toCurrencyComboBox.SelectedIndex == 0) // USD
				{
					fromToTextBlock.Text = "1 Indian Rupee = 0.011492628 USD";
					toFromTextBlock.Text = "1 USD = 74.257327 Indian Rupees";
				}
				else if (toCurrencyComboBox.SelectedIndex == 1) // EUR
				{
					fromToTextBlock.Text = "1 Indian Rupee = 0.0013492774 Euros";
					toFromTextBlock.Text = "1 Euro = 87.00755 Indian Rupees";
				}
				else if (toCurrencyComboBox.SelectedIndex == 2) // GBP
				{
					fromToTextBlock.Text = "1 Indian Rupee = 0.0098339397 British Pounds";
					toFromTextBlock.Text = "1 British Pound = 101.686692 Indian Rupees";
				}
				else // INR
				{
					fromToTextBlock.Text = "1 British Pound = 101.686692 Indian Rupees";
					toFromTextBlock.Text = "1 Indian Rupee = 0.0098339397 British Pounds";
				}
			}
		}

		// Method for converting from US Dollars
		private double ConvertFromUSD(double amount)
		{
			const double EUR = 0.85189982;
			const double GBP = 0.72872436;
			const double INR = 74.257327;

			if (toCurrencyComboBox.SelectedIndex == 0)
			{
				return amount;
			}
			else if (toCurrencyComboBox.SelectedIndex == 1)
			{
				return amount * EUR;
			}
			else if (toCurrencyComboBox.SelectedIndex == 2)
			{
				return amount * GBP;
			}
			else
			{
				return amount * INR;
			}
		}

		// Method for converting from Euros
		private double ConvertFromEUR(double amount)
		{
			const double USD = 1.1739732;
			const double GBP = 0.8556672;
			const double INR = 87.00755;

			if (toCurrencyComboBox.SelectedIndex == 0)
			{
				return amount * USD;
			}
			else if (toCurrencyComboBox.SelectedIndex == 1)
			{
				return amount;
			}
			else if (toCurrencyComboBox.SelectedIndex == 2)
			{
				return amount * GBP;
			}
			else
			{
				return amount * INR;
			}
		}

		// Method for converting from British Pounds
		private double ConvertFromGBP(double amount)
		{
			const double USD = 1.371907;
			const double EUR = 1.1686692;
			const double INR = 101.68635;

			if (toCurrencyComboBox.SelectedIndex == 0)
			{
				return amount * USD;
			}
			else if (toCurrencyComboBox.SelectedIndex == 1)
			{
				return amount * EUR;
			}
			else if (toCurrencyComboBox.SelectedIndex == 2)
			{
				return amount;
			}
			else
			{
				return amount * INR;
			}
		}

		// Method for converting from Indian Rupees
		private double ConvertFromINR(double amount)
		{
			const double USD = 0.011492628;
			const double EUR = 0.013492774;
			const double GBP = 0.0098339397;

			if (toCurrencyComboBox.SelectedIndex == 0)
			{
				return amount * USD;
			}
			else if (toCurrencyComboBox.SelectedIndex == 1)
			{
				return amount * EUR;
			}
			else if (toCurrencyComboBox.SelectedIndex == 2)
			{
				return amount * GBP;
			}
			else
			{
				return amount;
			}
		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainMenu));
		}
	}
}
