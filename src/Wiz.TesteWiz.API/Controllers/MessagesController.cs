using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wiz.TesteWiz.API.Services.Interfaces;
using Wiz.TesteWiz.API.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Wiz.TesteWiz.API.Controllers
{
    [Route("api/messages")]
    public class MessagesController : Controller
    {
        private readonly IMessageService _messageService;
        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]MessageViewModel message)
        {
            await _messageService.PostAsync(message);

            return Ok();
        }
        
        
    }
}
