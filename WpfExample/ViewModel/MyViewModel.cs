using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MyLibrary;
using MyLibrary.Messaging;
using WpfExample.Message;

namespace WpfExample.ViewModel
{
    public class MyViewModel : ViewModelBase
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {   if ( _name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public MyViewModel()
        {
            this.Regist();
        }

        private bool IsOk
        {
            get { return !string.IsNullOrWhiteSpace(Name); }
        }

        private ICommand _helloCommand;

        public ICommand Hello
        {
            get
            {
                if (_helloCommand == null)
                {
                    _helloCommand = new RelayCommand(HelloAction);
                }
                return _helloCommand;
            }
        }

        public event EventHandler TestHandler = null;
        public async void HelloAction()
        {

            await Task.Run(() => {
                Thread.Sleep(10000);

                if( TestHandler != null)
                {
                    TestHandler(this, new EventArgs());
                }
            });
        }

        public void Regist()
        {
            TestHandler += MyViewModel_TestHandler;

            Messenger.Default.Register<DialogBoxMessage>(this, message => {
                this.Name = "Pochi";
                App.Current.Dispatcher.BeginInvoke(new Action(() => {
                    MessageBox.Show(message.Message, "確認", message.Button);

                    this.Name = "わんわん";
                }));             
            });
        }

        private void MyViewModel_TestHandler(object sender, EventArgs e)
        {
            var msg = new DialogBoxMessage(this);
            msg.Message = Name + "さん、こんにちは。";
            msg.Button = MessageBoxButton.YesNo;
            Messenger.Default.Send(this, msg);
            if (msg.Result == MessageBoxResult.Yes)
            {
                Name = "";
            }
        }
    }
}
