namespace TravelHelper.Infrastructure.Commands.Trip
{
    public class AddNewTrip: ICommand
    {
        public string UserID { get; set; }
        public string Name {get; set;}
    
    }
}