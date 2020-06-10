using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelHelper.Infrastructure.Commands;
using TravelHelper.Infrastructure.Commands.Trip;
using TravelHelper.Infrastructure.Data;
using TravelHelper.Infrastructure.Services;



namespace TravelHelper.Api.Controllers
{
    public class TripController : ApiControllerBase
    {
        private readonly ITripService _trip;
        private readonly IBudgetService _budget;
        private readonly DataContext _context;

        public TripController(ITripService trip,IBudgetService budget, 
        ICommandDispatcher commandDispatcher, DataContext context) : base(commandDispatcher)
        {
            _budget=budget;  
            _context= context;
            _trip=trip;
        }


        
       [HttpPost("add")]
       public async Task<IActionResult> Post([FromBody]AddNewTrip command)
            {         
                await CommandDispatcher.DispatchAsync(command);
                 
                return StatusCode(201);
            
    }
   
      [HttpGet("{UserId}")]
       public async Task<IActionResult> GetTrips(GetUserTrips command)
            {   
                //await CommandDispatcher.DispatchAsync(command);      
                var userId = Guid.Parse(command.UserId);
                var trips =  await _context.Trips.Where(x=>x.UserId == userId).ToListAsync();
      
                return Json(new
                {
                    ItemList = trips});
            
    }
      [Authorize]
      [HttpGet("delete/{TripId}")]
       public async Task<IActionResult> DeleteTrip(DeleteTrip command)
            {   
                await CommandDispatcher.DispatchAsync(command);      
           
                return StatusCode(201);
    
            
    }
      
    }
}