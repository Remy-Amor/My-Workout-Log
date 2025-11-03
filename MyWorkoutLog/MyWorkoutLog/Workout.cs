namespace MyWorkoutLog
{
     public class Workout : DescribableObject
     {
          private List<Exercise> _exerciseList;
          private DateOnly? _dateCompleted;

          public Workout(string name, string note, List<Exercise> exerciseList, DateOnly? dateCompleted) : base(name, note)
          {
               _exerciseList = exerciseList;
               _dateCompleted = dateCompleted;
          }

          public Workout(string name, List<Exercise> exercistList, DateOnly dateCompleted) : base(name, "")
          {
               _exerciseList = exercistList;
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

          public string DateCompleted
          {
               get
               {
                    return _dateCompleted.ToString();
               }
               set
               {
                    _dateCompleted = DateOnly.Parse(value);
               }
          }
     }
}