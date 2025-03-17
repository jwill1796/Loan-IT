using Loan_IT.Data;
using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace Loan_IT
{
    public partial class MainPage : ContentPage
    {
        private readonly DatabaseService _databaseService;

        public MainPage(DatabaseService databaseService)
        {
            InitializeComponent();
            _databaseService = databaseService;
            LoadUserInfo();
        }

        private async void LoadUserInfo()
        {
            var user = await _databaseService.GetLoggedInUser();
            if (user != null)
            {
                WelcomeLabel.Text = $"Welcome {user.Username}";
            }
        }

        private async void OnUserInfoClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//UserInfoPage");
        }

        private async void OnMortgageInputClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//MortgageInputPage");
        }

        private async void OnMortgagesRecordsClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//MortgageRecordsPage");
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            await _databaseService.LogoutUser();
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
