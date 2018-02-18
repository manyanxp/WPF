using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfExample.Service
{
    /// <summary>
    /// 送信するメッセージ
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MessageArgs<T> : EventArgs
    {
        public int MesasgeId { get; set; }
        public T   Data { get; set; }
    }

    /// <summary>
    /// メッセージインターフェース
    /// </summary>
    public interface IMessageService
    {
        bool SendMessage(object sender, MessageArgs<object> args);
    }
}
