/*
 * Name: Andre Agrippa
 * Date: 10/02/2020
 * Course: NETD 3202
 * Purpose: Project class, has all the attrivutes, getters and setters.
 * File: Project.cs
 */
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace LAB1_NETD3202_ANDRE_AGRIPPA
{
    public class Project
    {
        //Private data members for a Project
        private string projectName;
        private double budget;
        private double amountSpent;
        private double hoursRemaining;
        private int projectStatus;
        
        //Pass in attributes to class Project
        public Project(string projectName, double budget, double amountSpent, double hoursRemaining, int projectStatus)
        {
            this.projectName = projectName;
            this.budget = budget;
            this.amountSpent = amountSpent;
            this.hoursRemaining = hoursRemaining;
            this.projectStatus = projectStatus;
        }
        //Getters and setters for Project Name
        public string ProjectName
        {
            get { return this.projectName; }
            set { this.projectName = value; }

        }
        //Getters and setters for Budget
        public double Budget
        {
            get { return this.budget; }
            set { this.budget = value; }
        }
        //Getters and setters for Spent
        public double Spent
        {
            get { return this.amountSpent; }
            set { this.amountSpent = value; }
        }
        //Getters and setters for HoursRemaining
        public double HoursRemaining
        {
            get { return this.hoursRemaining; }
            set { this.hoursRemaining = value; }
        }
        //Getters and setters for Status
        public int Status
        {
            get { return this.projectStatus; }
            set { this.projectStatus = value; }
        }
    }
}