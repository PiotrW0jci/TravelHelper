namespace TravelHelper.Infrastructure.Commands.Budget
{
    public class AddTotal :ICommand 
    {
        public string BudgetPlanId { get; set; }
        public int Total { get; set; }
       

    }
}
    
