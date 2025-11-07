using MyWorkoutLog.Core;

namespace MyWorkoutLog.Services;

public interface INavigationService
{
     ViewModel CurrentView { get; }
    void NavigateTo<T>() where T : ViewModel;
}
public class NavigationService : ObservableObject, INavigationService
{
    private ViewModel _currentView;
    private readonly Func<Type, ViewModel> _viewModelFactory;

    public ViewModel CurrentView
    {
        get { return _currentView; }
        private set
        {
            _currentView = value;
            OnPropertyChanged();
        }
    }

    // constructor,sets viewModelFactory
    public NavigationService(Func<Type,ViewModel>viewModelFactory)
    {
        _viewModelFactory = viewModelFactory;
    }

    // for actually changing the view. Type ViewModel is input, viewModelFactory is invoked to return the view model instance held in services,
    // CurrentView is set to viewModel
    public void NavigateTo<TViewModel>() where TViewModel : ViewModel
    {
        ViewModel viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
        CurrentView = viewModel;
    }
}