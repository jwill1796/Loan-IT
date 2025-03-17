using Loan_IT.Data;
using Loan_IT.Models;
using Microsoft.Maui.Controls;
using System;

namespace Loan_IT.Views
{


    public partial class MortgageInputPage : ContentPage
    {
        private readonly DatabaseService _databaseService;
        public MortgageInputPage(DatabaseService database)
        {
            InitializeComponent();
            _databaseService = database;
        }

        private async void OnSaveMortgageClicked(object sender, EventArgs e)
        {
            var user = await _databaseService.GetLoggedInUser();
            if (user == null) return;

            double loanAmount = double.Parse(CostOfHomeEntry.Text);
            double monthlyRate = (double.Parse(InterestRateEntry.Text) / 100) / 12;
            int totalPayments = int.Parse(LoanTermEntry.Text) * 12;
            double monthlyPayment = (loanAmount * monthlyRate) / (1 - Math.Pow(1 + monthlyRate, -totalPayments));

            var mortgage = new MortgageDetails
            {
                UserId = user.Id,
                CostOfHome = double.Parse(CostOfHomeEntry.Text),
                DownPayment = double.Parse(DownPaymentEntry.Text),
                InterestRate = double.Parse(InterestRateEntry.Text),
                Term = int.Parse(LoanTermEntry.Text),
                PropertyTax = double.Parse(PropertyTaxEntry.Text),
                HomeOwnersInsurance = double.Parse(HomeInsuranceEntry.Text),
                HoaFees = double.Parse(HoaFeesEntry.Text),
                MonthlyPayment = monthlyPayment
            };

            await _databaseService.SaveMortgageDetails(mortgage);
            await DisplayAlert("Success", $"Mortgage Saved! Monthly Payment: ${monthlyPayment:F2}", "OK");

            await Shell.Current.GoToAsync("//ApprovalResultPage");
        }
    }
}