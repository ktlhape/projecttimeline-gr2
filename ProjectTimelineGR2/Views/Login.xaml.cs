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
using System.Windows.Shapes;

namespace ProjectTimelineGR2.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string empNo = txtEmpNo.Text;
            string pass = txtPassword.Password.ToString();

            Employee em = Employee.GetEmployee(empNo);
            if (em.EmployeeNo.Equals(empNo))
            {
                if (em.Password.Equals(pass))
                {
                    MainWindow main = new MainWindow();
                    main.Tag = em;
                    main.ShowDialog();
                }
                else
                {
                    MessageBox.Show($"Incorrect login details");
                }
               
            }
            else
            {
                MessageBox.Show($"Employee ({empNo}) not found!!!");

            }
        }
    }
}
