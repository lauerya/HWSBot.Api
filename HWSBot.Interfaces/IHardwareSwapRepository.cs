using System.Collections.Generic;
using HWSBot.ServiceModel;
using HWSBot.ServiceModel.Types;

namespace HWSBot.Interfaces
{
    public interface IHardwareSwapRepository
    {
        List<ProductPost> GetProductPostList(Product product);
        List<Post> GetNewPostList(int? lastPostId);
        void GetBatchPostList(List<int> list);
    }
}
