using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Loan_IT.Models
{
    public class MortgageDetails
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int UserId { get; set; }
        public double CostOfHome { get; set; }
        public double DownPayment { get; set; }
        public double InterestRate { get; set; }
        public int Term { get; set; }
        public double MarketValue { get; set; }
        public double PropertyTax { get; set; }
        public double HomeOwnersInsurance { get; set; }
        public double HoaFees { get; set; }
        public double LoanInsurance { get; set; }
        public double MonthlyPayment { get; set; }
    }
}
