//These are default (keep them!)
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
//keep the default namespace too, BillingApp is just the name of my project.
namespace LAB1_NETD3202_ANDRE_AGRIPPA
{
    public class Project
    {
        //First private data member
        private string projectName;
        private double budget;
        private double amountSpent;
        private double hoursRemaining;
        private string projectStatus;
        //Complete the rest (there are four more mentioned in the description).
        //constructor, you need to complete it this is a no parameter constructor
        public Project(string projectName, double budget, double amountSpent, double hoursRemaining, string projectStatus)
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
            get { return this.HoursRemaining; }
            set { this.HoursRemaining = value; }
        }
        //Getters and setters for Status
        public double Status
        {
            get { return this.Status; }
            set { this.Status = value; }
        }

    }
}