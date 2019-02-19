using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vakantiedagen
{
    class Employee
    {
        private string personnelNumber;
        private string name;
        private DateTime dateOfBirth;
        private int leaveDays;
        private int serviceYearss;
        private int serviceYearsLimit;
        private int ageLimit;
        private int ageLimitExtra;
        private int department;

        public Employee(string personnelNumber, string name, DateTime dateOfBirth, int leaveDays, int serviceYears, int serviceYearsLimit, int ageLimit, int ageLimitExtra, int department)
        {
            this.personnelNumber = personnelNumber;
            this.name = name;
            this.dateOfBirth = dateOfBirth;
            this.leaveDays = leaveDays;
            this.serviceYearss = serviceYears;
            this.serviceYearsLimit = serviceYearsLimit;
            this.ageLimit = ageLimit;
            this.ageLimitExtra = ageLimitExtra;
            this.department = department;
        }

        public override string ToString()
        {
            return $"Personnel Number: {personnelNumber}, Name:{name}, Date of birth:{dateOfBirth}, leave days:{leaveDays}";
        }

        public string PersonnelNumber
        {
            get { return personnelNumber; }
            set { personnelNumber = value; }
        }

        public string Name
        {
            get { return name; }
        }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
        }

        public int LeaveDays
        {
            get { return leaveDays; }
            set { leaveDays = value; }
        }

        public int ServiceYears
        {
            get { return serviceYearss; }
        }

        public int ServiceYearsLimit
        {
            get { return serviceYearsLimit; }
            set { serviceYearsLimit = value; }
        }

        public int AgeLimit
        {
            get { return ageLimit; }
        }

        public int AgeLimitExtra
        {
            get { return ageLimitExtra; }
        }

        public int Department
        {
            get { return department; }
        }
    }
}
