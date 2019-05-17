using HWSBot.ServiceModel.Types;
using System.Collections.Generic;

namespace HWSBot.Interfaces
{
    public interface IHardwareSwapManager
    {
        List<Product> GetUsersProductList(int userId);
        List<ProductPost> GetProductPostList(int productId);
    }
}
