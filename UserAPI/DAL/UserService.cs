using MySql.Data.MySqlClient;
using System.Data;
using UserAPI.Model;

namespace UserAPI.DAL
{
    public class UserService :IUserService
    {
        private readonly string str;
        public UserService()
        {
            str = "server=localhost;port=3306;uid=root;pwd=sobiazafar@2023;database=mvc_crud";
        }

        public User AddUuser(User user)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(str))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "insert into user_microserves (username,address) values(_username,_address)";
                        cmd.Parameters.AddWithValue("_username", user.UserName);
                        cmd.Parameters.AddWithValue("_address", user.Address);
                        cmd.ExecuteNonQuery();


                        using (MySqlCommand cmd1 = new MySqlCommand())
                        {
                            MySqlDataReader dr;
                            DataTable tbl = new DataTable();
                            cmd1.Connection = conn;
                            cmd1.CommandType = CommandType.Text;
                            cmd1.CommandText = "select * from user_microserves";
                            dr = cmd.ExecuteReader();
                            conn.Close();
                            tbl.Load(dr);
                            User obj = new User();
                            foreach (DataRow row in tbl.Rows)
                            {
                                new User
                                {
                                    UserId = (int)row["uid"],
                                    UserName = row["username"].ToString(),
                                    Address = row["address"].ToString()

                                };
                            }
                            return obj;
                        }



                    }
                  
                }
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        public bool DeleteUser(int id)
        {
            using(MySqlConnection conn=new MySqlConnection(str))
            {
                conn.Open();
                using(MySqlCommand cmd=new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText= "Delete from user_microserves where uid=_uid";
                    cmd.Parameters.AddWithValue("_uid", id);
                   int result= cmd.ExecuteNonQuery();
                    conn.Close();
                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
               
            }
        }

        public User GetUserByID(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(str))
            {
                conn.Open();
                DataTable tbl = new DataTable();
                MySqlDataReader dr;
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from user_microserves where uid=_uid";
                    cmd.Parameters.AddWithValue("_uid", id);
                    dr = cmd.ExecuteReader();
                    conn.Close();
                    tbl.Load(dr);                  
                    User obj = new User();
                    foreach (DataRow row in tbl.Rows)
                    {
                        new User
                        {
                            UserId = (int)row["uid"],
                            UserName = row["username"].ToString(),
                            Address = row["address"].ToString()

                        };                     
                    }
                    return obj;
                }
                
            }
        }

        public IEnumerable<User> GetUSerList()
        {
           using(MySqlConnection conn =new MySqlConnection(str))
            {
                conn.Open();
                DataTable tbl = new DataTable();
                MySqlDataReader dr;
                using(MySqlCommand cmd=new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType=CommandType.Text;
                    cmd.CommandText = "select * from user_microserves";
                    dr = cmd.ExecuteReader();
                    conn.Close();
                    tbl.Load(dr);
                    List<User> userlist = new List<User>();
                    User obj = new User();
                    foreach (DataRow row in tbl.Rows)
                    {
                        new User
                        {
                            UserId =(int)row["uid"],
                            UserName = row["username"].ToString(),
                            Address = row["address"].ToString()
                            
                        };
                        userlist.Add(obj);
                    }
                    return userlist;
                }
            }
        }

        public User UpdateUuser(User user)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(str))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "update user_microserves set username=_userame ,address=_address where uid=_uid";
                        cmd.Parameters.AddWithValue("_userame", user.UserName);
                        cmd.Parameters.AddWithValue("_address", user.Address);
                        cmd.Parameters.AddWithValue("_uid", user.UserId);
                        cmd.ExecuteNonQuery();



                        using (MySqlCommand cmd2 = new MySqlCommand())
                        {
                            DataTable tbl = new DataTable();
                            MySqlDataReader dr;
                            cmd.Connection = conn;
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "select * from user_microserves";
                            dr = cmd.ExecuteReader();
                            conn.Close();
                            tbl.Load(dr);

                            User obj = new User();
                            foreach (DataRow row in tbl.Rows)
                            {
                                new User
                                {
                                    UserId = (int)row["uid"],
                                    UserName = row["username"].ToString(),
                                    Address = row["address"].ToString()

                                };

                            }
                            return obj; ;

                        }

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
