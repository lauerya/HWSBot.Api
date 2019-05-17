using ServiceStack;

namespace HWSBot.ServiceModel
{
    [Route(path:"/Process/ProductPost/{ProductId}")]
    public class MatchProductPostProcess
    {
        public int ProductId { get; set; }
    }
}
