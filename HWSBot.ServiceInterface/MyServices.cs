using HWSBot.Interfaces;
using HWSBot.Managers;
using HWSBot.ServiceModel;
using HWSBot.ServiceModel.Ebay;
using HWSBot.ServiceModel.Types;
using ServiceStack;
using System.Collections.Generic;

namespace HWSBot.ServiceInterface
{
    public class MyServices : Service
    {
        RedditManager _manager = new RedditManager();
        IEbayManager _ebayManager;
        private readonly IHardwareSwapManager _hardwareSwapManager;
        private readonly IMatchManager _matchManager;

        public MyServices(IEbayManager ebayManager,
                          IHardwareSwapManager hardwareSwapManager,
                          IMatchManager matchManager)
        {
            _ebayManager = ebayManager;
            _hardwareSwapManager = hardwareSwapManager;
            _matchManager = matchManager;
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

        public List<Product> Get(GetUsersProductList request)
        {
            return _hardwareSwapManager.GetUsersProductList(request.UserId);
        }

        public List<ProductPost> Get(GetProductPostList request)
        {
            return _hardwareSwapManager.GetProductPostList(request.ProductId);
        }

        public ResponseStatus Get(MatchProductPostProcess request)
        {
            _matchManager.MatchProductPost(request.ProductId);
            return new ResponseStatus();
        }

        public ResponseStatus Post(Product product)
        {
            _hardwareSwapManager.Save(product);

            return new ResponseStatus();
        }
    }
}