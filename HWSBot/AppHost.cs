using Funq;
using ServiceStack;
using HWSBot.ServiceInterface;
using System.Web.Http.Cors;
using System.Web.Http;
using System;
using HWSBot.Managers;
using HWSBot.Interfaces;
using HWSBot.Repositories;

namespace HWSBot
{
    //VS.NET Template Info: https://servicestack.net/vs-templates/EmptyAspNet
    public class AppHost : AppHostBase
    {
        /// <summary>
        /// Base constructor requires a Name and Assembly where web service implementation is located
        /// </summary>
        public AppHost()
            : base("HWSBot", typeof(MyServices).Assembly)
        {
            
        }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        public override void Configure(Container container)
        {
            ConfigureContainer(container);
            //Config examples
            this.Plugins.Add(new PostmanFeature());
            Plugins.Add(new CorsFeature(
    allowOriginWhitelist: new[] {
      "http://localhost", "http://localhost:3000", "http://localhost:4200"
       },
    allowCredentials: true,
    allowedHeaders: "Content-Type, Allow, Authorization"));
        }

        private void ConfigureContainer(Container container)
        {
            container.Register<IJsonServiceClient>(c => new JsonServiceClient("http://localhost/api/Hws/V1"));
            container.Register<IEbayRepository>(c => new EbayRepository(c.Resolve<IJsonServiceClient>()));
            container.Register<IEbayManager>(c => new EbayManager(c.Resolve<IEbayRepository>()));
          
        }
    }
}   