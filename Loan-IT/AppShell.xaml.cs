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
            CurrentItem = new ShellContent { Content = new LoginPage() };
        }
    }
}
