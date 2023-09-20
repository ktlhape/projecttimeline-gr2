using ProjectTimelineGR2.Views;
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

namespace ProjectTimelineGR2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        pgFilter filter = new pgFilter();
        pgCapture capture = new pgCapture();
        pgDisplay display = new pgDisplay();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCapture_Click(object sender, RoutedEventArgs e)
        {
            frmContainer.Content = capture;
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            frmContainer.Content = filter;
        }

        private void btnDisplay_Click(object sender, RoutedEventArgs e)
        {
            frmContainer.Content = display;
        }
    }
}
