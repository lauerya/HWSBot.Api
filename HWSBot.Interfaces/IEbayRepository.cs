using HWSBot.ServiceModel.Types;

namespace HWSBot.Interfaces
{
    public interface IEbayRepository
    {
        EbayItemDetail GetEbayCompletedItem(string item);
    }
}
