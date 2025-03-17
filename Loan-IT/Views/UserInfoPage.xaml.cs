using Loan_IT.Data;
using Loan_IT.Models;
using Microsoft.Maui.Controls;
using System;

namespace Loan_IT.Views
{
    public partial class UserInfoPage : ContentPage
    {
        private readonly DatabaseService _databaseService;

        public UserInfoPage(DatabaseService databaseService)
        {
            InitializeComponent();
            _databaseService = databaseService;
            LoadUserInfo();
        }

        private async void LoadUserInfo()
        {
            var user = await _databaseService.GetLoggedInUser();
            if (user == null) return;

            var userInfo = await _databaseService.GetUserInfo(user.Id);
            if (userInfo != null)
            {
                IncomeEntry.Text = userInfo.MonthlyIncome.ToString();
                DebtEntry.Text = userInfo.TotalMonthlyDebt.ToString();
                CreditScoreEntry.Text = userInfo.CreditScore.ToString();
                EmploymentPicker.SelectedItem = userInfo.EmploymentStatus;
                MaritalPicker.SelectedItem = userInfo.MaritalStatus;
            }
        }

        private async void OnSaveUserInfoClicked(object sender, EventArgs e)
        {
            var user = await _databaseService.GetLoggedInUser();
            if (user == null) return;

            var userInfo = new UserInfo
            {
                UserId = user.Id,
                MonthlyIncome = double.Parse(IncomeEntry.Text),
                TotalMonthlyDebt = double.Parse(DebtEntry.Text),
                EmploymentStatus = EmploymentPicker.SelectedItem?.ToString(),
                MaritalStatus = MaritalPicker.SelectedItem?.ToString(),
                CreditScore = int.Parse(CreditScoreEntry.Text)
            };

            await _databaseService.SaveUserInfo(userInfo);
            await DisplayAlert("Success", "User Info Saved", "OK");
        }
    }
}



