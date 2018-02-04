using ServiceStack;

namespace HWSBot.ServiceModel
{
    [Route("/Reddit/Price/{Item}")]
    public class GetItemPrice : IReturn<PriceResponse>
    {
        public string Item { get; set; }
    }

    public class PriceResponse
    {
        public string Price { get; set; }
    }
}