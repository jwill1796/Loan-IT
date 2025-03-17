using Loan_IT.ViewModels;
using Loan_IT.Data;
using Microsoft.Maui.Controls;

namespace Loan_IT.Views;
public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
        BindingContext = App.ServiceProvider?.GetService<UserViewModel>() ?? throw new System.Exception("UserViewModel is not registered.");
    }
}