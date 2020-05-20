using TravelHelper.Infrastructure.Commands;
using System.Threading.Tasks;
using TravelHelper.Infrastructure.Extensions;
using TravelHelper.Infrastructure.Commands.Budget;
using TravelHelper.Infrastructure.Services;

namespace TravelHelper.Infrastructure.Handlers.Budget
{
    public class CreateBudgetHandler : ICommandHandler<AddNewBudgetPlan>
    {
        private readonly IBudgetService _budget;
        public CreateBudgetHandler(IBudgetService budget){
            _budget = budget;
        }
        public async  Task HandleAsync(AddNewBudgetPlan command)
        {
            await _budget.AddNewBudgetPlanAsync(command.UserID,command.Name);
        }
    }
}