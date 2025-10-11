namespace MyWorkoutLog
{
     public abstract class BaseUser : IUsers
     {
          private Dictionary<Workout, int> _workoutHistory;
          private string _username;
          private string _password;
          private bool _accountPermissions;
          private Workout? _currentWorkout;
          public BaseUser(string name, string password)
          {
               _username = name;
               _password = password;
               _workoutHistory = new Dictionary<Workout, int>();
          }

          public virtual void ClearData()
          {
               _workoutHistory.Clear();
               _currentWorkout.Clear();
          }

          public void StartWorkout(Workout workout)
          {
               _currentWorkout = workout;
          }
          public void FinishWorkout()
          {
               _workoutHistory.Add(_currentWorkout, DateTime.Today.ToString);
               _currentWorkout = null;
          }
     }
}