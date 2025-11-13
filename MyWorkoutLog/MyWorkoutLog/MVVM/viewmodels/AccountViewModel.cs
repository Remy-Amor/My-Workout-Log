using MyWorkoutLog.Core;
using MyWorkoutLog.Services;
using System.Windows;
using System.Windows.Controls;

namespace MyWorkoutLog.MVVM.ViewModels
{

    public class AccountViewModel : ViewModel
    {

        private bool _signInButtonVisibility = false;

        public Visibility SignInVisibility
        {
            get { return _signInButtonVisibility ? Visibility.Visible : Visibility.Collapsed; }
        }
        private string? _currentUsername;
        public string? CurrentUsername
        {
            get { return _currentUsername; }
            set
            {
                _currentUsername = value;
                OnPropertyChanged();

            }
        }

        // navigation service for navigating between viewmodels
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

        public RelayCommand NavigateSignInCommand { get; set; }
        public RelayCommand NavigateRegisterCommand { get; set; }

        public AccountViewModel(INavigationService navService)
        {
            Navigation = navService;
            LoadFromSession();

            // subscribe to SessionData changes so viewmodel updates
            SessionData.CurrentUserChanged += OnCurrentUserChanged;

            ClearDataCommand = new RelayCommand(execute: o => ClearData(), canExecute: o => true);

            NavigateRegisterCommand = new RelayCommand(execute: o => { Navigation.NavigateTo<RegisterViewModel>(); }, canExecute: o => true);
            NavigateSignInCommand = new RelayCommand(execute: o => { Navigation.NavigateTo<SignInViewModel>(); }, canExecute: o => true);

        }

        private void LoadFromSession()
        {
            // Initialize CurrentUsername from SessionData
            if (SessionData.CurrentUser != null)
            {
                CurrentUsername = SessionData.CurrentUser.Username;
            }
            else
            {
                CurrentUsername = "None";
            }
        }

        private void OnCurrentUserChanged()
        {
            LoadFromSession();
            if (CurrentUsername != "Guest")
            {
                _signInButtonVisibility = true;
            }
        }

        // Commands
        public RelayCommand ClearDataCommand { get; set; }


        public void ClearData()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to clear all workout data for the current user?", "Confirm Clear Data", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                SessionData.CurrentUser.ClearData();
            }
        }
    }
}