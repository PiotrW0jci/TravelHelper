namespace TravelHelper.Infrastructure.Commands.Trip
{
    public class AddDestination : ICommand
    {
        public string TripId { get; set; }
        public string Name {get; set;}
    
    }
}