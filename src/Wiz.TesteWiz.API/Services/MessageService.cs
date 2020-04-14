using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wiz.TesteWiz.API.Services.Interfaces;
using Wiz.TesteWiz.API.ViewModels;
using Wiz.TesteWiz.Domain.Interfaces.Bot;
using Wiz.TesteWiz.Domain.Interfaces.Services;
using Wiz.TesteWiz.Domain.Models.Bot.Watson;

namespace Wiz.TesteWiz.API.Services
{
    public class MessageService : IMessageService

    {
        private readonly IBlipService _blipService;

        private readonly IWatsonBot _watsonBot;
        public MessageService(IBlipService blipService, IWatsonBot watsonBot)
        {
            _blipService = blipService;
            _watsonBot = watsonBot;
        }

        public async Task<string> PostAsync(MessageViewModel message)
        {
            

            var retorno = _watsonBot.SendMessage(message.Content, message.From);


            foreach (Generic resp in retorno.output.generic)
            {
                switch (resp.response_type)
                {
                    case "text":
                        
                        var messageObj = new
                        {
                            id = Guid.NewGuid(),
                            to = message.From,
                            type = "text/plain",
                            content = resp.text
                        };
                        await _blipService.SendMessageAsync(messageObj);
                        break;
                    case "option":
                        string content = resp.title;

                        content += "\n";

                        foreach (Option opt in resp.options)
                        {
                            content += opt.label + " - " + opt.value.input.text + "\n";
                        }

                        var messageObjNew = new
                        {
                            id = Guid.NewGuid(),
                            to = message.From,
                            type = "text/plain",
                            content
                        };

                        await _blipService.SendMessageAsync(messageObjNew);
                        


                        
                        break;
                }
            }

            


            return "";
        }
    }
}
