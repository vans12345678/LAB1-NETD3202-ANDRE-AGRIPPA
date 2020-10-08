/*
 * Name: Andre Agrippa
 * Date: 10/02/2020
 * Course: NETD 3202
 * Purpose: Project Display window for project create. Displays selected user project.
 * File: winProjectDisplay.xaml.cs
 */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LAB1_NETD3202_ANDRE_AGRIPPA
{
    /// <summary>
    /// winProjectDisplay.xaml.cs window, opens when user double clicks project
    /// </summary>
    public partial class winProjectDisplay : Window
    {
        public ObservableCollection<Project> projects;
        public int selectedProject;
        public object sender;
        public winProjectDisplay(ObservableCollection<Project> projects, int selectedProject, object sender)
        {
            InitializeComponent();
            this.projects = projects;
            this.selectedProject = selectedProject;
            this.sender = sender;

            //create project based on passed in project
            Project project = projects[selectedProject];

            //Dispay project attributes
            txtProjectNameOut.Text = project.ProjectName;
            txtBudgetOut.Text = project.Budget.ToString();
            txtSpentOut.Text = project.Budget.ToString();
            txtHoursRemainingOut.Text = project.HoursRemaining.ToString();
            cmbStatusOut.SelectedIndex = project.Status;
        }

        //Called when the close button is clicked
        private void btnCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            //Will close the project dispay window
            this.Close();
        }

        private void btnAlter_Click(object sender, RoutedEventArgs e)
        {
            projects = ProjectCreate();
        }

        public ObservableCollection<Project> ProjectCreate()
        {
            //When this is clicked, sets the project attributes to user input

            //Temporary variables used for projects
            string projectName;
            double budget;
            double spent;
            double hoursRemaining;
            int status;

            status = cmbStatusOut.SelectedIndex;

            // If textbox project name is not empty
            if (txtProjectNameOut.Text.Trim() != string.Empty)
            {
                //Assign project name to entered text
                projects[selectedProject].ProjectName = txtProjectNameOut.Text;
                projectName = txtProjectNameOut.Text;

                //If textbox budget can be parsed to double budget
                if (double.TryParse(txtBudgetOut.Text.Trim(), out budget))
                {
                    //If textbox spent can be parsed to double spent
                    if (double.TryParse(txtSpentOut.Text.Trim(), out spent))
                    {
                        //If textbox hours remaining can be parsed to double hoursRemaining
                        if (double.TryParse(txtHoursRemainingOut.Text.Trim(), out hoursRemaining))
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
                                            cmbStatusOut.SelectedIndex = 5;
                                            status = cmbStatusOut.SelectedIndex;
                                        }

                                        //If combo box selected completed
                                        if (cmbStatusOut.SelectedIndex == 5)
                                        {
                                            //make hours remaining = 0 and change text to 0
                                            hoursRemaining = 0;
                                            txtHoursRemainingOut.Text = hoursRemaining.ToString();
                                        }

                                        //Add to the project list, clear listbox projects items
                                        projects[selectedProject] = new Project(projectName, budget, spent, hoursRemaining, status);
                                        // lsbProjects.Items.Clear();

                                        //Add the project name to list box
                                        // for (int i = 0; i < projects.Count; i++)
                                        // {
                                        //     lsbProjects.Items.Add(projects[i].ProjectName);
                                        // }

                                    }
                                    //If hours remaining is negative
                                    else
                                    {
                                        MessageBox.Show("Hours remaining must be a numeric entry greater than 0");
                                        txtHoursRemainingOut.SelectAll();
                                        txtHoursRemainingOut.Focus();
                                    }
                                }
                                //If spent is less than 0
                                else
                                {
                                    MessageBox.Show("Spent remaining must be a numeric entry greater than 0");
                                    txtSpentOut.SelectAll();
                                    txtSpentOut.Focus();
                                }
                            }
                            else
                            {
                                //If budget is less than 0
                                MessageBox.Show("Budget must be a numeric entry greater than 0");
                                txtBudgetOut.SelectAll();
                                txtBudgetOut.Focus();
                            }
                        }
                        else
                        {
                            //Hours string or empty
                            MessageBox.Show("Hours remaining cannot be a string/empty");
                            txtHoursRemainingOut.SelectAll();
                            txtHoursRemainingOut.Focus();
                        }
                    }
                    else
                    {
                        //Spent is string or empty
                        MessageBox.Show("Spent cannot be a string/empty");
                        txtSpentOut.SelectAll();
                        txtSpentOut.Focus();
                    }
                }
                else
                {
                    //Budget is string or empty
                    MessageBox.Show("Budget cannot be a string/empty");
                    txtBudgetOut.SelectAll();
                    txtBudgetOut.Focus();
                }
            }
            else
            {
                //Project string empty
                MessageBox.Show("Project name cannot be empty");
                txtProjectNameOut.SelectAll();
                txtProjectNameOut.Focus();
            }
            CollectionViewSource.GetDefaultView(projects).Refresh();

            return projects;
        }

    }
}
