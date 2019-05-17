using HWSBot.Interfaces;
using HWSBot.ServiceModel;
using HWSBot.ServiceModel.Types;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWSBot.Repositories
{
    public class HardwareSwapRepository : IHardwareSwapRepository
    {
        string connectionString = "Data Source=DESKTOP-G3VPCBF;Initial Catalog=HardwareSwap;Integrated Security=True";
        
        public List<Post> GetNewPostList(int? lastPostId)
        {
            List<Post> postList;
            Post post;
            postList = new List<Post>();
            SqlConnection myConnection = new SqlConnection(connectionString);

            SqlCommand myCommand = new SqlCommand("dbo.ReadNewPosts", myConnection);
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@LastPostId", lastPostId);
            myConnection.Open();

            var reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                post = new Post();

                post.PostId = int.Parse(reader["PostID"].ToString());
                post.Author = reader["Name"] as string;
                post.Date = reader["Date"] as string;
                post.Item = reader["Items"] as string;
                post.Price = reader["Price"] as string;
                post.Url = reader["Url"] as string;
                post.Text = reader["Text"] as string;
                post.Category = reader["Category"] as string;
                post.Title = reader["Title"] as string;

                postList.Add(post);
            }
            reader.Close();
            return postList;
        }

        public List<ProductPost> GetProductPostList(Product product)
        {
            List<ProductPost> productPostList;
            ProductPost productPost;
            productPostList = new List<ProductPost>();
            SqlConnection myConnection = new SqlConnection(connectionString);

            SqlCommand myCommand = new SqlCommand("dbo.SearchProductPost", myConnection);
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@ProductId", product.ProductId);
            myConnection.Open();

            var reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                productPost = new ProductPost();
                productPost.ProductPostId = int.Parse(reader["ProductPostId"].ToString());

                productPost.Post = new Post();
                productPost.Post.PostId = int.Parse(reader["PostID"].ToString());
                
                productPost.Product = product;

                productPost.HasBeenRead = bool.Parse(reader["HasBeenRead"].ToString());
                productPost.TotalRank = int.Parse(reader["TotalRank"].ToString());


                productPostList.Add(productPost);
            }
            reader.Close();
            return productPostList;
        }
    }
}
