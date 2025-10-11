namespace MyWorkoutLog {
     public interface IUsers
     {
          bool AccountPermissions();
          string Username { get; set; }
          List<Workout> WorkoutHistory { get; set; }
          void ClearData();
          void StartWorkout(Workout workout);
          
     }
}