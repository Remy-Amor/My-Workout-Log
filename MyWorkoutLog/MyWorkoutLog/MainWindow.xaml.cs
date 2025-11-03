using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyWorkoutLog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Exercise testExercise = new Exercise("Something", EquipmentType.barbell);
        public MainWindow()
        {
            InitializeComponent();
            List<Exercise> exerciseList = new List<Exercise> {testExercise};
            Workout testWorkout = new Workout("Upper", exerciseList, DateOnly.FromDateTime(DateTime.Now));

            Console.WriteLine(testWorkout.Name + exerciseList[0].Name);
        }

        
    }
}