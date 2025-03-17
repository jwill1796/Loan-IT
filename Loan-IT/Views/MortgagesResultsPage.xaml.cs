using Loan_IT.Data;
using Loan_IT.Models;
using Microsoft.Maui.Controls;
using System;

namespace Loan_IT.Views
{

    public partial class MortgagesResultsPage : ContentPage
    {
        private readonly DatabaseService _databaseService;
        public MortgagesResultsPage(DatabaseService databaseService)
        {
            InitializeComponent();
            _databaseService = databaseService;
        }
    }
}