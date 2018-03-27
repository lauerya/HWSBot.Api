using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HWSBot.Repositories;
using ServiceStack;
using HWSBot.ServiceModel.Ebay;

namespace HWSBot.Tests
{
    [TestClass]
    public class EbayRepositoryTests
    {
        [TestMethod]
        public void TestMethod1()
        {
           // IJsonServiceClient client;
            //EbayRepository repository = new EbayRepository(client);

            //repository.GetEbayCompletedItem("Pixel");
        }
        [TestMethod]
        public void AAT()
        {
            GetEbayCompletedItem request = new GetEbayCompletedItem();
            request.Item = "pixel";

            var client = new ServiceStack.JsonServiceClient("http://localhost/api/Hws/V1/");

            var response = client.Get(request); //WOrking on getting ebay api to work.

            Assert.IsNotNull(response);
        }
    }
}
