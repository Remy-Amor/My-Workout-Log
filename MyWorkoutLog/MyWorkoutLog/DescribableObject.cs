namespace MyWorkoutLog
{
     public abstract class DescribableObject
     {
          private string _name;
          private string _note;

          public DescribableObject(string name, string note)
          {
               _name = name;
               _note = note;
          }
          
          public string Name
          {
               get
               {
                    return _name;
               }
               set
               {
                    _name = value;
               }
          }

          public string Note
          {
               get
               {
                    return _note;
               }
               set
               {
                    _note = value;
               }
          }
     }
}