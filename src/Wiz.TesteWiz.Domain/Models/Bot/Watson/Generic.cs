using System;
using System.Collections.Generic;
using System.Text;

namespace Wiz.TesteWiz.Domain.Models.Bot.Watson
{
    public class Generic
    {
        public string response_type { get; set; }
        public string text { get; set; }
        public string title { get; set; }
        public IList<Option> options { get; set; }
    }

}
