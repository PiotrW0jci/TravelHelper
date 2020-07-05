
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelHelper.Core.Domain;
using TravelHelper.Infrastructure.Data;

namespace TravelHelper.Infrastructure.Services
{
    public class TripService : ITripService
    {
        private readonly IMapper _mapper;
      
        private readonly DataContext _context;
        private readonly IBudgetService _budget;
     

        public TripService(IMapper mapper, DataContext context,IBudgetService budget)
        {
           
            _mapper = mapper;
            _context= context;
            _budget = budget;
        
        }
        public async Task<Trip> AddNewTripAsync(string UserID, string Name,string location, string link)
        {
            var trip = new Trip(System.Guid.Parse(UserID) ,Name,link);
            var destination= new Destination(trip.Id,location);
            var budget = await _budget.AddNewBudgetPlanAsync(trip.Id);
            trip.BudgetId= budget.Id;
            await _context.Trips.AddAsync(trip);
            await AddDestination(trip.Id,location);
            await _context.SaveChangesAsync();
           return trip;
        
        }
         public async Task<List<Trip>> GetTripAsync(string UserId )
        {
            var userId = Guid.Parse(UserId);
            var trip = await _context.Trips.Where(x=>x.UserId == userId).ToListAsync();

             
           return trip;
          
        
        }
    

        public async Task<Trip> DeleteTripAsync(string TripId)
        {
           var trip = await _context.Trips.FirstOrDefaultAsync(x=>x.Id == Guid.Parse(TripId));
            _context.Trips.Attach(trip);
            _context.Trips.Remove(trip);
            await _context.SaveChangesAsync();
            return trip;
        }

        public async Task<Destination> AddDestination(Guid TripId, string name)
        {
            var destination = new Destination(TripId ,name);
            await _context.Destinations.AddAsync(destination);
            await _context.SaveChangesAsync();
            return destination;
        }

        public async Task<Destination> DeleteDestinationAsync(string DestinationId)
        {
            var destination = await _context.Destinations.FirstOrDefaultAsync(x=>x.Id == Guid.Parse(DestinationId));
            _context.Destinations.Attach(destination);
            _context.Destinations.Remove(destination);
            await _context.SaveChangesAsync();
            return destination;
        }
    }
}