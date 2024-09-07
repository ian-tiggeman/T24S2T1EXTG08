using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
	public sealed partial class currencyConverter : Page
	{
		public currencyConverter()
		{
			this.InitializeComponent();
			fromComboBox.SelectedIndex = 0;
			toComboBox.SelectedIndex = 1;
		}

		private async void conversionButton_Click(object sender, RoutedEventArgs e)
		{
			double conversionAmount;
			double resultAmount;

			try
			{
				conversionAmount = double.Parse(amountTextBox.Text);
			}
			catch (Exception theException)
			{
				var dialogMessage = new MessageDialog("Please enter a valid amount.");
				await dialogMessage.ShowAsync();
				amountTextBox.Focus(FocusState.Programmatic);
				amountTextBox.SelectAll();
				return;
			}
			if (conversionAmount <= 0)
			{
				var dialogMessage = new MessageDialog("Amount must be greater than 0");
				await dialogMessage.ShowAsync();
				amountTextBox.Focus(FocusState.Programmatic);
				amountTextBox.SelectAll();
				return;
			}
			// Calculate the convesion rate
			resultAmount = calcConversion(conversionAmount);
			resultAmountTextBlock.Text = resultAmount.ToString("C");

		}

		private double calcConversion(double conversionAmount)
		{
			const double USD_TO_EUR = 0.85189982;
			const double USD_TO_GBP = 0.72872436;
			const double USD_TO_INR = 74.257327;
			const double EUR_TO_USD = 1.1739732;
			const double EUR_TO_GBP = 0.8556672;
			const double EUR_TO_INR = 87.00755;
			const double GBP_TO_USD = 1.371907;
			const double GBP_TO_EUR = 1.1686692;
			const double GBP_TO_INR = 101.68635;
			const double INR_TO_USD = 0.011492628;
			const double INR_TO_EUR = 0.013492774;
			const double INR_TO_GBP = 0.0098339397;


			String fromCombo, toCombo;
			String messageAmount = conversionAmount.ToString();
			String conversionRateFrom;

			// Get conversion option from the fromComboBox 
			fromCombo = fromComboBox.SelectedItem.ToString();
			// Get conversion option from the toComboBox 
			toCombo = toComboBox.SelectedItem.ToString();
			// Based on selected options, calculate currency conversion
			switch (fromCombo)
			{
				case "USD - US Dollar":
					{
						messageAmount += " US Dollars =";
						displayAmountTextBlock.Text = messageAmount;
						conversionRateFrom = "1 USD = ";
						if (toCombo.Equals("GBP - British Pound"))
						{
							resultTypeTextBlock.Text = "British Pounds";
							rate1TextBlock.Text = conversionRateFrom + USD_TO_GBP.ToString() + " British Pounds";
							rate2TextBlock.Text = "1 GBP = " + GBP_TO_USD + " US Dollars";
							return conversionAmount * USD_TO_GBP;
						}
						else if (toCombo.Equals("EUR - Euro"))
						{
							resultTypeTextBlock.Text = "Euros";
							rate1TextBlock.Text = conversionRateFrom + USD_TO_EUR.ToString() + " Euros";
							rate2TextBlock.Text = "1 EUR = " + EUR_TO_USD + " US Dollars";
							return conversionAmount * USD_TO_EUR;
						}
						else if (toCombo.Equals("INR - Indian Rupee"))
						{
							resultTypeTextBlock.Text = "Indian Rupees";
							rate1TextBlock.Text = conversionRateFrom + USD_TO_INR.ToString() + " Indian Rupees";
							rate2TextBlock.Text = "1 INR = " + INR_TO_USD + " US Dollars";
							return conversionAmount * USD_TO_INR;
						}
						else
						{
							return 0;
						}
					}
				case "GBP - British Pound":
					{
						messageAmount += " British Pounds =";
						displayAmountTextBlock.Text = messageAmount;
						conversionRateFrom = "1 GBP = ";
						if (toCombo.Equals("USD - US Dollar"))
						{
							resultTypeTextBlock.Text = "US Dollars";
							rate1TextBlock.Text = conversionRateFrom + GBP_TO_USD.ToString() + " US Dollars";
							rate2TextBlock.Text = "1 USD = " + USD_TO_GBP + " British Pounds";
							return conversionAmount * GBP_TO_USD;
						}
						else if (toCombo.Equals("EUR - Euro"))
						{
							resultTypeTextBlock.Text = "Euros";
							rate1TextBlock.Text = conversionRateFrom + GBP_TO_EUR.ToString() + " Euros";
							rate2TextBlock.Text = "1 EUR = " + EUR_TO_GBP + " British Pounds";
							return conversionAmount * GBP_TO_EUR;
						}
						else if (toCombo.Equals("INR - Indian Rupee"))
						{
							resultTypeTextBlock.Text = "Indian Rupees";
							rate1TextBlock.Text = conversionRateFrom + GBP_TO_INR.ToString() + " Indian Rupees";
							rate2TextBlock.Text = "1 INR = " + INR_TO_GBP + " British Pounds";
							return conversionAmount * GBP_TO_INR;
						}
						else
						{
							return 0;
						}
					}
				case "EUR - Euro":
					{
						messageAmount += " Euros =";
						displayAmountTextBlock.Text = messageAmount;
						conversionRateFrom = "1 EUR = ";
						if (toCombo.Equals("GBP - British Pound"))
						{
							resultTypeTextBlock.Text = "British Pounds";
							rate1TextBlock.Text = conversionRateFrom + EUR_TO_GBP.ToString() + " British Pounds";
							rate2TextBlock.Text = "1 GBP = " + GBP_TO_EUR + " Euros";
							return conversionAmount * EUR_TO_GBP;
						}
						else if (toCombo.Equals("USD - US Dollar"))
						{
							resultTypeTextBlock.Text = "US Dollars";
							rate1TextBlock.Text = conversionRateFrom + EUR_TO_USD.ToString() + " US Dollars";
							rate2TextBlock.Text = "1 USD = " + USD_TO_EUR + " Euros";
							return conversionAmount * EUR_TO_USD;
						}
						else if (toCombo.Equals("INR - Indian Rupee"))
						{
							resultTypeTextBlock.Text = "Indian Rupees";
							rate1TextBlock.Text = conversionRateFrom + EUR_TO_INR.ToString() + " Indian Rupees";
							rate2TextBlock.Text = "1 INR = " + INR_TO_EUR + " Euros";
							return conversionAmount * EUR_TO_INR;
						}
						else
						{
							return 0;
						}
					}
				case "INR - Indian Rupee":
					{
						messageAmount += " Indian Rupees =";
						displayAmountTextBlock.Text = messageAmount;
						conversionRateFrom = "1 INR = ";
						if (toCombo.Equals("GBP - British Pound"))
						{
							resultTypeTextBlock.Text = "British Pounds";
							rate1TextBlock.Text = conversionRateFrom + INR_TO_GBP.ToString() + " British Pounds";
							rate2TextBlock.Text = "1 GBP = " + GBP_TO_INR + " Indian Rupees";
							return conversionAmount * INR_TO_GBP;
						}
						else if (toCombo.Equals("USD - US Dollar"))
						{
							resultTypeTextBlock.Text = "US Dollars";
							rate1TextBlock.Text = conversionRateFrom + INR_TO_USD.ToString() + " US Dollars";
							rate2TextBlock.Text = "1 USD = " + USD_TO_INR + " Indian Rupees";
							return conversionAmount * INR_TO_USD;
						}
						else if (toCombo.Equals("EUR - Euro"))
						{
							resultTypeTextBlock.Text = "Euros";
							rate1TextBlock.Text = conversionRateFrom + INR_TO_EUR.ToString() + " Euros";
							rate2TextBlock.Text = "1 EUR = " + EUR_TO_INR + " Indian Rupees";
							return conversionAmount * INR_TO_EUR;
						}
						else
						{
							return 0;
						}
					}
				default:
					{
						displayAmountTextBlock.Text = "";
						resultTypeTextBlock.Text = "";
						return 0;
					}
			}
		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainMenu));
		}
	}
}
