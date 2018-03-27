using HWSBot.ServiceModel.Types;
using ServiceStack;
using HWSBot.Interfaces;

namespace HWSBot.Repositories
{
    public class EbayRepository : IEbayRepository
    {
        string ebayUrl = "http://svcs.ebay.com/services/search/FindingService/v1?"; // ConfigurationManager.AppSettings["ebayApiUrl"];
        string ebaySecurityAppUrl = "RyanLaue-Hardware-PRD-b4b12cf99-0bff90a8"; // ConfigurationManager.AppSettings["ebaySecurityAppName"];
        EbayItemDetail response;
        IJsonServiceClient jsonClient;

        public EbayRepository(IJsonServiceClient client)
        {
            jsonClient = client;
        }
        public EbayItemDetail GetEbayCompletedItem(string item)
        {
            string urlParams =
                "OPERATION-NAME=findCompletedItems&" +
                "SERVICE-VERSION=1.0.0&" +
                $"SECURITY-APPNAME={ebaySecurityAppUrl}&" +
                "RESPONSE-DATA-FORMAT=JSON&" +
                "REST-PAYLOAD&" +
                $"keywords={item.Replace(" ", "+")}";
            response = jsonClient.Get<EbayItemDetail>($"{ebayUrl}{urlParams}");
            return response;
        }
    }
}
    //http://svcs.ebay.com/services/search/FindingService/v1?OPERATION-NAME=findItemsByKeywords&SERVICE-VERSION=1.0.0&SECURITY-APPNAME=RyanLaue-Hardware-PRD-b4b12cf99-0bff90a8&REST-PAYLOAD&keywords=harry%20potter%20phoenix&paginationInput.entriesPerPage=2