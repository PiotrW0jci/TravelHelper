namespace TravelHelper.Infrastructure.Commands.Users
{
    public class SendEmail :ICommand
    {
        public string Email { get; set; }
        public string value { get; set; }
    }
}