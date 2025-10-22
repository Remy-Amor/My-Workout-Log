namespace MyWorkoutLog
{
     public class Exercise : DescribableObject
     {
          private int _reps;
          private float _weight;
          private string _weightUnit;
          private string _equipment;

          public Exercise(string name, string note, int reps, float weight, string weightunits, string equipment) : base(name, note)
          {
               _reps = reps;
               _weight = weight;
               _weightunits = weightunits;
               _equipment = equipment;
          }

          public Exercise(string name, string note, string equipment) : base(name, note)
          {
               _equipment = equipment;
          }

          public Exercise(string name, string equipment) : base(name, "")
          {
               _equipment = equipment;
          }

          // properties

          public int Reps
          {
               get
               {
                    return _reps;
               }
          }

          public float Weight
          {
               get
               {
                    return _weight;
               }
          }

          public string WeightUnit
          {
               get
               {
                    return _weightUnit;
               }
          }

          public string Equipment
          {
               get
               {
                    return _equipment;
               }
          }
     }
}