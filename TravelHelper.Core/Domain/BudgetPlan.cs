using System;
using System.ComponentModel.DataAnnotations;

namespace TravelHelper.Core.Domain
{
    public class BudgetPlan
    {
        [Key]
        public Guid Id {get; protected set;}
        public Guid TripId {get; protected set;}

        public DateTime  CreatedAt{get; protected set;}
          protected BudgetPlan()
        {
        }
         public BudgetPlan (Guid tripid)
        {
            Id=Guid.NewGuid();
            TripId= tripid;
            CreatedAt = DateTime.UtcNow;
        }

    }
}