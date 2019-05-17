using System;
using HWSBot.ServiceModel;
using HWSBot.Repositories;
using System.Collections.Generic;
using ServiceStack.FluentValidation;
using HWSBot.ServiceModel.Types;

namespace HWSBot.Managers
{
    public class RedditManager
    {
        RedditRepository _repository = new RedditRepository();

        public PriceResponse GetItemPrice(string item)
        {
            PriceResponse response;
            response = new PriceResponse();
            string result;  
            result = _repository.GetItemPrice(item);

            response.Price = result;
            return response;
        }

        public List<Post> GetItemDetail(string subreddit, string request)
        {
            List<Post> itemDetailList;
            if(request == null) { throw new ValidationException("No query term included"); }
            switch (subreddit)
            {
                case "hardwareswap":
                    itemDetailList = _repository.GetAllItemDetail(request, "dbo.ReadHardwareSwapPost");
                    break;
                case "mechmarket":
                    itemDetailList = _repository.GetAllItemDetail(request, "dbo.ReadMechMarketPost");
                    break;
                case "appleswap":
                    itemDetailList = _repository.GetAllItemDetail(request, "dbo.ReadAppleSwapPost");
                    break;
                default:
                    itemDetailList = _repository.GetAllItemDetail(request, "dbo.ReadPost");
                    break;
            }
            return itemDetailList;
        }
    }
}
