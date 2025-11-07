namespace MyWorkoutLog;

public static class SessionData
{
    private static BaseUser _currentUser = new Guest();
    private static List<RegisteredUser> registeredUsers = new();
   private static readonly BaseExercises exercises = new();

    public static event Action? CurrentUserChanged;
    public static event Action? RegisteredUsersChanged;

    public static BaseUser CurrentUser
    {
        get { return _currentUser; }
        set { 
            if (!ReferenceEquals(_currentUser, value))
            {
                _currentUser = value;
                CurrentUserChanged?.Invoke();
            }
        }
    }

    public static List<RegisteredUser> RegisteredUsers
    {
        get { return registeredUsers; }
    }

    public static void AddUser(RegisteredUser user)
    {
        registeredUsers.Add(user);
        RegisteredUsersChanged?.Invoke();
    }

    public static void RemoveUser(RegisteredUser user)
    {
        registeredUsers.Remove(user);
        RegisteredUsersChanged?.Invoke();
    }




}