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
    /// Interaction logic for pgFilter.xaml
    /// </summary>
    public partial class pgFilter : Page
    {
        public pgFilter()
        {
            InitializeComponent();
        }

        private void cmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgvDisplay.Items.Clear();
            List<Project> ls = Project.prList;
            Project pr = new();

            if (cmbFilter.SelectedIndex == 0)
            {
                ls = Project.prList;
            }else if (cmbFilter.SelectedIndex == 1)
            {
                pr = pr["P101"];
                dgvDisplay.Items.Add(pr);

            }
            else if (cmbFilter.SelectedIndex == 2)
            {
                ls = Project.Completed();
            }else if (cmbFilter.SelectedIndex == 3)
            {
               // ls = Project.MoreThanSixWeeks();
            }else if (cmbFilter.SelectedIndex == 4)
            {
               // ls = Project.BetweenDates(Convert.ToDateTime("06-05-2023"), Convert.ToDateTime("16-06-2023"));
            }

            foreach (Project p in ls)
            {
                dgvDisplay.Items.Add(p);
            }
        }
    }
}
