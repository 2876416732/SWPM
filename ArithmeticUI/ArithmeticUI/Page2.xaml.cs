using CalculationModuleUWP;
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
            this.InitializeComponent();
        }

        private void BackButten2_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            int m = 0, s = 0, targetTime = 1800;//倒计时秒数
            strTime.Text = string.Format("剩余时间：{0}分 {1}秒", m, s);
            DispatcherTimer timer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 1) };
            timer.Tick += new EventHandler<object>(async (so, eo) =>
            {
                await Dispatcher.TryRunAsync(CoreDispatcherPriority.Normal, new DispatchedHandler(() =>
                {
                    targetTime--;
                    m = targetTime / 60;
                    s = targetTime % 60;
                    strTime.Text = string.Format("剩余时间：{0}分 {1}秒", m, s);
                    if (targetTime <= 0)
                    {
                        timer.Stop();
                    }
                }));
            });
            timer.Start();

            var t1 = Port.ProblemGeneration("10", "一年级");
            var t2 = Port.ProblemGeneration("10", "一年级");

            foreach (var i in t1.Keys)
            {
                listSubject.Items.Add(i);
            }
            foreach (var i in t2.Keys)
            {
                listSubject.Items.Add(i);
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Page3));
        }
    }
}
