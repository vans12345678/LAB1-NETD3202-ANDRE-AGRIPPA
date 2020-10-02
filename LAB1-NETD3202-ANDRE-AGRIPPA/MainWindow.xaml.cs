using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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

namespace LAB1_NETD3202_ANDRE_AGRIPPA
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

        private static List<Project> projects = new List <Project>();
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            string projectName;
            double budget;
            double spent;
            double hoursRemaining;
            string status;

            status = cmbStatus.Text;

            if (txtProjectName.Text.Trim() != string.Empty)
            {
                projectName = txtProjectName.Text;

                if (double.TryParse(txtBudget.Text.Trim(), out budget))
                {
                    if (double.TryParse(txtSpent.Text.Trim(), out spent))
                    {
                        if (double.TryParse(txtHoursRemaining.Text.Trim(), out hoursRemaining))
                        {
                            //everything is able to parse, make sure no negative numbers
                            if (budget >= 0)
                            {
                                if (spent >= 0)
                                {
                                    if (hoursRemaining >= 0)
                                    {
                                        //Everything valid
                                        if (hoursRemaining == 0)
                                        {
                                            //make cmb equal to completed
                                            cmbStatus.SelectedIndex = 5;
                                            status = cmbStatus.Text;
                                        }

                                        projects.Add(new Project(projectName, budget, spent, hoursRemaining, status));
                                        lsbProjects.Items.Clear();

                                        for (int i = 0; i < projects.Count; i++)
                                        {
                                            lsbProjects.Items.Add(projects[i].ProjectName);
                                        }
                                    }
                                    //If hours remaining is negative
                                    else
                                    {
                                        MessageBox.Show("Hours remaining must be a numeric entry greater than 0");
                                        txtHoursRemaining.SelectAll();
                                        txtHoursRemaining.Focus();
                                    }
                                }
                                //If spent is less than 0
                                else
                                {
                                    MessageBox.Show("Spent remaining must be a numeric entry greater than 0");
                                    txtSpent.SelectAll();
                                    txtSpent.Focus();
                                }
                            }
                            
                            else
                            {
                                //If budget is less than 0
                                MessageBox.Show("Budget must be a numeric entry greater than 0");
                                txtBudget.SelectAll();
                                txtBudget.Focus();
                            }
                        }
                        else
                        {
                            //Hours string or empty
                            MessageBox.Show("Hours remaining cannot be a string/empty");
                            txtHoursRemaining.SelectAll();
                            txtHoursRemaining.Focus();
                        }
                    }
                    else
                    {
                        //Spent is string or empty
                        MessageBox.Show("Spent cannot be a string/empty");
                        txtSpent.SelectAll();
                        txtSpent.Focus();
                    }
                }
                else
                {
                    //Budget is string or empty
                    MessageBox.Show("Budget cannot be a string/empty");
                    txtBudget.SelectAll();
                    txtBudget.Focus();
                }
            }
            else
            {
                //Project string empty
                MessageBox.Show("Project name cannot be empty");
                txtProjectName.SelectAll();
                txtProjectName.Focus();
            }
            
        }//End button click
    }//End class
}//End namespace
