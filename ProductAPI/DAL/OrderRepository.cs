using MySql.Data.MySqlClient;
using ProductAPI.Model;
using System.Data;

namespace ProductAPI.DAL
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string str;
        public OrderRepository()
        {
            str = "server=localhost;port=3306;uid=root;pwd=sobiazafar@2023;database=mvc_crud";

        }
        public async Task<int> Add(Order order)
        {
            using (MySqlConnection conn = new MySqlConnection(str))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_order_mircoservice";
                    cmd.Parameters.AddWithValue("_ProductId", order.ProductId);
                    cmd.Parameters.AddWithValue("_Cost", order.Cost);
                    cmd.Parameters.AddWithValue("_Placed", order.Placed);
                    cmd.Parameters.AddWithValue("_CustomerId", order.CustomerId);
                    cmd.Parameters.AddWithValue("_Status", order.Status);

                    try
                    {
                       cmd.ExecuteNonQuery();
                        conn.Close();
                        return order.Id;
                    }
                    catch (NullReferenceException ex)
                    {
                        throw new NullReferenceException(ex.Message);
                    }

                }
            }


        }

        public async Task<string> Cancel(int id)
        {
            using (MySqlConnection con = new MySqlConnection(str))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update order_microservice set status='canceled' where id=@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    int rowaffect = cmd.ExecuteNonQuery();
                    if (rowaffect == 0)
                    {
                        return "order not found";
                    }
                    else
                    {
                        return "order canceled successfully";
                    }


                }
            }
        }

        public async Task<Order> GetByCustomerId(int customerId)
        {
            using (MySqlConnection conn = new MySqlConnection(str))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from order_microservice where id=@customerId";
                    cmd.Parameters.AddWithValue("@customerId", customerId);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    DataTable tbl = new DataTable();
                    tbl.Load(dr);
                    Order obj = new Order();
                    try
                    {
                        foreach (DataRow rows in tbl.Rows)
                        {
                            new Order
                            {
                                Id = (int)rows["id"],
                                ProductId = (string)rows["productid"],
                                Cost = (double)rows["cost"],
                                Placed = (DateTime)rows["placed"],
                                CustomerId = (int)rows["customerid"],
                                Status = (string)rows["status"]
                            };
                        }
                        return obj;
                    }
                    catch
                    {
                        throw;
                    }

                }
            }
        }

        public async Task<Order> GetById(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(str))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from order_microservice where id=@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    DataTable tbl = new DataTable();
                    tbl.Load(dr);
                    Order obj = new Order();
                    try
                    {
                        foreach (DataRow rows in tbl.Rows)
                        {
                            new Order
                            {
                                Id = (int)rows["id"],
                                ProductId = (string)rows["productid"],
                                Cost = (double)rows["cost"],
                                Placed = (DateTime)rows["placed"],
                                CustomerId = (int)rows["customerid"],
                                Status = (string)rows["status"]
                            };
                        }
                        return obj;
                    }
                    catch
                    {
                        throw;
                    }

                }
            }
        }

    }
}
