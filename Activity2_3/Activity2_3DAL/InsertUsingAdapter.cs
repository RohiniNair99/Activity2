using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Activity2_3DAL
{
    public class InsertUsingAdapter
    {
        public int InsertIntoFaculty(string PSNO, string email, string facultyName, out int rowAffected)
        {
            SqlDataAdapter da = new SqlDataAdapter(); ;
            DataTable dataTable = new DataTable();
            SqlConnection SqlConObj = new SqlConnection( ConfigurationManager.ConnectionStrings["ConnectX"].ToString());
            SqlCommand SqlCmdObj = new SqlCommand("dbo.uspInsertFaculty", SqlConObj);
            SqlCmdObj.CommandType = CommandType.StoredProcedure;
            SqlCmdObj.Parameters.AddWithValue("@PSNo", PSNO);
            SqlCmdObj.Parameters.AddWithValue("@emailId", email);
            SqlCmdObj.Parameters.AddWithValue("@facultyName", facultyName);
            try
            {
                SqlParameter rm = SqlCmdObj.Parameters.Add("ReturnValue", SqlDbType.Int);
                rm.Direction = ParameterDirection.ReturnValue;
                da.SelectCommand = SqlCmdObj;
                da.Fill(dataTable);
                int returnValue = (int)rm.Value;
                rowAffected = da.Update(dataTable);
                return returnValue;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went Wrong !");
                rowAffected = 0;
                return 0;
            }

        }
    }
}
