using RedditSharp.Things;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWSBot.Repositories
{
    public class RedditRepository
    {
        public void AddToDatabase(Post post, string items, List<string> price)
        {
            String.Join(String.Empty, price);

            string connectionString = "Data Source=DESKTOP-JQ72B37;Initial Catalog=HWSBot;Integrated Security=True";
            SqlConnection myConnection = new SqlConnection(connectionString);

            myConnection.Open();

            SqlCommand myCommand = new SqlCommand("INSERT INTO HWSBotTable", myConnection);
            myCommand.Parameters.AddWithValue("@Name", post.AuthorName);
            myCommand.Parameters.AddWithValue("@Items", items);
            myCommand.Parameters.AddWithValue("@Date", post.Created);
            myCommand.Parameters.AddWithValue("@Price", price);

            myCommand.ExecuteNonQuery();
        }
        public bool ValueExistsInDatabase(string val)
        {
            SqlCommand find_item = new SqlCommand("SELECT TOP 1 FROM products WHERE products.id = ?");
            if (find_item == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public void WriteToFile(Post post, string items, List<string> price)
        {
            string combindedPrice = string.Join(",", price.ToArray());
            string directory = Environment.CurrentDirectory + "WriteLines.txt";

            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(directory, true))
            {
                file.WriteLine("");
                file.WriteLine("Flair: " + post.LinkFlairText);
                file.WriteLine("Name: " + post.AuthorName);
                file.WriteLine("Date: " + post.Created);
                file.WriteLine("Items: " + items);
                file.WriteLine("Prices: " + combindedPrice);
            }
        }
    }
}
