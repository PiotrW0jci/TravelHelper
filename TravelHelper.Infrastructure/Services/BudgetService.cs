using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelHelper.Core.Domain;
using TravelHelper.Infrastructure.Data;

namespace TravelHelper.Infrastructure.Services
{
    public class BudgetService : IBudgetService
    {
      
        private readonly IMapper _mapper;
      
        private readonly DataContext _context;
     

        public BudgetService(IMapper mapper, DataContext context)
        {
           
            _mapper = mapper;
            _context= context;
        
        }
        public async Task<BudgetPlan> AddNewBudgetPlanAsync(Guid TripId)
        {
            
           /* var budget = await _context.Budgets.FirstOrDefaultAsync(x=>x.Name == Name);
            if(budget!=null)
            {
               throw new Exception($"Budget with that name: '{Name}' already exists.");
            }*/
            
            var budget = new BudgetPlan(TripId);
            await _context.Budgets.AddAsync(budget);
            await _context.SaveChangesAsync();

            return budget;
        }

        public async Task<BudgetPlanItem> AddNewBudgetPlanItemAsync(string BudgetPlanId, string Name, int Value, int Price)
        {
            var budgetItem = await _context.BudgetItems.FirstOrDefaultAsync(x=>x.Name == Name);
            if(budgetItem!=null)
            {
               throw new Exception($"Budget Item with that name: '{Name}' already exists.");
            }
            budgetItem = new BudgetPlanItem(BudgetPlanId,Name,Price,Value);
            await _context.BudgetItems.AddAsync(budgetItem);
            await _context.SaveChangesAsync();

            return budgetItem;
        }

        public async Task<BudgetPlan> DeleteBudgetPlanAsync(string TripId)
        {
            var tripid = Guid.Parse(TripId);
            var budget = await _context.Budgets.FirstOrDefaultAsync(x=>x.TripId == tripid);
            _context.Budgets.Attach(budget);
            _context.Budgets.Remove(budget);
            await _context.SaveChangesAsync();

            return budget;
        }

        public async Task<BudgetPlan> GetUserBudgetPlanAsync(string TripId)
        {
            var tripid = Guid.Parse(TripId);
            var budget = await _context.Budgets.FirstOrDefaultAsync(x=>x.TripId == tripid);
            var Id =budget.Id;
            var items = _context.BudgetItems.Where(x=>x.BudgetPlanId==Id).ToListAsync();

            return budget;
        }
    }

}