namespace MyWorkoutLog
{
     public abstract class BaseUser : IUsers
     {
          private Dictionary<Workout, DateOnly> _workoutHistory;
          private string _username;
          private string _password;
          private bool _accountPermissions;
          public BaseUser(string name, string password)
          {
               _username = name;
               _password = password;
               _workoutHistory = new Dictionary<Workout, DateOnly>();
               _accountPermissions = false;
          }

          public virtual void ClearData()
          {
               _workoutHistory.Clear();
          }

          public void AddWorkout(Workout workout)
          {
               _workoutHistory.Add(workout, DateOnly.FromDateTime(DateTime.Now));
          }

          // Properties
          public Dictionary<Workout, DateOnly> WorkoutHistory
          {
               get
               {
                    return _workoutHistory;
               }
          }

          public string Username
          {
               get
               {
                    return _username;
               }
          }

          public string Password
          {
               get
               {
                    return _password;
               }
          }

          public bool AccountPermissions
          {
               get
               {
                    return _accountPermissions;
               }
               set
               {
                    _accountPermissions = value;
               }
          }

          
     }
}