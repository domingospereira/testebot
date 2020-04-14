using System;
using System.Collections.Generic;
using System.Text;

namespace Wiz.TesteWiz.Domain.Models.Bot.Watson
{
    public class Output
    {
        public IList<Generic> generic { get; set; }
        public IList<Intent> intents { get; set; }
        public IList<object> entities { get; set; }
    }

}
