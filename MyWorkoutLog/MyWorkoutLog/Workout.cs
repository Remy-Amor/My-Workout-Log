namespace MyWorkoutLog
{
     public class Workout : DescribableObject
     {
          private List<Exercise> _exerciseList;
          private int? _dateCompleted;

          public Workout(string name, string note, List<Exercise> exerciseList, int? dateCompleted) : base(name, note)
          {
               _exerciseList = exerciseList;
               _dateCompleted = dateCompleted;
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

          public int? DateCompleted
          {
               get
               {
                    return _dateCompleted;
               }
               set
               {
                    _dateCompleted = value;
               }
          }
     }
}