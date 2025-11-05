namespace MyWorkoutLog {
     public interface IUsers
     {
          bool AccountPermissions { get; }
          string Username { get; }

          Workout CurrentWorkout { get;}
          Dictionary<Workout, DateOnly> WorkoutHistory { get; }
          void ClearData();

          // StartWorkout will _currentWorkout to the inputted Workout
          void StartWorkout(Workout workout);
          // meant to save to workout history then clear _currentWorkout
          void FinishWorkout();
     }
}