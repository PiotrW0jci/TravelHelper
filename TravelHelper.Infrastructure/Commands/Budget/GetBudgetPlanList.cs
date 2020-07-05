namespace TravelHelper.Infrastructure.Commands.Budget
{
    public class GetBudgetPlanList:ICommand 
    {
        public string TripId { get; set; }
    }
}