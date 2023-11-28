using DemoConsole.ClassAndMethod;
using DemoConsole.PE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsole.TranBaDang_PCS
{
    public class StudentIn
    {
        public static void Main(string[] args)
        {
            // Question 1.1;

           /* Student student = new Student()
            {
                ID = 1,Name="Nguyen Van Smith", GPA= 9.5
            };
           */
            //Question 1.2:
            List<Student> list = new List<Student>() {
                new Student { ID=1, Name="Nguyen Van Smith", GPA=9.5} ,
                new Student { ID=2, Name="Tran Van David", GPA=6.4} ,
                new Student { ID=3, Name="Nguyen ngoc Hoang", GPA=7.0} ,
                new Student { ID=4, Name="Le Van Hoang", GPA= 8.0} ,
                new Student { ID=5, Name="Ly Dieu Smith", GPA=8.0} ,
            };
            // Question 1.3
            foreach (var item in list)
            {
                var studentInfo = item.GetStudentInfo();
                Console.WriteLine($"{studentInfo.id}-{studentInfo.name}-{studentInfo.gpa}");
            }
            //Question 2.1:
            var studentGPA = list.Where(p => p.GPA == 7);
            Console.WriteLine("1.\tFilter student GPA :");
            foreach (var item in studentGPA)
            {
                Console.WriteLine($"{item.ID,3}-{item.Name,20}-{item.GPA,15}");
            }
            //Question 2.2:
            var studentName = list.Where(p => p.Name.Contains("Hoang"));
            Console.WriteLine("2.\tFind student whose names contain the keyword \"Hoang\":");
            foreach (var item in studentName)
            {
                Console.WriteLine($"{item.ID,3}-{item.Name,20}-{item.GPA,15}");
            }
            //Question 2.3:
            var doctorOrderById = list.OrderByDescending(p => p.ID);
            Console.WriteLine("3.\tSort the student list in descending order by DoctorID:");
            foreach (var item in doctorOrderById)
            {
                Console.WriteLine($"{item.ID,3}-{item.Name,20}-{item.GPA,15}");
            }
            //Question 2.4:
            Student newStudent = new Student()
            {
                ID = 6,
                Name = "Ba Dang",
                GPA =  9.0,
            };
            list.Add(newStudent);
            //Question 2.5:
            Console.WriteLine("5.\tPrint the student list after performing the above operations");
            foreach (var item in list)
            {
                var studentInfo = item.GetStudentInfo();
                Console.WriteLine($"{studentInfo.id}-{studentInfo.name}-{studentInfo.gpa}");
            }
        }
    }
}
