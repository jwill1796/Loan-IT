using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loan_IT.Data;
using Loan_IT.Models;
using Loan_IT.Services;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Loan_IT.ViewModels
{
    public class ApprovalViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseService _databaseService;
        public string ApprovalResult { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ApprovalViewModel()
        {
            _databaseService = App.ServiceProvider?.GetService<DatabaseService>();
        }
        public ApprovalViewModel(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task EvaluateApproval()
        {
            var user = await _databaseService.GetLoggedInUser();
            if (user == null)
            {
                ApprovalResult = "Error: No user found!";
                OnPropertyChanged(nameof(ApprovalResult));
                return;
            }

            var userInfo = await _databaseService.GetUserInfo(user.Id);
            var mortgage = await _databaseService.GetLatestMortgage(user.Id);

            if (userInfo == null || mortgage == null)
            {
                ApprovalResult = "Error: No user info or mortgage found!";
            }
            else
            {
                ApprovalResult = ApprovalService.EvaluateMortgage(userInfo, mortgage);
            }

            OnPropertyChanged(nameof(ApprovalResult));
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
