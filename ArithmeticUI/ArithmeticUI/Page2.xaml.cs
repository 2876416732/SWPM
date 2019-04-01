using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace ArithmeticUI
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Page2 : Page
    {
        public Page2()
        {
            int i = 0;
            int TimeCount = 1800;//倒计时秒数
            DispatcherTimer timer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 1) };
            timer.Tick += new EventHandler<object>(async (sender, e) =>
            {
                await Dispatcher.TryRunAsync(CoreDispatcherPriority.Normal, new DispatchedHandler(() =>
                {
                    i += 1;
                    double temp = (385 * Math.PI) * i / TimeCount / 15;
                    MyEllipse.StrokeDashArray = new DoubleCollection() { temp, 1000 };
                    txt.Text = ((TimeCount - i) / 60).ToString("00") + ":" + ((TimeCount - i) % 60).ToString("00");
                    if (i == TimeCount)
                        timer.Stop();
                }));
            });
            timer.Start();
            this.InitializeComponent();
        }

        private void BackButten2_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
