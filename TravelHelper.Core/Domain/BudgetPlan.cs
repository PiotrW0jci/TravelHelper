using System;
namespace TravelHelper.Core.Domain
{
    public class BudgetPlan
    {
        public Guid Id {get; protected set;}
        public Guid UserID {get; protected set;}
        public string Name{get; protected set;}

    }
}