using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Vakantiedagen
{
    public partial class Form1 : Form
    {
        private Dictionary<int, Employee> employees;
        private int dep1LeaveDaysLimt;
        private int dep2LeaveDaysLimt;
        private int dep3LeaveDaysLimt;
        private int depLeaveDaysLimt;
        private int _leaveDaysTotal;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dep1LeaveDaysLimt = 24;
            dep2LeaveDaysLimt = 23;
            dep3LeaveDaysLimt = 22;
            depLeaveDaysLimt = 20;

            employees = new Dictionary<int, Employee>();

            employees.Add(1, new Employee("", "John Deer", Convert.ToDateTime("10/2/1990"), 0, 11, 0, 50, 55, 1));
            employees.Add(2, new Employee("", "John Dough", Convert.ToDateTime("18/2/1964"), 0, 9, 0, 50, 55, 2));

            foreach(KeyValuePair<int, Employee> entry in employees)
            {
                //sets employee personnel number "department + year + dictionary key"
                entry.Value.PersonnelNumber = entry.Value.Department.ToString() + entry.Value.DateOfBirth.Year.ToString() + entry.Key.ToString("00");
                entry.Value.ServiceYearsLimit = 10;

                switch (entry.Value.Department)
                {
                    case 1:
                        entry.Value.LeaveDays = dep1LeaveDaysLimt;
                        break;
                    case 2:
                        entry.Value.LeaveDays = dep2LeaveDaysLimt;
                        break;
                    case 3:
                        entry.Value.LeaveDays = dep3LeaveDaysLimt;
                        break;
                    case int d when (d <= 10 && d >= 4):
                        entry.Value.LeaveDays = depLeaveDaysLimt;
                        break;
                }
            }

            // Displays title property
            listBoxEmployees.DataSource = employees.Values.ToList();
            listBoxEmployees.DisplayMember = "Values";

            // Displays calculation, total
            labelTicketsTotal.Text = $@"Leave days = service + age50 + age55";
            labelPriceTotal.Text = $@"Total: {_leaveDaysTotal}";
        }

        private void ButtonCalculate_Click(object sender, EventArgs e)
        {
            Employee tempEmployee = (Employee)listBoxEmployees.SelectedItem;
            int ageEmployee = 0;
            int leaveDays10 = 0;
            int leaveDays50 = 0;
            int leaveDays55 = 0;
            _leaveDaysTotal = 0;

            // Checks if employee has more or equal service years than the limit
            if (tempEmployee.ServiceYears >= tempEmployee.ServiceYearsLimit)
            {
                leaveDays10 = 3;
                _leaveDaysTotal += tempEmployee.LeaveDays + leaveDays10;
            }

            ageEmployee = CalculateAge(tempEmployee.DateOfBirth);

            // Checks if employee is older than 50
            if (ageEmployee >= tempEmployee.AgeLimit)
            {
                leaveDays50 = 5;
                _leaveDaysTotal += tempEmployee.LeaveDays + leaveDays50;
            }

            // Checks if employee is older than 55
            if (ageEmployee >= tempEmployee.AgeLimitExtra)
            {
                leaveDays55 = (1 * (ageEmployee - (tempEmployee.AgeLimitExtra - 1)));
                _leaveDaysTotal +=  leaveDays55;
            }

            // Displays calculation, total
            labelTicketsTotal.Text = $@"Leave days = service {leaveDays10} + age {leaveDays50} + age {leaveDays55}";
            labelPriceTotal.Text = $@"Total: {_leaveDaysTotal}";
        }

        private static int CalculateAge(DateTime dateOfBirth)
        {
            int age = DateTime.Now.Year - dateOfBirth.Year;  
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)  
                age = age - 1;  
  
            return age; 
        }
    }
}
