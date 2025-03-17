using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loan_IT.Models;

namespace Loan_IT.Services
{
    public class ApprovalService
    {
        public static string EvaluateMortgage(UserInfo userinfo, MortgageDetails mortgage)
        {
            double dti = (userinfo.TotalMonthlyDebt / userinfo.MonthlyIncome) * 100;
            bool dtiPass = dti < 43;

            bool creditPass = userinfo.CreditScore >= 620;

            double ltv = (mortgage.CostOfHome - mortgage.DownPayment) / mortgage.CostOfHome * 100;
            bool ltvPass = ltv <= 90;

            double downPaymentPercent = (mortgage.DownPayment / mortgage.CostOfHome) * 100;
            bool downPaymentPass = downPaymentPercent >= 3.5;

            if (dtiPass && creditPass && ltvPass && downPaymentPass)
            {
                return "Approved ✅\nYour financial profile meets mortgage requirements!";
            }
            else
            {
                string reason = "Denied ❌\nReasons:\n";

                if (!dtiPass) reason += "- High Debt-to-Income Ratio (>43%)\n";
                if (!creditPass) reason += "- Low Credit Score (<620)\n";
                if (!ltvPass) reason += "- High Loan-to-Value Ratio (>90%)\n";
                if (!downPaymentPass) reason += "- Low Down Payment (<3.5%)\n";

                return reason;
            }
        }
    }
}
