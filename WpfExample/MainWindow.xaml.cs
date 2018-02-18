using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfExample.ViewModel;
using WpfExample.Service;
using MyLibrary.Messaging;
using WpfExample.Message;

namespace WpfExample
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        MyViewModel test = new MyViewModel();

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = test;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            test.HelloAction();

            System.Console.WriteLine("test");
        }
    }
}
