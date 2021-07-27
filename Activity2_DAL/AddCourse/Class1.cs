using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Activity2_DAL
{

    public class Class1
    {

        SqlConnection sqlConObj = null;
        SqlCommand sqlCmdObj = null;
        public int GetAllCoursesDetails(string cid, string ctitle, int duration,string mode,out int rows)
        {
            sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString());
            sqlCmdObj = new SqlCommand("[dbo].[uspAddCourses]", sqlConObj);
            sqlCmdObj.CommandType = CommandType.StoredProcedure;
            sqlCmdObj.Parameters.AddWithValue("@CourseId", cid);
            sqlCmdObj.Parameters.AddWithValue("@CourseTitle", ctitle);
            sqlCmdObj.Parameters.AddWithValue("@CourseDuration", duration);
            sqlCmdObj.Parameters.AddWithValue("@CourseMode", mode);
            sqlCmdObj.Parameters.AddWithValue("@Curriculum", null);
            
            try
            {
                sqlConObj.Open();
                SqlParameter param = sqlCmdObj.Parameters.Add("ReturnValue", SqlDbType.Int);
                param.Direction = ParameterDirection.ReturnValue;
                rows = sqlCmdObj.ExecuteNonQuery();
                int results = (int)param.Value;
                return results;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops!!Something Happened!");
                rows = 0;
                return -99;
            }
            finally
            {
                sqlConObj.Close();
            }
        }
    }
}

