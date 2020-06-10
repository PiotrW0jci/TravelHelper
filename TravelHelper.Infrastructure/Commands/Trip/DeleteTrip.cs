namespace TravelHelper.Infrastructure.Commands.Trip
{
    public class DeleteTrip : ICommand
    {
         public string TripId { get; set; }
    
    }
}