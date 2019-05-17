using HWSBot.Interfaces;
using HWSBot.ServiceModel;
using HWSBot.ServiceModel.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HWSBot.Repositories
{
    public class HardwareSwapRepository : IHardwareSwapRepository
    {
        string connectionString = "Data Source=DESKTOP-G3VPCBF;Initial Catalog=HardwareSwap;Integrated Security=True";

        public Dictionary<int, Post> GetBatchPostList(List<int> postIdList)
        {
            Dictionary<int, Post> postByIdDictionary;
            Post post;
            postByIdDictionary = new Dictionary<int, Post>();
            SqlConnection myConnection = new SqlConnection(connectionString);

            SqlCommand myCommand = new SqlCommand("dbo.ReadBatchPost", myConnection);
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@IdTable", CreateDataTable(postIdList));
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

                postByIdDictionary[post.PostId] = post;
            }
            reader.Close();
            return postByIdDictionary;
        }

        private DataTable CreateDataTable(List<int> list)
        {
            DataTable dataTable;

            dataTable = new DataTable();
            dataTable.Columns.Add("Id");

            foreach (int l in list)
            {
                dataTable.Rows.Add(l);
            }
            return dataTable;
        }

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

        public Product GetProduct(int productId)
        {
            Product product = null;
            SqlConnection myConnection = new SqlConnection(connectionString);

            SqlCommand myCommand = new SqlCommand("dbo.ReadProduct", myConnection);
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@ProductId", productId);
            myConnection.Open();

            var reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                product = new Product();

                product.ProductId = int.Parse(reader["ProductId"].ToString());
                product.Name = reader["Name"] as string;
                product.RankThreshold = int.Parse(reader["RankThreshold"].ToString());
                product.PriceThreshold = int.Parse(reader["PriceThreshold"].ToString());
                product.CreateByUserId = int.Parse(reader["CreatedByUserId"].ToString());
            }
            reader.Close();
            return product;
        }

        public List<ProductCriteria> GetProductCriteriaList(int productId)
        {
            List<ProductCriteria> productCriteriaList;
            ProductCriteria productCriteria;
            productCriteriaList = new List<ProductCriteria>();
            SqlConnection myConnection = new SqlConnection(connectionString);

            SqlCommand myCommand = new SqlCommand("dbo.SearchProductCriteria", myConnection);
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@ProductId", productId);
            myConnection.Open();

            var reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                productCriteria = new ProductCriteria();
                productCriteria.ProductCriteriaId = int.Parse(reader["ProductCriteriaId"].ToString());
                productCriteria.Value = reader["Value"] as string;
                productCriteria.Rank = int.Parse(reader["Rank"].ToString());
                productCriteria.ProductId = productId;

                productCriteriaList.Add(productCriteria);
            }
            reader.Close();
            return productCriteriaList;
        }

        public List<ProductStore> GetProductStoreList(int productId)
        {
            List<ProductStore> productStoreList;
            ProductStore productStore;
            productStoreList = new List<ProductStore>();
            SqlConnection myConnection = new SqlConnection(connectionString);

            SqlCommand myCommand = new SqlCommand("dbo.SearchProductStore", myConnection);
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@ProductId", productId);
            myConnection.Open();

            var reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                productStore = new ProductStore();
                productStore.ProductStoreId = int.Parse(reader["ProductStoreId"].ToString());
                productStore.Category = reader["Value"] as string;
                productStore.StoreType = (StoreType)int.Parse(reader["StoreTypeId"].ToString());
                productStore.ProductId = productId;

                productStoreList.Add(productStore);
            }
            reader.Close();
            return productStoreList;
        }

        public List<Product> SearchUserProductList(int userId)
        {
            List<Product> productList;
            Product product = null;
            SqlConnection myConnection = new SqlConnection(connectionString);

            SqlCommand myCommand = new SqlCommand("dbo.ReadProduct", myConnection);
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@UserId", userId);
            myConnection.Open();

            productList = new List<Product>();

            var reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                product = new Product();

                product.ProductId = int.Parse(reader["ProductId"].ToString());
                product.Name = reader["Name"] as string;
                product.RankThreshold = int.Parse(reader["RankThreshold"].ToString());
                product.PriceThreshold = int.Parse(reader["PriceThreshold"].ToString());
                product.CreateByUserId = int.Parse(reader["CreatedByUserId"].ToString());
                productList.Add(product);
            }
            reader.Close();
            return productList;
        }

        public void Save(List<ProductPost> productPostList)
        {
            DataTable dataTable;

            dataTable = new DataTable();
            dataTable.Columns.Add("ProductPostId");
            dataTable.Columns.Add("ProductId");
            dataTable.Columns.Add("PostId");
            dataTable.Columns.Add("TotalRank");
            dataTable.Columns.Add("HasBeenRead");

            foreach (ProductPost productPost in productPostList)
            {
                dataTable.Rows.Add(
                    productPost.ProductPostId,
                    productPost.Product.ProductId,
                    productPost.Post.PostId,
                    productPost.TotalRank,
                    productPost.HasBeenRead);
            }

            SqlConnection myConnection = new SqlConnection(connectionString);

            SqlCommand myCommand = new SqlCommand("dbo.MergeProductPost", myConnection);
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@ProductPostType", dataTable);
            myConnection.Open();
            
            myCommand.ExecuteNonQuery();
        }

        public void Save(Product product)
        {
            DataTable dataTable;

            dataTable = new DataTable();
            dataTable.Columns.Add("ProductId");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("CreateByUserId");
            dataTable.Columns.Add("RankThreshold");
            dataTable.Columns.Add("PriceThreshold");
            dataTable.Columns.Add("LastPostId");

            dataTable.Rows.Add(
                    product.ProductId,
                    product.Name,
                    product.CreateByUserId,
                    product.RankThreshold,
                    product.PriceThreshold,
                    product.LastPostId);
            

            SqlConnection myConnection = new SqlConnection(connectionString);

            SqlCommand myCommand = new SqlCommand("dbo.MergeProduct", myConnection);
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@ProductType", dataTable);
            myConnection.Open();

            myCommand.ExecuteNonQuery();
        }

        public void Save(List<ProductStore> storeList)
        {
            DataTable dataTable;

            dataTable = new DataTable();
            dataTable.Columns.Add("ProductStoreId");
            dataTable.Columns.Add("StoreTypeId");
            dataTable.Columns.Add("ProductId");
            dataTable.Columns.Add("StoreCategory");

            foreach (ProductStore productStore in storeList)
            {
                dataTable.Rows.Add(
                    productStore.ProductStoreId,
                    (int)productStore.StoreType,
                    productStore.ProductId,
                    productStore.Category);
            }

            SqlConnection myConnection = new SqlConnection(connectionString);

            SqlCommand myCommand = new SqlCommand("dbo.MergeProductStore", myConnection);
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@ProductStoreType", dataTable);
            myConnection.Open();

            myCommand.ExecuteNonQuery();
        }

        public void Save(List<ProductCriteria> productCriteriaList)
        {
            DataTable dataTable;

            dataTable = new DataTable();
            dataTable.Columns.Add("ProductCriteriaId");
            dataTable.Columns.Add("Value");
            dataTable.Columns.Add("Rank");
            dataTable.Columns.Add("ProductId");

            foreach (ProductCriteria productCriteria in productCriteriaList)
            {
                dataTable.Rows.Add(
                    productCriteria.ProductCriteriaId,
                    productCriteria.Value,
                    productCriteria.Rank,
                    productCriteria.ProductId);
            }

            SqlConnection myConnection = new SqlConnection(connectionString);

            SqlCommand myCommand = new SqlCommand("dbo.MergeProductCriteria", myConnection);
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@ProductCriteriaType", dataTable);
            myConnection.Open();

            myCommand.ExecuteNonQuery();
        }


        //NICK save stuff
    }
}
