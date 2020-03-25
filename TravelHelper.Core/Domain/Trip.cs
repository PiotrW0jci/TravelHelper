using System;

namespace TravelHelper.Core.Domain
{
    public class Trip
    {
        public Guid Id {get; protected set;}
        public Guid UserId {get; protected set;}
        public DateTime  CreatedAt{get; protected set;}
        public string TripName{get;protected set;}
        
        public string Destination{get;protected set;}


        protected Trip()
        {
        }
        public Trip (Guid id, Guid userid,string tripname,string destination)
        {
            Id=id;
            UserId= userid;
            TripName=tripname;
            Destination=destination;
            CreatedAt = DateTime.UtcNow;
        }
    }


}