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

namespace WpfApp4
{
    public enum BatteryStatus
    {
        None = 0,
        Min,
        Mid,
        Max
    }

    /// <summary>
    /// BatteryControl.xaml の相互作用ロジック
    /// </summary>
    public partial class BatteryControl : UserControl
    {
        public static readonly DependencyProperty StatusProperty =
            DependencyProperty.Register(
        "Status",
        typeof(BatteryStatus),
        typeof(BatteryControl),
        new PropertyMetadata(BatteryStatus.None, (d, e) => {
            var c = (d as BatteryControl);
            if (e.NewValue == e.OldValue) return;
            switch (e.NewValue)
            {
                case BatteryStatus.Max:
                    c.batteryFrame.Stroke = Brushes.Green;
                    c.batteryMax.Stroke = Brushes.Green;
                    c.batteryMid.Stroke = Brushes.Green;
                    c.batteryMin.Stroke = Brushes.Green;
                    c.batteryMax.Visibility = Visibility.Visible;
                    c.batteryMid.Visibility = Visibility.Visible;
                    c.batteryMin.Visibility = Visibility.Visible;
                    break;
                case BatteryStatus.Mid:
                    c.batteryFrame.Stroke = Brushes.Orange;
                    c.batteryMid.Stroke = Brushes.Orange;
                    c.batteryMax.Stroke = Brushes.Green;
                    c.batteryMin.Stroke = Brushes.Orange;
                    c.batteryMid.Visibility = Visibility.Visible;
                    c.batteryMin.Visibility = Visibility.Visible;
                    c.batteryMax.Visibility = Visibility.Hidden;
                    break;
                case BatteryStatus.Min:
                    c.batteryFrame.Stroke = Brushes.Red;
                    c.batteryMin.Stroke = Brushes.Red;
                    c.batteryMax.Stroke = Brushes.Green;
                    c.batteryMid.Stroke = Brushes.Green;
                    c.batteryMin.Visibility = Visibility.Visible;
                    c.batteryMax.Visibility = Visibility.Hidden;
                    c.batteryMid.Visibility = Visibility.Hidden;
                    break;
                default:
                    c.batteryFrame.Stroke = Brushes.Red;
                    c.batteryMax.Stroke = Brushes.Red;
                    c.batteryMid.Stroke = Brushes.Red;
                    c.batteryMin.Stroke = Brushes.Red;
                    c.batteryMax.Visibility = Visibility.Hidden;
                    c.batteryMid.Visibility = Visibility.Hidden;
                    c.batteryMin.Visibility = Visibility.Hidden;
                    break;
            }
        }));

        public BatteryStatus Status
        {
            get { return (BatteryStatus)GetValue(StatusProperty); }
            set { SetValue(StatusProperty, value); }
        }

        public BatteryControl()
        {
            InitializeComponent();

            this.Status = BatteryStatus.None;
        }
    }
}
