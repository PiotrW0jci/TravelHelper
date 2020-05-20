using Microsoft.EntityFrameworkCore;
using TravelHelper.Core.Domain;


namespace TravelHelper.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
    
        
        public DbSet<User> Users {get;set;}
        public DbSet<BudgetPlan> Budgets {get;set;}
        public DbSet<BudgetPlanItem> BudgetItems {get;set;}
    }
}