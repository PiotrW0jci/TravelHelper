namespace TravelHelper.Infrastructure.Commands.Budget
{
    public class AddNewBudgetPlan : ICommand
    {
        
        public string UserID { get; set; }
        public string Name { get; set; }
     
           
        
    }
}