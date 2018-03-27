using HWSBot.ServiceModel.Types;
using ServiceStack;

namespace HWSBot.ServiceModel.Ebay
{
    [Route("/Reddit/Ebay/CompletedItem")]
    public class GetEbayCompletedItem : IReturn<SearchResult>
    {
        public string Item { get; set; }
    }
}
