using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Loan_IT.Models
{
    public class UserInfo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int UserId { get; set; }
        public double MonthlyIncome { get; set; }
        public double TotalMonthlyDebt { get; set; }
        public string EmploymentStatus { get; set; }
        public string MaritalStatus { get; set; }
        public int CreditScore { get; set; }
    }
}
