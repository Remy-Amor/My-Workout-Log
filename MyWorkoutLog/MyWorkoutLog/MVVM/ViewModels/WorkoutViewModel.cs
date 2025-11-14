using MyWorkoutLog;
using MyWorkoutLog.Core;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Data;
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
            RemoveExerciseCommand = new RelayCommand(execute: o => RemoveExercise(o), canExecute: o => true);
            CompleteWorkoutCommand = new RelayCommand(execute: o => CompleteWorkout(), canExecute: o => Exercises.Count > 0);

           

        }

        private void AddExercise()
        {
            Exercises.Add(new Exercise("", EquipmentType.cablemachine));
        }

        private void RemoveExercise(object o)
        {

            System.Diagnostics.Debug.WriteLine("RemoveExercise called. param: " + (o?.GetType().FullName ?? "null"));
            if (o is not Exercise exercise) { System.Diagnostics.Debug.WriteLine("param not Exercise"); return; }
            System.Diagnostics.Debug.WriteLine($"Removing {exercise.Name}. Count before: {Exercises.Count}");
            Exercises.Remove(exercise);
            System.Diagnostics.Debug.WriteLine($"Count after: {Exercises.Count}");
        }

        private void CompleteWorkout()
        {
            // stop if any empty exercises
            for (int i = 0; i < Exercises.Count; i++)
            {
                Exercise exercise = Exercises[i];
                if (exercise.Name == "" || exercise.Reps == 0)
                {
                    MessageBox.Show($"Please fill out all required fields for exercise {i + 1} before completing the workout.");
                    return;
                }
                else if (exercise.Weight < 0)

                {
                    MessageBox.Show($"Weight cannot be negative for exercise {i + 1}. Please correct the weight value before completing the workout.");
                    return;
                }
            }
                    Workout workout = new Workout(WorkoutName, Notes, Exercises.ToList());
                    SessionData.CurrentUser.AddWorkout(workout);
                    Exercises.Clear();
                    WorkoutName = "";
                    Notes = "";
                    OnPropertyChanged(nameof(WorkoutName));
                    OnPropertyChanged(nameof(Notes));
             
        }
    }



    // for converting between int and string in bindings
    public class IntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.ToString() ?? "";
        }

        public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var str = value as string;

            if (int.TryParse(str, out int num))
                return num;

            return null; // Prevents exceptions
        }
    }
}
