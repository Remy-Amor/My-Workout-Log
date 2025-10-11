namespace MyWorkoutLog
{
     public class Guest : BaseUser
     {
          public Guest()
          {
               _username = "Guest";
               _password = "";
               _accountPermissions = false;
          }
     }
}