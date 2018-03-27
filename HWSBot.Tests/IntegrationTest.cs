using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HWSBot.ServiceInterface;
using HWSBot.Interfaces;
using HWSBot.ServiceModel.Ebay;
using HWSBot.Repositories;
using HWSBot.Managers;
using ServiceStack;

namespace HWSBot.Tests
{
    [TestClass]
    public class IntegrationTest
    {

        [TestInitialize]
        public void Init()
        {

        }
        [TestMethod]
        public void EbayIntegrationTest()
        {
            MyServices service;
            IEbayManager ebayManager;
            IEbayRepository ebayRepository;
            IJsonServiceClient jsonClient;
            jsonClient = new JsonServiceClient();
            ebayRepository = new EbayRepository(jsonClient);
        
            ebayManager = new EbayManager(ebayRepository);

            service = new MyServices(ebayManager);
            GetEbayCompletedItem request = new GetEbayCompletedItem();
            request.Item = "Pixel 2 xl";

            var response = service.Get(request);
            Assert.IsNotNull(response);
        }
    }
}
