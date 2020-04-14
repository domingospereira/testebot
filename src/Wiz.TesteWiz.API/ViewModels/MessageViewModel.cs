using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wiz.TesteWiz.API.ViewModels
{
    public class MessageViewModel
    {
        public MessageViewModel()
        {

        }
        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }
    }
}
