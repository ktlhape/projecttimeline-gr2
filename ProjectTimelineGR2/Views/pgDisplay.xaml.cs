using ProjectLibrary;
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

namespace ProjectTimelineGR2.Views
{
    /// <summary>
    /// Interaction logic for pgDisplay.xaml
    /// </summary>
    public partial class pgDisplay : Page
    {
        public pgDisplay()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dgvDisplay.Items.Clear();
            Project pr = new Project();
            foreach (Project p in pr.AllProjects())
            {
                dgvDisplay.Items.Add(p);
            }
        }
    }
}
