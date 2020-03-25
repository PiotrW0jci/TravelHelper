using System.Windows.Input;
using Microsoft.AspNetCore.Mvc;
using TravelHelper.Infrastructure.Commands;

namespace TravelHelper.Api.Controllers
{   
     [Route("[controller]")]
    public abstract class ApiControllerBase : Controller
    {
        protected readonly ICommandDispatcher CommandDispatcher;
        protected ApiControllerBase(ICommandDispatcher commandDispatcher)
        {
            CommandDispatcher = commandDispatcher;    
        }
    }
}