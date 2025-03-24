using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Loan_IT.Data;
using Loan_IT.Views;
using Loan_IT.ViewModels;
using System.IO;

namespace Loan_IT
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "loanit.db");
            builder.Services.AddSingleton(new DatabaseService(dbPath));
            builder.Services.AddSingleton<LoginPage>(); 
            builder.Services.AddSingleton<RegisterPage>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<ApprovalViewModel>();
            builder.Services.AddSingleton<UserViewModel>(); 

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}