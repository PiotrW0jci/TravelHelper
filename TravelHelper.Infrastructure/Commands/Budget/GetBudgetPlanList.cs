namespace TravelHelper.Infrastructure.Commands.Budget
{
    public class GetBudgetPlanList:ICommand 
    {
        public string UserId { get; set; }
    }
}