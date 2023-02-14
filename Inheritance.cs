using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace InheritanceAssignment
{
    class Person
    {
        public int id;
        public string name;
        public string address;
        public long phone;
        public void getPersonInfo()
        {
            Console.WriteLine("Enter the id, name, address, phone");
            id = Convert.ToInt32(Console.ReadLine());
            name = Console.ReadLine();
            address = Console.ReadLine();
            phone = Convert.ToInt64(Console.ReadLine());
        }
    }
    class Student : Person
    {
        public string classs;
        public int marks;
        public string grade;
        public double fees;

        public void getStudentInfo()
        {
            Console.WriteLine("Enter the classs, marks, grade, fees");
            classs = Console.ReadLine();
            marks = Convert.ToInt32(Console.ReadLine());
            grade = Console.ReadLine();
            fees = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Student details");
            Console.WriteLine($"Id = {id} \n Name = {name} \n Address = {address} \n Phone = {phone} \n Classs = {classs} \n Fees = {fees}");
        }
    }
    class Staff : Person
    {
        public string designation;
        public double salary;
        public void getStaffInfo()
        {
            Console.WriteLine("Enter the designation, salary");
            designation = Console.ReadLine();
            salary = Convert.ToDouble(Console.ReadLine());
        }
    }
    class TeachingStaff : Staff 
    {
        public string qualification;
        public string subject;
        public void getTeachingStaffInfo()
        {
            Console.WriteLine("Enter the qualification, subject");
            qualification = Console.ReadLine();
            subject = Console.ReadLine();
            Console.WriteLine("TeachingStaff details");
            Console.WriteLine($"Id = {id} \n Name = {name} \n Address = {address} \n Phone = {phone} \n Designation = {designation} \n Salary = {salary} \n Qualification = {qualification} \n Subject = {subject}");
         }

    }
    class NonTeachingStaff : Staff
    {
        public string deptName;
        public int managerId;
        public void getNonTeachingStaffInfo()
        {
            Console.WriteLine("Enter the deptName, ManagerId");
            deptName = Console.ReadLine();
            managerId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("NonTeachingStaff details");
            Console.WriteLine($"Id = {id} \n Name = {name} \n Address = {address} \n Phone = {phone} \n Designation = {designation} \n Salary = {salary} \n DeptName = {deptName} \n ManagerId = {managerId}");
        }
        static void Main(string[] args)
        {
            
            Student student = new Student();
            student.getPersonInfo();
            student.getStudentInfo();
            TeachingStaff ts = new TeachingStaff();
            ts.getPersonInfo();
            ts.getStaffInfo();
            ts.getTeachingStaffInfo();
            NonTeachingStaff nts = new NonTeachingStaff();
            nts.getPersonInfo();
            nts.getStaffInfo();
            nts.getNonTeachingStaffInfo();

        }
    }
}


