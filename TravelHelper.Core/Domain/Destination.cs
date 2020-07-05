using System;
using System.ComponentModel.DataAnnotations;

namespace TravelHelper.Core.Domain
{
    public class Destination
    {
        [Key]
        public Guid Id {get;protected set;}
        public Guid TripId {get;protected set;}
        public string Name {get;protected set;}

         protected Destination()
        {
        }
        public Destination (Guid tripId,string name)
        {
            Id= Guid.NewGuid();
            TripId= tripId;
            Name=name;
        }
    }
}