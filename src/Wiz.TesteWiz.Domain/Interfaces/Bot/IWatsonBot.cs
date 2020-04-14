using System;
using System.Collections.Generic;
using System.Text;
using Wiz.TesteWiz.Domain.Models.Bot.Watson;

namespace Wiz.TesteWiz.Domain.Interfaces.Bot
{
    public interface IWatsonBot
    {
        Response SendMessage(string message, string userid);
    }
}
