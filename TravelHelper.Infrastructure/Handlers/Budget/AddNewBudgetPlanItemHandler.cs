using System.Threading.Tasks;
using TravelHelper.Infrastructure.Commands;
using TravelHelper.Infrastructure.Commands.Budget;
using TravelHelper.Infrastructure.Services;

namespace TravelHelper.Infrastructure.Handlers.Budget
{
    public class AddNewBudgetPlanItemHandler : ICommandHandler<AddNewBudgetPlanItem>
    {
        private readonly IBudgetService _budget;
        public AddNewBudgetPlanItemHandler(IBudgetService budget){
            _budget = budget;
        }
        
        public async Task HandleAsync(AddNewBudgetPlanItem command)
        {
            await _budget.AddNewBudgetPlanItemAsync(command.BudgetPlanId,command.Name,command.Price,command.Value);
        }
    }
}