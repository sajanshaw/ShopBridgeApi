using ShopBridge.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace ShopBridge.Core
{
    public class ProductCore : IProductCore
    {
        public DataTable DoFetchProductDetails(string connString)
        {
            DataTable objProductList = new DataTable();
            string sqlQuery = "SELECT * FROM InventoryItem";
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    SqlCommand command = new SqlCommand(sqlQuery, connection);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        objProductList.Load(reader);
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return objProductList;
        }

        public int DoAddProduct(string connString, ProductModel productItem)
        {
            int Result = 0;
            SqlConnection sqlCon = null;
            try
            {
                using (sqlCon = new SqlConnection(connString))
                {
                    sqlCon.Open();
                    SqlCommand Cmnd = new SqlCommand("SB_AddProduct", sqlCon);
                    Cmnd.CommandType = CommandType.StoredProcedure;
                    Cmnd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = productItem.ID;
                    Cmnd.Parameters.AddWithValue("@NAME", SqlDbType.NVarChar).Value = productItem.Name;
                    Cmnd.Parameters.AddWithValue("@Description", SqlDbType.NVarChar).Value = productItem.Description;
                    Cmnd.Parameters.AddWithValue("@Price", SqlDbType.Decimal).Value = productItem.Price;
                    Cmnd.Parameters.AddWithValue("@InStock", SqlDbType.Int).Value = productItem.InStock;
                    Result = Cmnd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return Result;

        }

        public int DoUpdateProduct(string connString, ProductModel productItem)
        {
            int Result=0;
            SqlConnection sqlCon = null;
            try
            {
                using (sqlCon = new SqlConnection(connString))
                {
                    sqlCon.Open();
                    SqlCommand Cmnd = new SqlCommand("SB_UpdateProduct", sqlCon);
                    Cmnd.CommandType = CommandType.StoredProcedure;
                    Cmnd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = productItem.ID;
                    Cmnd.Parameters.AddWithValue("@NAME", SqlDbType.NVarChar).Value = productItem.Name;
                    Cmnd.Parameters.AddWithValue("@Description", SqlDbType.NVarChar).Value = productItem.Description;
                    Cmnd.Parameters.AddWithValue("@Price", SqlDbType.Decimal).Value = productItem.Price;
                    Cmnd.Parameters.AddWithValue("@InStock", SqlDbType.Int).Value = productItem.InStock;
                    Result = Cmnd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return Result;
        }

        public int DeleteProductByID(string connString, int productID)
        {
            int Result = 0;
            try
            {
                SqlConnection sqlCon = null;
                using (sqlCon = new SqlConnection(connString))
                {
                    sqlCon.Open();
                    SqlCommand Cmnd = new SqlCommand("SB_DeleteProductByID", sqlCon);
                    Cmnd.CommandType = CommandType.StoredProcedure;
                    Cmnd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = productID;
                    Result = Cmnd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return Result;
        }
    }
}
