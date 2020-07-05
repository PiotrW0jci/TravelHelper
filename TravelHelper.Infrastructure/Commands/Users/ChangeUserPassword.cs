namespace TravelHelper.Infrastructure.Commands.Users
{
    public class ChangeUserPassword : ICommand
    {
        
        public string UserId { get;set;}
        public string CurrentPassword { get;set;}
        public string NewPassword { get;set;}
        
    }
}