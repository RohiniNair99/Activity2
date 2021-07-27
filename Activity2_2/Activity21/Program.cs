using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Activity21DAL;

namespace Activity21
{
    class Program
    {
        static void Main(string[] args)
        {
            Update faculty = new Update();
            faculty.InsertIntoFaculty("PS120", "Ruchi@ltts.com", "Ruchi Verma");
            Console.ReadLine();
            
        }
    }
}
