using MyWorkoutLog.Core;
using MyWorkoutLog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyWorkoutLog.MVVM.ViewModels
{
    public class SignInViewModel : ViewModel
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public RelayCommand SignInCommand { get; set; }

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
        public RelayCommand NavigateHomeCommand { get; set; }

        public SignInViewModel(INavigationService navService)
        {
            Navigation = navService;
            NavigateHomeCommand = new RelayCommand(execute: o => { Navigation.NavigateTo<HomeViewModel>(); }, canExecute: o => true);

            SignInCommand = new RelayCommand(execute: o => { SignIn(); }, canExecute: o => true);

        }

        private void SignIn()
        {
            foreach (RegisteredUser user in SessionData.RegisteredUsers)
            {
                if (user.Username == Username && user.Password == Password)
                {
                    SessionData.CurrentUser = user;
                    Navigation.NavigateTo<HomeViewModel>();
                    return;
                }
            }
            MessageBox.Show("Incorrect Username or Password. Please try again");
        }
    }
}
