using System;

namespace TravelHelper.Core.Domain
{
    public class BudgetPlanItem
    {
        public Guid Id {get;protected set;}
        public Guid BudgetPlan {get;protected set;}
        public int Value {get;protected set;}

    }
}