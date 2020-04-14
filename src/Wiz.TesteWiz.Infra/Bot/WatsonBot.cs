using IBM.Cloud.SDK.Core.Authentication.Iam;
using IBM.Watson.Assistant.v2;
using IBM.Watson.Assistant.v2.Model;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Wiz.TesteWiz.Domain.Interfaces.Bot;
using Wiz.TesteWiz.Domain.Models.Bot.Watson;

namespace Wiz.TesteWiz.Infra.Bot
{
    public class WatsonBot : IWatsonBot
    {
        private readonly IamAuthenticator _iamAuthenticator;

        private readonly AssistantService _assistantService;

        private readonly string _assistantId;

        //private readonly string _sessionid;

        private readonly IDistributedCache _distributedCache;
        public WatsonBot(IConfiguration configuration, IDistributedCache distributedCache)
        {
            _iamAuthenticator = new IamAuthenticator(configuration["Watson:Key"]);

            _assistantService = new AssistantService("2019-02-28", _iamAuthenticator);

            _assistantService.SetServiceUrl(configuration["Watson:Url"]);

            _assistantId = configuration["Watson:AssistantId"];

            _distributedCache = distributedCache;

            //_sessionid = _assistantService.CreateSession(_assistantId).Result.SessionId;
        }
        public Response SendMessage(string message, string userId)
        {
            var _sessionid = _distributedCache.GetString(userId);
            if (string.IsNullOrWhiteSpace(_sessionid))
            {
                _sessionid = _assistantService.CreateSession(_assistantId).Result.SessionId;

                _distributedCache.SetString(userId, _sessionid, new DistributedCacheEntryOptions() { SlidingExpiration = new TimeSpan(00, 10, 00) });
            }
            //var sessionid = _assistantService.CreateSession(_assistantId).Result.SessionId;

            var messageObj = new IBM.Watson.Assistant.v2.Model.MessageInput()
            {
                Text = message
            };

            MessageContextSkills skills = new MessageContextSkills();
            MessageContextSkill skill = new MessageContextSkill();
            skill.UserDefined = new Dictionary<string, object>();

            skills.Add("main skill", skill);

            var MessageContext = new IBM.Watson.Assistant.v2.Model.MessageContext()
            {
                Global = new MessageContextGlobal()
                {
                    System = new MessageContextGlobalSystem()
                    {
                        UserId = userId,
                        Timezone = "GMT3"
                    }
                },
                Skills = skills
            };

            var result = _assistantService.Message(_assistantId, _sessionid, messageObj, MessageContext);

            var response = JsonConvert.DeserializeObject<Response>(result.Response);

            //_assistantService.DeleteSession(_assistantId, sessionid);
            return response;
        }
    }
}
