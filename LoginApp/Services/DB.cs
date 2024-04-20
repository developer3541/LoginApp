using LoginApp.Models;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LoginApp.Services
{
    public class DB
    {
        public static DataTable LogIn(Signin signin)
        {
            string conn = "Data Source=(localdb)\\MSSQLLocalDB;Database=premier;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
            DataTable dt = new DataTable("AppUsers");
            using (SqlConnection _con = new SqlConnection(conn))
            {
                string queryStatement = $"SELECT * FROM dbo.AppUsers WHERE UserName = '{signin.Email}'";

                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                {

                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

                    _con.Open();
                    _dap.Fill(dt);
                    _con.Close();

                }
            }

            return dt;

        }
        public static bool Register(Register register)
        {
            bool result = false;
            string conn = "Data Source=(localdb)\\MSSQLLocalDB;Database=premier;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
            using (SqlConnection _con = new SqlConnection(conn))
            {
                string queryStatement = $"INSERT into dbo.AppUsers (FirstName,LastName,UserName,Email,PasswordHash,Gender,DOB,EducationLevel) VALUES ('{register.FirstName}','{register.LastName}','{register.Username}','{register.Email}','{register.Password}','{register.Gender}','{register.DOB}','{register.EducationLevel}')";

                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                {
                    try
                    {
                        _con.Open();
                        int r = _cmd.ExecuteNonQuery();
                        if (r == 1)
                        {
                            result = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        result = false;
                    }
                    finally
                    {
                        _con.Close();
                    }

                }
            }

            return result;

        }
    }
}
