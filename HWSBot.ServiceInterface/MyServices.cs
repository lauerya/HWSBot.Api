using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using HWSBot.ServiceModel;
using HWSBot.Managers;

namespace HWSBot.ServiceInterface
{
    public class MyServices : Service
    {
        RedditManager _manager = new RedditManager();
        public PriceResponse Post(GetItemPrice request)
        {
            return _manager.GetItemPrice(request.Item);
        }
        public List<ItemDetail> Post(GetItemDetail request)
        {
            return _manager.GetItemDetail(request.Subreddit, request.Item);
        }
    }
}