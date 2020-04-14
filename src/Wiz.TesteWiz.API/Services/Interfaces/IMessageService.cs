using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wiz.TesteWiz.API.ViewModels;

namespace Wiz.TesteWiz.API.Services.Interfaces
{
    public interface IMessageService
    {
        Task<string> PostAsync(MessageViewModel message);
    }
}
