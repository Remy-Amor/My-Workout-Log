using MyWorkoutLog.Core;
using MyWorkoutLog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWorkoutLog.MVVM.ViewModels
{
    class RegisterViewModel : ViewModel
    {

        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public RelayCommand RegisterUserCommand { get; set; }

        // For Navigate commands
        private INavigationService _navigation;
        public INavigationService Navigation
        {
            get { return _navigation; }
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand NavigateAccountCommand { get; set; }

        public RegisterViewModel(INavigationService navService)
        {
            NavigateAccountCommand = new RelayCommand(execute: o => { navService.NavigateTo<AccountViewModel>(); }, canExecute: o => true);

            RegisterUserCommand = new RelayCommand(execute: o => { RegisterUser(); }, canExecute: o => true);

        }

        private void RegisterUser()
        {
            RegisteredUser user = new(Username, Password);
            SessionData.AddUser(user);
            SessionData.CurrentUser = user;
            Username = string.Empty;
            Password = string.Empty;
            Navigation.NavigateTo<AccountViewModel>();
        }
    }
}
