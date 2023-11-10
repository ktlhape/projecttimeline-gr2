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
    /// Interaction logic for pgAssignProject.xaml
    /// </summary>
    public partial class pgAssignProject : Page
    {
        public pgAssignProject()
        {
            InitializeComponent();
            dgvEmployees.ItemsSource = Employee.AllEmployees();
            LoadProjects();
        }

        private void btnAssign_Click(object sender, RoutedEventArgs e)
        {
            int id = 100;
            string prCode = cmbProject.SelectedValue.ToString();
            DateTime assignmentDate = DateTime.Now;

            foreach (Employee em in dgvEmployees.SelectedItems)
            {
                string empNo = em.EmployeeNo;
                Assignment objAssign = new Assignment(id, prCode, empNo, assignmentDate);
                objAssign.AssignProject();
            }

        }
        public void LoadProjects()
        {
            DataContext = Project.AllProjects();
        }
    }
}
