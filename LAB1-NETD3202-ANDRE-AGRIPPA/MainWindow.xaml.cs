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

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            string projectName;
            double budget;
            double spent;
            double hoursRemaining;
            string status;

            if (txtProjectName.Text.Trim() != string.Empty)
            {
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
                                    if (hoursRemaining > 0)
                                    {

                                    }
                                    else if (hoursRemaining == 0)
                                    {
                                        //make cmb equal to completed
                                        cmbStatus.SelectedIndex = 5;
                                    }
                                    //If hours remaining is negative
                                    else
                                    {
                                        MessageBox.Show("Hours remaining must be a numeric entry greater than 0");
                                        txtHoursRemaining.Text = "";
                                        txtHoursRemaining.SelectAll();
                                    }
                                }
                                //If spent is less than 0
                                else
                                {
                                    MessageBox.Show("Spent remaining must be a numeric entry greater than 0");
                                    txtSpent.Text = "";
                                    txtSpent.SelectAll();
                                }
                            }
                            //If budget is less than 0
                            else
                            {
                                MessageBox.Show("Budget remaining must be a numeric entry greater than 0");
                                txtBudget.Text = "";
                                txtBudget.SelectAll();

                            }
                        }
                        else
                        {
                            //Hours not numeric
                            MessageBox.Show("Hours remaining cannot be a string");
                            txtHoursRemaining.Text = "";
                            txtHoursRemaining.SelectAll();
                        }
                    }
                    else
                    {
                        //Spent not numeric
                        MessageBox.Show("Spent cannot be a empty");
                        txtSpent.Text = "";
                        txtSpent.SelectAll();
                    }
                }
                else
                {
                    MessageBox.Show("Budget remaining cannot be empty");
                    txtBudget.Text = "";
                    txtBudget.SelectAll();
                }
            }
            else
            {
                //Project string empty
                MessageBox.Show("Project name cannot be empty");
                txtProjectName.Text = "";
                txtProjectName.SelectAll();
            }
            
        }//End button click
    }//End class
}//End namespace
