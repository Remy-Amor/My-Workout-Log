using MyWorkoutLog.Core;
using MyWorkoutLog.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWorkoutLog.MVVM.ViewModels;
     public class MainViewModel : ViewModel
     {
        private INavigationService _navigation;
        public INavigationService Navigation { 
            get { return _navigation; }
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
            }

        public RelayCommand NavigateAccountCommand { get; set; }
        public RelayCommand NavigateHistoryCommand { get; set; }
        public RelayCommand NavigateTemplatesCommand { get; set; }
        public RelayCommand NavigateMainCommand { get; set; }
        public RelayCommand NavigateHomeCommand { get; set; }




    // constructor. Passes in navigationService as set up through dependency injection
    public MainViewModel(INavigationService navService)
    {
        Navigation = navService;
        // takes the action (execute) and the predicate (canExecute). they are delegates, so stored as the methods, not their results   
        NavigateAccountCommand = new RelayCommand(execute: o => { Navigation.NavigateTo<AccountViewModel>(); }, canExecute: o => true);
        NavigateHistoryCommand = new RelayCommand(execute: o => { Navigation.NavigateTo<HistoryViewModel>(); }, canExecute: o => true);
        NavigateTemplatesCommand = new RelayCommand(execute: o => { Navigation.NavigateTo<TemplatesViewModel>(); }, canExecute: o => true);
        NavigateMainCommand = new RelayCommand(execute: o => { Navigation.NavigateTo<MainViewModel>(); }, canExecute: o => true);
        NavigateHomeCommand = new RelayCommand(execute: o => { Navigation.NavigateTo<HomeViewModel>(); }, canExecute: o => true);

        Navigation.NavigateTo<HomeViewModel>();

    }

    

   
}
