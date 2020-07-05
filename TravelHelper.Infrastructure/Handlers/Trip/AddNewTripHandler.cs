using System.Threading.Tasks;
using TravelHelper.Infrastructure.Commands;
using TravelHelper.Infrastructure.Commands.Trip;
using TravelHelper.Infrastructure.Services;

namespace TravelHelper.Infrastructure.Handlers.Trip
{
    public class AddNewTripHandler :ICommandHandler<AddNewTrip>
    {

      private readonly ITripService _trip ;
        public AddNewTripHandler(ITripService trip){
            _trip = trip;
        }

        public async Task HandleAsync(AddNewTrip command)
        {
            await _trip.AddNewTripAsync(command.UserID,command.Name,command.Location,command.Link);
            
        }
    }
}