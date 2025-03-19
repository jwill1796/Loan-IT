using Loan_IT.Models;
using Loan_IT.ViewModels;
using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace Loan_IT.Views;
public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
        BindingContext = App.ServiceProvider?.GetService<UserViewModel>() ?? throw new System.Exception("UserViewModel is not registered.");
    }

}