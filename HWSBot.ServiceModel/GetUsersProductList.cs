using ServiceStack;

namespace HWSBot.ServiceModel
{
    [Route(path: "/Product/{UserId}", verbs: "GET")]
    public class GetUsersProductList
    {
        public int UserId { get; set; }
    }
}
