using ServiceStack;

namespace HWSBot.ServiceModel
{
    [Route(path:"/ProductPost/{ProductId}")]
    public class GetProductPostList
    {
        public int ProductId { get; set; }
    }
}
