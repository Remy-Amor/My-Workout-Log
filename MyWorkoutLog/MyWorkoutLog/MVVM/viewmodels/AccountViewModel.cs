using MyWorkoutLog.Core;
using MyWorkoutLog.Services;
using System.Windows;

namespace MyWorkoutLog.MVVM.ViewModels
{

    public class AccountViewModel : ViewModel
    {
        private string? _currentUsername;
        public string? CurrentUsername
        {
            get { return _currentUsername; }
            set
            {
                _currentUsername = value;
                OnPropertyChanged();

            }
        }

        public AccountViewModel()
        {
            LoadFromSession();

            // subscribe to SessionData changes so viewmodel updates
            SessionData.CurrentUserChanged += OnCurrentUserChanged;

        }

        private void LoadFromSession()
        {
            // Initialize CurrentUsername from SessionData
            if (SessionData.CurrentUser != null)
            {
                CurrentUsername = SessionData.CurrentUser.Username;
            }
            else
            {
                CurrentUsername = "None";
            }
        }

        private void OnCurrentUserChanged()
        {
            LoadFromSession();
        }


        
    }
}