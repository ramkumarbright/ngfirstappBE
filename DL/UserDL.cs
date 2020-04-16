using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace FirstAppServices
{
    public class UserDL
    {

        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["con"].ToString();

        public int AddUser(Users user)
        {
            int res = -1;
            try
            {
                using (SqlConnection cn = new SqlConnection(conn))
                {

                    string qry = "insert into [user](FirstName,LastName,Email,Phone,Password) values( @FirstName, @LastName, @Email, @Phone, @Password) SELECT SCOPE_IDENTITY();";

                    SqlCommand cmd = new SqlCommand(qry, cn);

                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", user.FirstName);
                    cmd.Parameters.AddWithValue("@Email", user.FirstName);
                    cmd.Parameters.AddWithValue("@Phone", user.FirstName);
                    cmd.Parameters.AddWithValue("@Password", user.FirstName);

                    cmd.Parameters["UserId"].Direction = System.Data.ParameterDirection.Output;

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    res = (int)cmd.Parameters["UserId"].Value;
                    cn.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return res;
        }
    }
}