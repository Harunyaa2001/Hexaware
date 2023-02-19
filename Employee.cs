using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace ConstructorandStaticMembers
{
    class Employee
    {
        public static int empId=1001;
        public static int nextEmployeeNumber;
        public DateTime dateOfBirth;
        public string[] dependents;
        public string employeeName;
        public string gender;
        public short numberOfDependents;
        static Employee()
        {
            nextEmployeeNumber = 1001;
        }
        public Employee()
        {
            nextEmployeeNumber = empId++;
            dependents = new string[3];
        }
        public Employee(string employeeName,DateTime dateOfBirth,string gender)
        {
            this.employeeName = employeeName;
            this.dateOfBirth = dateOfBirth;
            this.gender = gender;
        }
        Employee(string employeeName, DateTime dateOfBirth, string gender,short numberOfDependents)
        {
            this.employeeName = employeeName;
            this.dateOfBirth = dateOfBirth;
            this.gender = gender;
            if (numberOfDependents < 0)
            {
                this.numberOfDependents = 0;
            }
            if (numberOfDependents > 3)
            {
                this.numberOfDependents = 3;
            }
            else
            {
                this.numberOfDependents = numberOfDependents;
            }
        }
        public int AddDependent(string dependentName)
        {
            if (numberOfDependents == 3)
            {
                return 0;
            }
            else
            {
                dependents[numberOfDependents + 1] = dependentName;
                return numberOfDependents;
            }
        }
        public bool UpdateDependents(string dependentName,int dependentId)
        {
            if(dependentId<=3 && dependentId > 0)
            {
                dependents[dependentId - 1] = dependentName;
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            //string employeeName = Console.ReadLine();
            //string gender = Console.ReadLine();
            //short numberOfDependents = Convert.ToInt16(Console.ReadLine());
            DateTime dt = new DateTime(1997, 07, 09);
            Employee emp = new Employee("Harunyaa",dt,"Female");
            Employee emp1 = new Employee("Harunyaa", dt, "Female", 3);
            Console.WriteLine("Employee Name:" + emp.employeeName);
            Console.WriteLine("Date of birth:" + emp.dateOfBirth);
            Console.WriteLine("Employee Gender:" + emp.gender);
            Console.WriteLine("No.of.dependents:" + emp1.numberOfDependents);

        }
    }
}
