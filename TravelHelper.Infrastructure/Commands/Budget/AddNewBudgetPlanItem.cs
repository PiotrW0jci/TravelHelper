namespace TravelHelper.Infrastructure.Commands.Budget
{
    public class AddNewBudgetPlanItem :ICommand 
    {
        public string BudgetPlanId { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public int Price { get; set; }

    }
}