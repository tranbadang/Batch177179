using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsole.ClassAndMethod
{
    public class PrintAndMethod
    {
        void Print(string mess)
        {
            Console.WriteLine(mess);
        }
        public void Run()
        {
            string notication = "Hello World";
            //Cach 1
            Print(notication);
            //Cach 2
            PrintAndMethod print = new PrintAndMethod();
            print.Print(notication);

        }
    }
}
