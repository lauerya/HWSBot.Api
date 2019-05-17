using HWSBot.ServiceModel;
using HWSBot.ServiceModel.Types;
using System.Collections.Generic;

namespace HWSBot.Interfaces
{
    public interface IHardwareSwapManager
    {
        List<Product> GetUsersProductList(int userId);
        List<ProductPost> GetProductPostList(int productId);
        Product GetProduct(int productId);
        List<Post> GetNewPostList(int? lastPostId);
        void Save(List<ProductPost> productPostList);
        void Save(Product product);
    }
}
