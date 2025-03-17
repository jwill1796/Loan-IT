using Loan_IT.ViewModels;
using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace Loan_IT.Views
{

	public partial class ApprovalResultPage : ContentPage
	{
		private readonly ApprovalViewModel _viewModel;
		public ApprovalResultPage(ApprovalViewModel viewModel)
		{
			InitializeComponent();
            _viewModel = viewModel;
			BindingContext = _viewModel;
			_ = LoadApprovalResultAsync();
        }
		private async Task LoadApprovalResultAsync()
		{
			await _viewModel.EvaluateApproval();
		}

		private async void OnBackToHomeClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//MainPage");
        }
    }
}