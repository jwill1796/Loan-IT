using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan_IT_Hybrid.Services
{
    public class SessionService
    {
        public bool IsLoggedIn { get; private set; } = false;
        public string LoggedInEmail { get; private set; } = string.Empty;

        public event Action? OnChange;

        public void Login(string email)
        {
            IsLoggedIn = true;
            LoggedInEmail = email;
            NotifyStateChanged();
        }

        public void Logout()
        {
            IsLoggedIn = false;
            LoggedInEmail = string.Empty;
            NotifyStateChanged();
        }
        public void NotifyStateChanged() => OnChange?.Invoke();
    }
}
