using Loan_IT.ViewModels;
using Loan_IT.Data;
using Microsoft.Maui.Controls;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using BCrypt.Net;

namespace Loan_IT.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
	{
		InitializeComponent();
		BindingContext = App.ServiceProvider?.GetService<UserViewModel>() ?? throw new System.Exception("UserViewModel is not registered.");
    }
}