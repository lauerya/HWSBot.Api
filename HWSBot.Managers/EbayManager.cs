using HWSBot.ServiceModel.Types;
using HWSBot.Interfaces;
using System.Collections.Generic;

namespace HWSBot.Managers
{
    public class EbayManager : IEbayManager
    {
        IEbayRepository _repository;

       public EbayManager(IEbayRepository repository)
        {
            _repository = repository;
        }

        public SearchResult GetEbayCompletedItem(string item)
        {
            EbayItemDetail response;
            response = _repository.GetEbayCompletedItem(item);
            if (response != null && response.findCompletedItemsResponse[0] != null)
            {
                return response.findCompletedItemsResponse[0].searchResult[0];
            }
            else
            {
                return null;
            }
        }
    }
}
