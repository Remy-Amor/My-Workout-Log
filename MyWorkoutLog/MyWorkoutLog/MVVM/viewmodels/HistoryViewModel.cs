using MyWorkoutLog.Core;
using MyWorkoutLog.Services;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows;


namespace MyWorkoutLog.MVVM.ViewModels;

public class HistoryViewModel : ViewModel
{
    
    public ObservableDictionary<Workout, DateOnly> Workouts
    {
        get
        {
            return SessionData.CurrentUser.WorkoutHistory;
        }
    }
    
}