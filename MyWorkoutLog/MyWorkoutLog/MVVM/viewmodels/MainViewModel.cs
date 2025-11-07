using MyWorkoutLog.Core;
using MyWorkoutLog.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWorkoutLog.MVVM.ViewModels;
     public class MainviewModel : ViewModel
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
        public RelayCommand NavigateExercisesCommand { get; set; }
        public RelayCommand NavigateHistoryCommand { get; set; }
        public RelayCommand NavigateTemplatesCommand { get; set; }



    // constructor. Passes in navigationService as set up through dependency injection
    public MainviewModel(INavigationService navService)
            {
                Navigation = navService;
            // takes the action (execute) and the predicate (canExecute). they are delegates, so stored as the methods, not their results   
                NavigateAccountCommand = new RelayCommand(execute: o => { Navigation.NavigateTo<AccountViewModel>(); }, canExecute: o => true);
                NavigateExercisesCommand = new RelayCommand(execute: o => { Navigation.NavigateTo<ExercisesViewModel>(); }, canExecute: o => true);
                NavigateHistoryCommand = new RelayCommand(execute: o => { Navigation.NavigateTo<HistoryViewModel>(); }, canExecute: o => true);
                NavigateTemplatesCommand = new RelayCommand(execute: o => { Navigation.NavigateTo<TemplatesViewModel>(); }, canExecute: o => true);

    }
}
