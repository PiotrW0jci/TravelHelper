using System;
using System.ComponentModel.DataAnnotations;

namespace TravelHelper.Core.Domain
{
    public class Trip
    { 
        [Key]
        public Guid Id {get; protected set;}
        public Guid UserId {get; protected set;}
        public Guid BudgetId {get;  set;}
        public DateTime  CreatedAt{get; protected set;}
        public string TripName{get;protected set;}

        public string PhotoUrl{get;protected set;}
        
        public Guid DestinationId{get;protected set;}


        protected Trip()
        {
        }
        public Trip (Guid userid,string tripname, string photoUrl)
        {
            Id= Guid.NewGuid();
            UserId= userid;
            TripName=tripname;
            CreatedAt = DateTime.UtcNow;
            PhotoUrl=photoUrl;
        }
    }


}