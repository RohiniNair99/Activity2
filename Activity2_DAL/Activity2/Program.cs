using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Activity2_DAL;

namespace Activity2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****************************  FACULTY  **************************");
            AddFaculty faculty = new AddFaculty();
            //var result=course.ExecuteuspAddCourse("ILSWTTI170", "PYTHON ESSENTIALS", 8, "HANDS ON");
            string result = faculty.ExecuteuspAddFaculty("F118", "rajiv@ltts.com", "Rajiv Sinha");
            Console.WriteLine(result);
            Console.WriteLine("*****************************  COURSES  **************************");
            int rows;
            int rows1;
            Class1 obj = new Class1();
            int result2 = (obj.GetAllCoursesDetails("ILSWTTI155", "Software", 85, "Hands on", out rows));
            // int result1 = (obj.DeleteCourse("ILSWTTI105", out rows));
            Console.WriteLine($"Value=" + result);
            Console.WriteLine(rows + " Rows Affected");
            Console.WriteLine("\n");
            Console.ReadLine();

        }
    }
}
