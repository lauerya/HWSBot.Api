using HWSBot.ServiceModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HWSBot.Repositories
{
    public class RedditRepository
    {
        string connectionString = "Data Source=DESKTOP-G3VPCBF;Initial Catalog=HardwareSwap;Integrated Security=True";

        public List<ItemDetail> GetItemDetail(string request)
        {
            List<ItemDetail> itemDetailList;
            ItemDetail item;
            itemDetailList = new List<ItemDetail>();
            SqlConnection myConnection = new SqlConnection(connectionString);

            SqlCommand myCommand = new SqlCommand("dbo.ReadPost", myConnection);
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@SearchTerm", request);                    
            myConnection.Open();

            var reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                item = new ItemDetail()
                {
                    Author = reader["Name"] as string,
                    Date = DateTimeOffset.Parse(reader["Date"] as string),
                    Item = reader["Item"] as string,
                    Price = (List<string>)reader["Price"]
                };
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
