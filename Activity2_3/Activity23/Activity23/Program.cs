using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Activity2_3DAL;

namespace Activity23
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows;
            InsertUsingAdapter obj = new InsertUsingAdapter();
            int result=obj.InsertIntoFaculty("A102", "roh@gmail.com", "Rohini Nair", out rows);
            Console.WriteLine("Result: " + result + "\tRows Affected: " + rows);
            Console.ReadLine();

        }
    }
}
