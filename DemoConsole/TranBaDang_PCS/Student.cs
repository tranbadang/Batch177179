using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsole.TranBaDang_PCS
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double GPA { get; set; }

        public (int id, string name, double gpa) GetStudentInfo()
        {
            return (ID,Name,GPA) ;
        }

    }
}
