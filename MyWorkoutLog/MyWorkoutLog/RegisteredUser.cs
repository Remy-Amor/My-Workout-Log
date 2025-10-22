namespace MyWorkoutLog
{
     public class RegisteredUser : BaseUser
     {
          private List<Workout> _workoutTemplates = new List<Workout>();
          private List<Exercise> _createdExercises = new List<Exercise>();
          public RegisteredUser(string name, string password) : base(name, password)
          {
               _accountPermissions = true;
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
          public List<Workout> WorkoutTemplates
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