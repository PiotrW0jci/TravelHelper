using System.Threading.Tasks;
using TravelHelper.Infrastructure.Commands;
using TravelHelper.Infrastructure.Commands.Budget;
using TravelHelper.Infrastructure.Services;

namespace TravelHelper.Infrastructure.Handlers.Budget
{
    public class GetBudgetPlanListHandler: ICommandHandler<GetBudgetPlanList>
    {
        private readonly IBudgetService _budget;
        public GetBudgetPlanListHandler(IBudgetService budget){
            _budget = budget;
        }
        public async Task HandleAsync(GetBudgetPlanList command)
        {
            await _budget.GetUserBudgetPlanAsync(command.TripId);
        }
    }
}
 