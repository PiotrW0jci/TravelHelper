using System.ComponentModel;
using System.Threading.Tasks;
using TravelHelper.Core.Domain;

namespace TravelHelper.Infrastructure.Services
{
    public interface IBudgetService : IService
    {
        Task<BudgetPlan> AddNewBudgetPlanAsync(string  UserId,string Name);
        Task<BudgetPlanItem> AddNewBudgetPlanItemAsync(string BudgetPlanId,string Name,int Value,int Price);
        Task<BudgetPlan> GetUserBudgetPlanAsync(string UserId);
        Task<BudgetPlan> DeleteBudgetPlanAsync(string BudgetPlanId);
    }
}