using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfExample.Service
{
    public class MessageService : IMessageService
    {
        public bool SendMessage(object sender, MessageArgs<object> args)
        {
            return true;
        }
    }
}
