using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace WpfExample.Actions
{
    public class Action
    {
        public Action()
        {
        }

        /// <summary>
        /// テスト用の非同期処理
        /// </summary>
        public async void ProcAsync()
        {

            var r = await Task.Run(() => {
                Thread.Sleep(10000);
                return true;
            });
        }
    }
}
