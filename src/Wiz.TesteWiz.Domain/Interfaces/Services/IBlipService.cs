using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Wiz.TesteWiz.Domain.Interfaces.Services
{
    public interface IBlipService
    {
        Task<object> SendMessageAsync(object resource);
    }
}
