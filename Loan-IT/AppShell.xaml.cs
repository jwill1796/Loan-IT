using Loan_IT.Views;
using Microsoft.Maui.Controls;

namespace Loan_IT
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(ApprovalResultPage), typeof(ApprovalResultPage));

            // Starting the application on the LoginPage
            //CurrentItem = new ShellContent { Content = new LoginPage() };

            Navigated += OnNavigated;
        }

        private void OnNavigated(object sender, ShellNavigatedEventArgs e)
        {
           if (e.Current.Location.OriginalString.Contains("LoginPage") || e.Current.Location.OriginalString.Contains("RegisterPage"))
            {
                Shell.SetNavBarIsVisible(this, false);
            }
            else
            {
                Shell.SetNavBarIsVisible(this, true);
            }
        }
    }
}
