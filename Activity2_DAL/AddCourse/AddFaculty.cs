using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Activity2_DAL
{
    public class AddFaculty
    {
        SqlConnection sqlConObj;
        public string ExecuteuspAddFaculty(string PSNO, string email,string name)
        {
            string Courseoutput = String.Empty;

            try
            {
                sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString());
                SqlCommand sqlCmdObj = new SqlCommand();
                sqlCmdObj.CommandText = "[dbo].[uspFacultyAdd]";
                sqlCmdObj.Connection = sqlConObj;
                sqlCmdObj.CommandType = CommandType.StoredProcedure;
                sqlCmdObj.Parameters.AddWithValue("@PSNO", PSNO);
                sqlCmdObj.Parameters.AddWithValue("@emailId", email);
                sqlCmdObj.Parameters.AddWithValue("@facultyName", name);
                

                sqlConObj.Open();
                int rowAffected = sqlCmdObj.ExecuteNonQuery();
                SqlParameter para = sqlCmdObj.Parameters.Add("ReturnValue", SqlDbType.Int);
                para.Direction = ParameterDirection.ReturnValue;
                int returnValue = (int)para.Value;
                Courseoutput = $"Rows Affected: {rowAffected} \nReturn Value: {returnValue}";
                return Courseoutput;
            }

            catch (Exception ex)
            {
                Console.WriteLine("Something Went wrong");
                return Courseoutput;

            }

            finally
            {
                sqlConObj.Close();
            }
        }
    }
}
