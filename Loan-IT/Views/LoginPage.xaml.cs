using Loan_IT.ViewModels;
using Microsoft.Maui.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace Loan_IT.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		BindingContext = App.ServiceProvider?.GetService<UserViewModel>() ?? throw new System.Exception("UserViewModel is not registered.");
    }

	private async void OnRegisterClicked(object sender, System.EventArgs e)
	{
		if (Shell.Current != null)
		{
			await Shell.Current.GoToAsync("//RegisterPage");
		}
		else
		{
			await DisplayAlert("Navigation Error", "Shell.Current is null", "OK");
		}

	}
}