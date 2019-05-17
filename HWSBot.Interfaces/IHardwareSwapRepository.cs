using System.Collections.Generic;
using HWSBot.ServiceModel;
using HWSBot.ServiceModel.Types;

namespace HWSBot.Interfaces
{
    public interface IHardwareSwapRepository
    {
        List<ProductPost> GetProductPostList(int productId);
        List<Post> GetNewPostList(int? lastPostId);
    }
}
