using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MyLibrary.Messaging;

namespace WpfExample.Message
{
    public class DialogBoxMessage : ViewMessage
    {
        public DialogBoxMessage(object sender) : base(sender)
        {
        }

        public string Message { get; set; }
        public MessageBoxButton Button { get; set; }
        public MessageBoxResult Result { get; set; }
    }
}
