using System.Threading.Tasks;
using TravelHelper.Infrastructure.Commands;
using TravelHelper.Infrastructure.Commands.Trip;
using TravelHelper.Infrastructure.Services;

namespace TravelHelper.Infrastructure.Handlers.Trip
{
    public class DeleteTripHandler:  ICommandHandler<DeleteTrip>
    {
         private readonly ITripService _trip ;
        public DeleteTripHandler(ITripService trip){
            _trip = trip;
        }

        public async Task HandleAsync(DeleteTrip command)
        {
            await _trip.DeleteTripAsync(command.TripId);
            
        }
    }
}