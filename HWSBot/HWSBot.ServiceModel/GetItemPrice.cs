using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;

namespace HWSBot.ServiceModel
{
    [Route("/Price/{Item}")]
    public class GetItemPrice : IReturn<PriceResponse>
    {
        public string Item { get; set; }
    }

    public class PriceResponse
    {
        public string Price { get; set; }
    }
}