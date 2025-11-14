using System.Collections.ObjectModel;
using System.Windows;
using MyWorkoutLog.Core;


namespace MyWorkoutLog
{
     public class RegisteredUser : BaseUser
     {
          private ObservableCollection<Workout> _workoutTemplates = new();
          private List<Exercise> _createdExercises = new List<Exercise>();
          public RegisteredUser(string name, string password) : base(name, password)
          {
               AccountPermissions = true;
          }

          public void SaveAsTemplate(Workout workout)
          {
               _workoutTemplates.Add(workout);
           
          }

          public void RemoveTemplate(Workout workout)
          {
               _workoutTemplates.Remove(workout);
          }

          public void AddExercise(Exercise exercise)
          {
               _createdExercises.Add(exercise);
          }
          public void RemoveExercise(Exercise exercise)
          {
               _createdExercises.Remove(exercise);
          }

          public override void ClearData()
          {
               base.ClearData();
               _workoutTemplates.Clear();
               _createdExercises.Clear();
          }

          // properties
          public ObservableCollection<Workout> WorkoutTemplates
          {
               get
               {
                    return _workoutTemplates;
               }
          }

          public List<Exercise> CreatedExercises
          {
               get
               {
                    return _createdExercises;
               }
          }
     }
}