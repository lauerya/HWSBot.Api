﻿using ServiceStack;
using System.Collections.Generic;


namespace HWSBot.ServiceModel
{
    [Route("/Reddit/ItemDetail/")]
    public class GetItemDetail: IReturn<List<Post>>
    {
        public string Item { get; set; }
        public string Subreddit { get; set; }
    }
}
