using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelHelper.Core.Domain;

namespace TravelHelper.Infrastructure.Services
{
    public interface ITripService
    {
         Task<Trip> AddNewTripAsync(string  UserId,string name,string location,string link);
        Task<List<Trip>> GetTripAsync(string TripId);
        Task<Trip> DeleteTripAsync(string TripId);
        Task<Destination> AddDestination(Guid TripId, string name);
        Task<Destination> DeleteDestinationAsync(string DestinationId);
    }
}