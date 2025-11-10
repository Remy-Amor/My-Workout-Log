using MyWorkoutLog;
using MyWorkoutLog.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyWorkoutLog.MVVM.ViewModels
{
    public class WorkoutViewModel : ViewModel
    {
        public string WorkoutName { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;

        public ObservableCollection<Exercise> Exercises { get; set; } = new();

        public string[] WeightUnits { get; } = Enum.GetNames(typeof(WeightUnit));
        public string[] EquipmentTypes { get; } = Enum.GetNames(typeof(EquipmentType));

        public RelayCommand AddExerciseCommand { get; set; }
        public RelayCommand RemoveExerciseCommand { get; set; }
        public RelayCommand CompleteWorkoutCommand { get; set; }


        public WorkoutViewModel()
        {
            AddExerciseCommand = new RelayCommand(execute: o => AddExercise(), canExecute: o => true);
            RemoveExerciseCommand = new RelayCommand(execute: o => Exercises.Remove(o as Exercise), canExecute: o => o is Exercise);
            CompleteWorkoutCommand = new RelayCommand(execute: o => CompleteWorkout(), canExecute: o => Exercises.Count > 0);
        }

        private void AddExercise()
        {
            Exercises.Add(new Exercise("", EquipmentType.cablemachine));
        }

        private void CompleteWorkout()
        {
            Workout workout = new Workout(WorkoutName, Notes, Exercises.ToList());
            SessionData.CurrentUser.AddWorkout(workout);
            Exercises.Clear();
            WorkoutName = string.Empty;
            Notes = string.Empty;
        }
    }
}
