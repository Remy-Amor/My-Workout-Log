using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace MyWorkoutLog
{
     public class Exercise : DescribableObject, INotifyPropertyChanged
    {
          private int _reps;
          private float _weight;
          private WeightUnit _weightUnit;
          private EquipmentType _equipment;

          public Exercise(string name, string note, int reps, float weight, WeightUnit weightunits, EquipmentType equipment) : base(name, note)
          {
               _reps = reps;
               _weight = weight;
               _weightUnit = weightunits;
               _equipment = equipment;
          }

          public Exercise(string name, string note, EquipmentType equipment) : base(name, note)
          {
               _equipment = equipment;
          }

          public Exercise(string name, EquipmentType equipment) : base(name, "")
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
               set
               {
                    _reps = value;
                OnPropertyChanged();

            }
        }

          public float Weight
          {
               get
               {
                    return _weight;
               }
               set
               {
             
                _weight = value;
                OnPropertyChanged();

            }
        }

          public WeightUnit WeightUnit
          {
               get
               {
                    return _weightUnit;
               }
               set
               {
                    _weightUnit = value;
                OnPropertyChanged();

            }
        }

          public EquipmentType Equipment
          {
               get
               {
                    return _equipment;
               }
               set
               {
                    _equipment = value;
                OnPropertyChanged();
               }
          }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));


        // for notes visibility in workout history
        public Visibility NotesVisibility
        {
            get
            {
                if(this.Note == null || this.Note.Trim() == "")
                {
                    return Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }
    }
}