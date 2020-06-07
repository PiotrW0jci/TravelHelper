using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelHelper.Infrastructure.Commands;
using TravelHelper.Infrastructure.Data;
using TravelHelper.Infrastructure.Services;

using TravelHelper.Infrastructure.Commands.Budget;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace TravelHelper.Api.Controllers
{
    public class BudgetController :ApiControllerBase
    {
        private readonly IBudgetService _budget;
        private readonly DataContext _context;
        public BudgetController(IBudgetService budget,
        ICommandDispatcher commandDispatcher, DataContext context) : base(commandDispatcher)
        {
            _budget=budget;  
            _context= context;
        }
       [Authorize]
       [HttpPost("add")]
       public async Task<IActionResult> Post([FromBody]AddNewBudgetPlan command)
            {         
                await CommandDispatcher.DispatchAsync(command);
                 
                return StatusCode(201);
            
    }
     [Authorize]
     [HttpPost("addItem")]
       public async Task<IActionResult> AddElement([FromBody]AddNewBudgetPlanItem command)
            {         
                await CommandDispatcher.DispatchAsync(command);
                 
                return StatusCode(201);
            
    }
      [Authorize]
      [HttpGet("{UserId}")]
       public async Task<IActionResult> GetBudgets(GetBudgetPlanList command)
            {   
                //await CommandDispatcher.DispatchAsync(command);      
                var userid = Guid.Parse(command.UserId);
                var budget = await _context.Budgets.FirstOrDefaultAsync(x=>x.UserId == userid);
                var name = budget.Name;
                var Id =budget.Id;
                var items = _context.BudgetItems.Where(x=>x.BudgetPlanId==Id).ToListAsync();
      
                return Json(new
                {
                    Name =name,
                    ItemList = items});
            
    }
}
}