using Loan_IT.Data;
using Loan_IT.Views;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace Loan_IT
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            ServiceProvider = serviceProvider;
            InitializeDatabase();

            MainPage = new NavigationPage(new LoginPage());
        }

        public void LoadAppShell()
        {
            MainPage = new AppShell();
        }

        private async void InitializeDatabase()
        {
            var databaseService = ServiceProvider.GetService<DatabaseService>();

            if (databaseService != null)
            {
                await databaseService.InitializeAsync();
            }
            else
            {
                throw new System.Exception("DatabaseService is not registered.");
            }
        }
        //protected override Window CreateWindow(IActivationState? activationState)
        //{
        //    return new Window(new AppShell());
        //}
    }
}