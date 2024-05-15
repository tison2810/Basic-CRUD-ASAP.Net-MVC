using System.Data.SqlClient;
using System.Data;
using SEIntern.Models;
public class OrderDataAccessLayer
{
    private string connectionString;
    private readonly IConfiguration _configuration; // Add this line

    public OrderDataAccessLayer(IConfiguration configuration) // Modify this line
    {
        _configuration = configuration; // Add this line
        connectionString = _configuration.GetConnectionString("DefaultConnection"); // Modify this line
    }

    public IEnumerable<Order> GetAllOrder()
    {
        List<Order> lstOrder = new List<Order>();
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("spGetAllOrder", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Order order = new Order();
                order.ProductID = rdr["ProductID"].ToString();
                order.SalesOrder = rdr["SalesOrder"].ToString();
                order.SalesOrderItem = rdr["SalesOrderItem"].ToString();
                order.WorkOrder = rdr["WorkOrder"].ToString();
                order.ProductDescription = rdr["ProductDescription"].ToString();
                order.OrderQuantity = Convert.ToDecimal(rdr["OrderQuantity"]);
                order.OrderStatus = rdr["OrderStatus"].ToString();
                order.Timestamp = Convert.ToDateTime(rdr["Timestamp"]);

                lstOrder.Add(order);
            }
            con.Close();
        }
        return lstOrder;
    }
    public void AddOrder(Order order)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("spAddOrder", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ProductID", order.ProductID);
            cmd.Parameters.AddWithValue("@SalesOrder", order.SalesOrder);
            cmd.Parameters.AddWithValue("@SalesOrderItem", order.SalesOrderItem);
            cmd.Parameters.AddWithValue("@WorkOrder", order.WorkOrder);
            cmd.Parameters.AddWithValue("@ProductDescription", order.ProductDescription);
            cmd.Parameters.AddWithValue("@OrderQuantity", order.OrderQuantity);
            cmd.Parameters.AddWithValue("@OrderStatus", order.OrderStatus);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }

    public void UpdateOrder(Order order)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("spUpdateOrder", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ProductID", order.ProductID);
            cmd.Parameters.AddWithValue("@SalesOrder", order.SalesOrder);
            cmd.Parameters.AddWithValue("@SalesOrderItem", order.SalesOrderItem);
            cmd.Parameters.AddWithValue("@WorkOrder", order.WorkOrder);
            cmd.Parameters.AddWithValue("@ProductDescription", order.ProductDescription);
            cmd.Parameters.AddWithValue("@OrderQuantity", order.OrderQuantity);
            cmd.Parameters.AddWithValue("@OrderStatus", order.OrderStatus);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }

    public Order GetOrderData(string WorkOrder)
    {
        Order order = new Order();

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            string sqlQuery = "SELECT * FROM tblOrder WHERE WorkOrder= '" + WorkOrder + "'";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                order.ProductID = rdr["ProductID"].ToString();
                order.SalesOrder = rdr["SalesOrder"].ToString();
                order.SalesOrderItem = rdr["SalesOrderItem"].ToString();
                order.WorkOrder = rdr["WorkOrder"].ToString();
                order.ProductDescription = rdr["ProductDescription"].ToString();
                order.OrderQuantity = Convert.ToDecimal(rdr["OrderQuantity"]);
                order.OrderStatus = rdr["OrderStatus"].ToString();
                order.Timestamp = Convert.ToDateTime(rdr["Timestamp"]);
            }
        }
        return order;
    }

    public void DeleteOrder(string WorkOrder)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("spDeleteOrder", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@WorkOrder", WorkOrder);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}