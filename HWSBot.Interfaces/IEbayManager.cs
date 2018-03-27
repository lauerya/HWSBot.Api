using HWSBot.ServiceModel.Types;

namespace HWSBot.Interfaces
{
    public interface IEbayManager
    {
        SearchResult GetEbayCompletedItem(string item);
    }
}
