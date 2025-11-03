namespace MyWorkoutLog
{
     public abstract class BaseUser : IUsers
     {
          private Dictionary<Workout, DateOnly> _workoutHistory;
          private string _username;
          private string _password;
          private bool _accountPermissions;
          private Workout? _currentWorkout;
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
               _currentWorkout = null;
          }

          public void StartWorkout(Workout workout)
          {
               _currentWorkout = workout;
          }
          public void FinishWorkout()
          {
               _workoutHistory.Add(_currentWorkout, DateOnly.FromDateTime(DateTime.Now));
               _currentWorkout = null;
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

          public Workout? CurrentWorkout
          {
               get
               {
                    return _currentWorkout;
               }
          }
     }
}