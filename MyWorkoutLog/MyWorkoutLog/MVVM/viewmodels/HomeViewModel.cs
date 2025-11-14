using MyWorkoutLog;
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
    public class HomeViewModel : ViewModel
    {
        private string? _currentUsername;

        public Visibility ViewTemplatesVisibility {
            get
            {
                if (SessionData.CurrentUser != null && SessionData.CurrentUser.AccountPermissions)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
        }
        public string? CurrentUsername
        {
            get { return _currentUsername; }
            set
            {
                _currentUsername = value;
                OnPropertyChanged();
            }
        }

        public HomeViewModel()
        {
            LoadFromSession();

            // subscribe to SessionData changes so viewmodel updates
            SessionData.CurrentUserChanged += OnCurrentUserChanged;

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
        }

        

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
        public RelayCommand NavigateExercisesCommand { get; set; }
        public RelayCommand NavigateHistoryCommand { get; set; }
        public RelayCommand NavigateTemplatesCommand { get; set; }
        public RelayCommand NavigateMainCommand { get; set; }
        public RelayCommand NavigateHomeCommand { get; set; }
        public RelayCommand NavigateWorkoutCommand { get; set; }




        // constructor. Passes in navigationService as set up through dependency injection
        public HomeViewModel(INavigationService navService)
        {
            Navigation = navService;
            // takes the action (execute) and the predicate (canExecute). they are delegates, so stored as the methods, not their results   
            NavigateAccountCommand = new RelayCommand(execute: o => { Navigation.NavigateTo<AccountViewModel>(); }, canExecute: o => true);
            NavigateHistoryCommand = new RelayCommand(execute: o => { Navigation.NavigateTo<HistoryViewModel>(); }, canExecute: o => true);
            NavigateTemplatesCommand = new RelayCommand(execute: o => { Navigation.NavigateTo<TemplatesViewModel>(); }, canExecute: o => true);
            NavigateMainCommand = new RelayCommand(execute: o => { Navigation.NavigateTo<MainViewModel>(); }, canExecute: o => true);
            NavigateHomeCommand = new RelayCommand(execute: o => { Navigation.NavigateTo<HomeViewModel>(); }, canExecute: o => true);
            NavigateWorkoutCommand = new RelayCommand(execute: o => { Navigation.NavigateTo<WorkoutViewModel>(); }, canExecute: o => true);
        }
    }
}
