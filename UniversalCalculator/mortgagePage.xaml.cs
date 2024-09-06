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
	public sealed partial class mortgagePage : Page
	{
		public mortgagePage()
		{
			this.InitializeComponent();
		}

		private async void Calculate_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				// retrieve input values
				double principal = double.Parse(txtPrincipal.Text);
				int years = int.Parse(txtYears.Text);
				int months = int.Parse(txtMonths.Text);
				double yearlyInterestRate = double.Parse(txtInterestRate.Text) / 100;

				// calculate the monthly interest rate
				double monthlyInterestRate = yearlyInterestRate / 12;
				txtMonthlyInterestRate.Text = monthlyInterestRate.ToString("F4") + "%";

				// calculate the total number of months
				int totalMonths = years * 12 + months;

				// calculate monthly repayment using the formula:
				// M = P [ i(1 + i)^n ] / [ (1 + i)^n – 1]
				double numerator = monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, totalMonths);
				double denominator = Math.Pow(1 + monthlyInterestRate, totalMonths) - 1;
				double monthlyRepayment = principal * (numerator / denominator);

				// display the monthly repayment
				txtMonthlyRepayment.Text = monthlyRepayment.ToString("C2");
			}
			catch (Exception ex)
			{
				ContentDialog dialog = new ContentDialog
				{
					Title = "Error",
					Content = ex.Message,
					CloseButtonText = "OK"
				};

				await dialog.ShowAsync();
			}
		}

		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Exit();
		}
	}
}
