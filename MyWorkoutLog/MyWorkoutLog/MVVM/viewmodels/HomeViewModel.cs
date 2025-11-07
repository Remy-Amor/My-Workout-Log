using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWorkoutLog.Core;
using MyWorkoutLog;

namespace MyWorkoutLog.MVVM.ViewModels
{
    public class HomeViewModel : ViewModel
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

        public HomeViewModel()
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
