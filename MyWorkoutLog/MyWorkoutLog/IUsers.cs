namespace MyWorkoutLog {
     public interface IUsers
     {
          bool AccountPermissions { get; }
          string Username { get; }

          Dictionary<Workout, DateOnly> WorkoutHistory { get; }
          void ClearData();

          // StartWorkout will _currentWorkout to the inputted Workout
          void AddWorkout(Workout workout);
     }
}