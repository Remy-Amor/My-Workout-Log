using MyWorkoutLog.Core;
using MyWorkoutLog.Services;
using System.Collections.ObjectModel;
using MyWorkoutLog;

namespace MyWorkoutLog.MVVM.ViewModels
{

    public class TemplatesViewModel : ViewModel
    {
        private WorkoutViewModel _workoutViewModel;


        // commands to start workout from template
        public RelayCommand StartWorkoutFromTemplate { get ; set; }

        // navigation set up
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

        public RelayCommand NavigateWorkoutCommand { get; set; }

        public TemplatesViewModel(INavigationService navService, WorkoutViewModel WorkoutVM)
        {   
            _workoutViewModel = WorkoutVM;
            Navigation = navService;
            NavigateWorkoutCommand = new RelayCommand(execute: o => Navigation.NavigateTo<WorkoutViewModel>(), canExecute: o => true);

            StartWorkoutFromTemplate = new RelayCommand(execute: o => StartWorkout((Workout)o), canExecute: o => o is Workout);
        }
        public ObservableCollection<Workout>? Templates
        {
            get
            {
                if (SessionData.CurrentUser is RegisteredUser registered)
                {
                    return registered.WorkoutTemplates;
                }
                else
                {
                    return null; 
                }
            }
        }

        public void StartWorkout(Workout workout)
        {
            _workoutViewModel.WorkoutName = workout.Name;
            _workoutViewModel.Notes = workout.Note;
            _workoutViewModel.Exercises = new ObservableCollection<Exercise>(workout.ExerciseList);
            Navigation.NavigateTo<WorkoutViewModel>();
        }

    }
}