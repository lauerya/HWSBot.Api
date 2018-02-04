using System;
using HWSBot.ServiceModel;
using HWSBot.Repositories;
using System.Collections.Generic;

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

        public List<ItemDetail> GetItemDetail(string request)
        {
            List<ItemDetail> itemDetailList;
            itemDetailList = _repository.GetItemDetail(request);
            return itemDetailList;
        }
    }
}
