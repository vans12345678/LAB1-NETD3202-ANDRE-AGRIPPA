/*
 * Name: Andre Agrippa
 * Date: 10/02/2020
 * Course: NETD 3202
 * Purpose: Main window for project create. Validates user input and makes an entry for a project.
 */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// MainWindow.xaml.cs window, opens when application first starts
    /// </summary>
    public partial class MainWindow : Window
    {
        //Initialize MainWindow
        public MainWindow()
        {
            InitializeComponent();
            lsbProjects.ItemsSource = projects;
        }

        //Create a new list of object project
        public ObservableCollection <Project> projects = new ObservableCollection <Project>();

        //Called when user double clicks the create button
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            projects = ProjectCreate();
            ClearText();


        }//End button click

        //For when the user double clicks on a project in the list box
        private void lsbProjects_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Get index of project selected and pass that project to a new window
            int selectedIndex = lsbProjects.SelectedIndex;

            winProjectDisplay newWindowDisplay = new winProjectDisplay(projects, selectedIndex, sender);
            newWindowDisplay.Show();

        }

        //VAldiates and creates an entry in the observable collection
        public ObservableCollection<Project> ProjectCreate()
        {
            //Temporary variables used for projects
            string projectName;
            double budget;
            double spent;
            double hoursRemaining;
            int status;

            //status is equal to whatever user selected from combo box
            status = cmbStatus.SelectedIndex;

            //If textbox project name is not empty
            if (txtProjectName.Text.Trim() != string.Empty)
            {
                //Assign project name to entered text
                projectName = txtProjectName.Text;

                //If textbox budget can be parsed to double budget
                if (double.TryParse(txtBudget.Text.Trim(), out budget))
                {
                    //If textbox spent can be parsed to double spent
                    if (double.TryParse(txtSpent.Text.Trim(), out spent))
                    {
                        //If textbox hours remaining can be parsed to double hoursRemaining
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
                                        //If hours remaining is 0
                                        if (hoursRemaining == 0)
                                        {
                                            //Make combo box completed, assign index number
                                            cmbStatus.SelectedIndex = 5;
                                            status = cmbStatus.SelectedIndex;
                                        }

                                        //If combo box selected completed
                                        if (cmbStatus.SelectedIndex == 5)
                                        {
                                            //make hours remaining = 0 and change text to 0
                                            hoursRemaining = 0;
                                            txtHoursRemaining.Text = hoursRemaining.ToString();
                                        }

                                        //Add to the project list, clear listbox projects items
                                        projects.Add(new Project(projectName, budget, spent, hoursRemaining, status));
                                        //lsbProjects.Items.Clear();

                                        //Add the project name to list box
                                        // for (int i = 0; i < projects.Count; i++)
                                        // {
                                            //lsbProjects.Items.Add(projects[i].ProjectName);
                                        //}

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

            //Returns a valid project entry
            return projects;

        }//End ProjectCreate
        //Clears all text fields
        public void ClearText()
        {
            txtHoursRemaining.Text = "";
            txtBudget.Text = "";
            txtSpent.Text = "";
            txtProjectName.Text = "";
        }

    }//End class
}//End namespace
