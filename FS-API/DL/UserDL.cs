using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace FS_API
{
    public class UserDL
    {

        public static List<Users> GetAllUsers(int? userid)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["con"].ToString();

            List<Users> obj = new List<Users>();

            try
            {
                using (SqlConnection cn = new SqlConnection(conn))
                {

                    string qry = "select UserId,FirstName,LastName,Email,Phone,Password from [User] where userid=@userid or @userid is null";

                    SqlCommand cmd = new SqlCommand(qry, cn);
                    if (userid.HasValue)
                        cmd.Parameters.AddWithValue("@userid", userid.Value);
                    else
                        cmd.Parameters.AddWithValue("@userid", DBNull.Value);


                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Users ob = new Users();
                        ob.UserId = Convert.ToInt32(dr["UserId"]);
                        ob.Phone = dr["Phone"].ToString();
                        ob.FirstName = dr["FirstName"].ToString();
                        ob.LastName = dr["LastName"].ToString();
                        ob.Email = dr["Email"].ToString();
                        //ob.Email = dr["Email"].ToString();
                        obj.Add(ob);
                    }

                    cn.Close();

                }
            }
            catch (Exception)
            {
                throw;
            }

            return obj;
        }

        public static int AddUser(Users user)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["con"].ToString();

            int res = -1;
            try
            {
                using (SqlConnection cn = new SqlConnection(conn))
                {

                    string qry = "insert into [user](FirstName,LastName,Email,Phone,Password) values( @FirstName, @LastName, @Email, @Phone, @Password) SELECT SCOPE_IDENTITY();";
                    // int userid = -1;
                    SqlCommand cmd = new SqlCommand(qry, cn);

                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Phone", user.Phone);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    //  cmd.Parameters.Add()

                    // cmd.Parameters["UserId"].Direction = System.Data.ParameterDirection.Output;

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    res = 1;
                    // res = (int)cmd.Parameters["UserId"].Value;
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