using System.Net;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelHelper.Infrastructure.Commands;
using TravelHelper.Infrastructure.Commands.Trip;
using TravelHelper.Infrastructure.Data;
using TravelHelper.Infrastructure.Services;
using System.Collections.Generic;
using System.Text.Json;
using System.Globalization;

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
       public async Task<IActionResult> Post([FromHeader]object header,[FromBody]AddNewTrip command)
            {   
  
                Microsoft.Extensions.Primitives.StringValues value ="";
                var coll=Request.Headers.TryGetValue("Authorization", out  value); 
                var coll1=Request.Body;
                var values= value.ToString().Split().ToList();
                var stream =values[1];  
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(stream);
                var tokenS = handler.ReadToken(stream) as JwtSecurityToken;
                command.UserID= tokenS.Claims.First().Value;
                
                await CommandDispatcher.DispatchAsync(command);
                 
                return StatusCode(201);
            
    }
    public class TripPOCOs
                {
                    public string name { get; set; }
                    public IList<string> locations {get;set;}
                    public string image_url {get;set;}
                    public string created_at {get;set;}
                    public Guid Id {get;set;}
                }

      [HttpGet("")]
       public async Task<IActionResult> GetTrips([FromHeader]object header)
            {   
                Microsoft.Extensions.Primitives.StringValues value ="";
                var coll=Request.Headers.TryGetValue("Authorization", out  value); 
                var values= value.ToString().Split().ToList();
                var stream =values[1];  
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(stream);
                var tokenS = handler.ReadToken(stream) as JwtSecurityToken;
    
                //await CommandDispatcher.DispatchAsync(command);      
                var userId = Guid.Parse(tokenS.Claims.First().Value);
                var trips =  await _context.Trips.Where(x=>x.UserId == userId).ToListAsync();
                
                Dictionary <string, Tuple<string, List<string>>> tripList= new Dictionary <string, Tuple<string, List<string>>>() ;
                List<TripPOCOs> trip_list=new List<TripPOCOs>(); 
                foreach(var trip in trips)
                {
                    var _trips = new TripPOCOs();
                    _trips.locations =_context.Destinations.Where(x=>x.TripId == trip.Id).Select(x=>x.Name).ToList();
                    _trips.image_url=trip.PhotoUrl;
                    _trips.name=trip.TripName;
                    _trips.created_at=trip.CreatedAt.ToString("g",
                  DateTimeFormatInfo.InvariantInfo);
                    _trips.Id=trip.Id;
                    trip_list.Add(_trips);
                    
                }
                
                
                return Json(new
                {
                    trip_list
                  
                    });
            
    }
     
      [HttpPost("delete")]
       public async Task<IActionResult> DeleteTrip([FromBody]DeleteTrip command)
            {   
                 var trip = await _context.Trips.FirstOrDefaultAsync(x=>x.Id == Guid.Parse(command.TripId));
            _context.Trips.Attach(trip);
            _context.Trips.Remove(trip);
            await _context.SaveChangesAsync();
            
               // await CommandDispatcher.DispatchAsync(command);      
           
                return StatusCode(201);
    
            
    }
     [HttpPost("Destination")]
       public async Task<IActionResult> Destination([FromHeader]object header,[FromBody]AddDestination command)
            {   

                await CommandDispatcher.DispatchAsync(command);
                 
                return StatusCode(201);
            
    }
      
    }
}