using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWSBot.ServiceModel
{
    [Route("/Reddit/ItemDetail/")]
    public class GetItemDetail: IReturn<List<ItemDetail>>
    {
        public string Item { get; set; }
    }
}
