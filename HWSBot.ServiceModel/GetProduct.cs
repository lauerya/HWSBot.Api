using ServiceStack;

namespace HWSBot.ServiceModel
{
    [Route(path: "/Product/{ProductId}", verbs:"GET")]
    public class GetProduct
    {
        public int ProductId { get; set; }
    }
}
