using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Loan_IT.Data;
using Loan_IT.Models;
using Loan_IT.Views;
using Microsoft.Maui.Controls;
using BCrypt.Net;

namespace Loan_IT.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseService _databaseService;

        public ICommand RegisterUserCommand { get; }
        public ICommand LoginUserCommand { get; }
        public ICommand NavigateToRegisterCommand { get; }
        public UserViewModel()
        {
            _databaseService = App.ServiceProvider?.GetService<DatabaseService>();
            RegisterUserCommand = new Command(async () => await RegisterUser());
            LoginUserCommand = new Command(async () => await LoginUser());
            NavigateToRegisterCommand = new Command(async () =>
            {
                if (Application.Current.MainPage is NavigationPage navPage)
                {
                    await navPage.PushAsync(new RegisterPage());
                }
            });
        }

        public UserViewModel(DatabaseService databaseService)
        {
            _databaseService = databaseService;
            RegisterUserCommand = new Command(async () => await RegisterUser());
            LoginUserCommand = new Command(async () => await LoginUser());
            NavigateToRegisterCommand = new Command(async () =>
            {
                if (Application.Current.MainPage is NavigationPage navPage)
                {
                    await navPage.PushAsync(new RegisterPage());
                }
            });
        }

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        private string _registrationMessage;
        public string RegistrationMessage
        {
            get => _registrationMessage;
            set
            {
                _registrationMessage = value;
                OnPropertyChanged();
            }
        }
        
        private string _loginMessage;
        public string LoginMessage
        { 
            get => _loginMessage;
            set { _loginMessage = value; OnPropertyChanged(); }
        }

        public async Task LoginUser()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                LoginMessage = "Please enter all fields.";
                return;
            }

            var user = await _databaseService.GetUserByUsername(Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(Password, user.PasswordHash))
            {
                LoginMessage = "Invalid username or password.";
                return;
            }

            LoginMessage = "Login Succesful";
            ((App)Application.Current).LoadAppShell();

        }


        public async Task<bool> RegisterUser()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                RegistrationMessage = "Please enter all fields.";
                return false;
            }
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(Password);

            var user = new Users
            {
                Username = _username,
                Email = _email,
                PasswordHash = hashedPassword
            };

            int result = await _databaseService.RegisterUser(user);
            if (result > 0)
            {
                RegistrationMessage = "User registered successfully.";
                if (Application.Current.MainPage is NavigationPage navPage)
                {
                    await navPage.PopAsync();
                }
                return true;
            }
            else
            {
                RegistrationMessage = "User registration failed.";
                return false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
