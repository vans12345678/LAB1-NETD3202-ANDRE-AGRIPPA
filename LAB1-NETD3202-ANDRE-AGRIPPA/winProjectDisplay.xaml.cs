/*
 * Name: Andre Agrippa
 * Date: 10/02/2020
 * Course: NETD 3202
 * Purpose: Project Display window for project create. Displays selected user project.
 * File: winProjectDisplay.xaml.cs
 */
using System;
using System.Collections.Generic;
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
        public winProjectDisplay(Project selectedProject)
        {
            InitializeComponent();

            //create project based on passed in project
            Project project = selectedProject;

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
            //When this is clicked, sets the project attributes to user input
        }
    }
}
