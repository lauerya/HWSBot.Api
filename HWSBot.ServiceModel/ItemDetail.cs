using System;
using System.Collections.Generic;

namespace HWSBot.ServiceModel
{
    public class ItemDetail
    {
        public List<string> Price { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Item { get; set; }
        public string Author { get; set; }
    }
}
