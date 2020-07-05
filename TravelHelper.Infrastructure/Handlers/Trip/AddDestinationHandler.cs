using System;
using System.Threading.Tasks;
using TravelHelper.Infrastructure.Commands;
using TravelHelper.Infrastructure.Commands.Trip;
using TravelHelper.Infrastructure.Services;

namespace TravelHelper.Infrastructure.Handlers.Trip
{
    public class AddDestinationHandler : ICommandHandler<AddDestination>
    {
        private readonly ITripService _trip;

        public AddDestinationHandler(ITripService trip){
            _trip = trip;
        }
        public async Task HandleAsync(AddDestination command)
        {
             await _trip.AddDestination(Guid.Parse(command.TripId),command.Name);
        }
    }
}