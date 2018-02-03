using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using HWSBot.ServiceModel;

namespace HWSBot.ServiceInterface
{
    public class MyServices : Service
    {
        public object Any(GetItemPrice request)
        {
            return null;
        }
    }
}