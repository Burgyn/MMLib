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

namespace WPFDemoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dt0.DateTime = DateTime.Now;
            dt1.DateTime = DateTime.Now.AddMinutes(-1);
            dt2.DateTime = DateTime.Now.AddMinutes(-2);
            dt3.DateTime = DateTime.Now.AddMinutes(-3);
            dt4.DateTime = DateTime.Now.AddMinutes(-5);
            dt5.DateTime = DateTime.Now.AddHours(-1);
            dt6.DateTime = DateTime.Now.AddDays(-1);
        }
    }
}
