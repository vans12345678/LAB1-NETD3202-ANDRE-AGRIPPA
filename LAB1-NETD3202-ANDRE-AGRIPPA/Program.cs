//These are default (keep them!)
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
//keep the default namespace too, BillingApp is just the name of my project.
namespace LAB1_NETD3202_ANDRE_AGRIPPA
{
    public class Program
    {
        //First private data member
        private string projectName;
        private double budget;
        private double spent;
        private double hoursRemaining;
        private string status;
        //Complete the rest (there are four more mentioned in the description).
        //constructor, you need to complete it this is a no parameter constructor
        public Program()
        {
            
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
            get { return this.spent; }
            set { this.spent = value; }
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