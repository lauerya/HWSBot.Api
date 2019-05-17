using System.Collections.Generic;
using HWSBot.ServiceModel;
using HWSBot.ServiceModel.Types;

namespace HWSBot.Interfaces
{
    public interface IHardwareSwapRepository
    {
        List<ProductPost> GetProductPostList(Product product);
        List<Post> GetNewPostList(int? lastPostId);
        Dictionary<int, Post> GetBatchPostList(List<int> list);
        Product GetProduct(int productId);
        List<ProductCriteria> GetProductCriteriaList(int productId);
        List<ProductStore> GetProductStoreList(int productId);
        List<Product> SearchUserProductList(int userId);
        void Save(List<ProductPost> productPostList);
        void Save(Product product);
    }
}
