using HWSBot.ServiceModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;

namespace HWSBot.Repositories
{
    public class RedditRepository
    {
        string connectionString = "Data Source=DESKTOP-G3VPCBF;Initial Catalog=HardwareSwap;Integrated Security=True";

        public List<Post> GetAllItemDetail(string request, string sproc)
        {
            List<Post> itemDetailList;
            Post item;
            itemDetailList = new List<Post>();
            SqlConnection myConnection = new SqlConnection(connectionString);

            SqlCommand myCommand = new SqlCommand(sproc, myConnection);
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@SearchTerm", request);                    
            myConnection.Open();

            var reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                item = new Post();

                item.Author = reader["Name"] as string;
                item.Date = reader["Date"] as string;
                item.Item = reader["Items"] as string; 
                item.Price = reader["Price"] as string;
                item.Url = reader["Url"] as string;
                item.Text = reader["Text"] as string;
                
                itemDetailList.Add(item);
            }
            reader.Close();
            return itemDetailList;
        }

        public string GetItemPrice(string item)
        {
            throw new NotImplementedException();
        }

    }
}
