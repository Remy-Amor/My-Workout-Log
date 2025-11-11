namespace MyWorkoutLog
{
     public class Workout : DescribableObject
     {
          private List<Exercise> _exerciseList;

          public Workout(string name, string note, List<Exercise> exerciseList) : base(name, note)
          {
               _exerciseList = exerciseList;
          }

          public Workout(string name, List<Exercise> exercistList) : base(name, "")
          {
               _exerciseList = exercistList;
          }

          public void RemoveExercise(Exercise exercise)
          {
               _exerciseList.Remove(exercise);
          }

          public void AddExercise(Exercise exercise)
          {
               _exerciseList.Add(exercise);
          }

          // properties
          public List<Exercise> ExerciseList
          {
               get
               {
                    return _exerciseList;
               }
          }

     }
}