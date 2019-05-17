using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using HWSBot.ServiceModel;
using HWSBot.Managers;
using HWSBot.ServiceModel.Types;
using HWSBot.ServiceModel.Ebay;
using HWSBot.Interfaces;

namespace HWSBot.ServiceInterface
{
    public class MyServices : Service
    {
        RedditManager _manager = new RedditManager();
        IEbayManager _ebayManager;

        public MyServices(IEbayManager ebayManager)
        {
            _ebayManager = ebayManager;
        }
        public PriceResponse Post(GetItemPrice request)
        {
            return _manager.GetItemPrice(request.Item);
        }
        public List<Post> Post(GetItemDetail request)
        {
            return _manager.GetItemDetail(request.Subreddit, request.Item);
        }
        public SearchResult Get(GetEbayCompletedItem request)
        {
            return _ebayManager.GetEbayCompletedItem(request.Item);
        }
    }
}