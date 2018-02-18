using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Reflection;

namespace MyLibrary.Messaging
{
    public class ViewMessage
    {
        public object Sender { get; protected set; }
        public ViewMessage(object sender)
        {
            this.Sender = sender;
        }
    }

    /// <summary>
    /// アクション情報
    /// </summary>
    public class ActionInfo
    {
        public Type Type { get; set; }
        public object Target { get; set; }
        public Delegate Action { get; set; }
    }

    /// <summary>
    /// Mvvm Lightをまねた仕組み
    /// </summary>
    public class Messenger
    {
        // メッセンジャークラスの実体
        private static Messenger _instance = new Messenger();
        // メッセンジャークラスのインスタンスを返す.
        public static Messenger Default
        {
           get { return _instance; }
        }

        /// <summary>
        /// アクションリスト
        /// </summary>
        private List<ActionInfo> _list = new List<ActionInfo>();

        /// <summary>
        /// コールバックさせるメソッドの登録
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <param name="recipient"></param>
        /// <param name="action"></param>
        public void Register<TMessage>(object target, Action<TMessage> action)
        {
            lock (this._list)
            {
                this._list.Add(new ActionInfo
                {
                    Type = typeof(TMessage),
                    Target = target,
                    Action = action
                });
            }
        }

        /// <summary>
        /// メッセージの送信
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        public void Send<TMessage>(object target, TMessage message)
        {
            lock (this._list)
            {
                var q = this._list.Where(o => o.Target == target && o.Type == message.GetType())
                    .Select(o => o.Action as Action<TMessage>);
                foreach (var a in q)
                {
                    a(message);
                }
            }
        }

        /// <summary>
        /// メソッドの削除
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <param name="target"></param>
        /// <param name="message"></param>
        public void Unreister<TMessage>(object target, TMessage message)
        {
            lock (this._list)
            {
                this._list.RemoveAll(o => o.Target == target && o.Type == message.GetType());
            }
        }
    }
}
