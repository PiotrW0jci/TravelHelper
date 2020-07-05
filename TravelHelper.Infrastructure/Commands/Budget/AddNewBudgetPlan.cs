using System;

namespace TravelHelper.Infrastructure.Commands.Budget
{
    public class AddNewBudgetPlan : ICommand
    {
        
        public Guid TripID { get; set; }
    
         
        
    }
}