
using Microsoft.AspNetCore.Mvc;
using Wiz.TesteWiz.API.ViewModels;

namespace Wiz.TesteWiz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        public void Post([FromBody]MessageViewModel message)
        {

        }
    }
}