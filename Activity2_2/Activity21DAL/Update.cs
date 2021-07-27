using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Activity21DAL
{
    public class Update
    {
        SqlConnection sqlConObj;
        SqlCommand sqlCmdObj;
        public int InsertIntoFaculty(string Psno, string Email, string Name)
        {

            try
            {
                sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectX"].ToString());
                

                sqlCmdObj = new SqlCommand(@"insert into dbo.Faculty values(@PSNO,@emailId,@facultyName)", sqlConObj);
                sqlCmdObj.Parameters.AddWithValue("@PSNO", Psno);
                sqlCmdObj.Parameters.AddWithValue("@emailId", Email);
                sqlCmdObj.Parameters.AddWithValue("@facultyName", Name);
                sqlConObj.Open();
                sqlCmdObj.ExecuteReader();
                
                Console.WriteLine("Faculty added");
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong");
                Console.WriteLine("Error Message: {0}", ex.Message);
                return -99;
            }
            finally
            {
                
                sqlConObj.Close();
            }

        }
    }
}
