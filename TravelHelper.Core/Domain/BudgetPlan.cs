using System;
using System.ComponentModel.DataAnnotations;

namespace TravelHelper.Core.Domain
{
    public class BudgetPlan
    {
        [Key]
        public Guid Id {get; protected set;}
        public Guid UserId {get; protected set;}
        public string Name{get; protected set;}
        public DateTime  CreatedAt{get; protected set;}
          protected BudgetPlan()
        {
        }
         public BudgetPlan (string userid,string budgetname)
        {
            Id=Guid.NewGuid();
            UserId= Guid.Parse(userid);
            Name=budgetname;
            CreatedAt = DateTime.UtcNow;
        }

    }
}