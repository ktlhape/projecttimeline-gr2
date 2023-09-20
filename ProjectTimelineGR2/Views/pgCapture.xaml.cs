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
    /// Interaction logic for pgCapture.xaml
    /// </summary>
    public partial class pgCapture : Page
    {
        DateTime semesterDate = Convert.ToDateTime("04-09-2023");

        public pgCapture()
        {
            InitializeComponent();
            dtpStartDate.DisplayDateStart = semesterDate;
            dtpStartDate.DisplayDateEnd = semesterDate.AddDays(50);

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string code, prName;
            double rate;
            DateTime start, end;

            try
            {
                code = txtCode.Text;
                prName = txtProjectName.Text;
                rate = Convert.ToDouble(txtRate.Text);
                start = dtpStartDate.SelectedDate.Value;
                end = dtpEndDate.SelectedDate.Value;

                Project p = new Project(code, prName, start, end,rate);

                Project.prList.Add(p);

                txtEstCost.Text = p.EstimatedCost.ToString("C2");
                txtDuration.Text = p.Duration.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, this.Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void txtCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtCode.Text.Trim().Length == 0)
            {
                btnSave.IsEnabled = false;
            }
            else
            {
                btnSave.IsEnabled = true;
            }
        }
    }
}
