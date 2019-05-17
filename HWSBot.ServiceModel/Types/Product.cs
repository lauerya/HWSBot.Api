using System.Collections.Generic;

namespace HWSBot.ServiceModel.Types
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int RankThreshold { get; set; }
        public int PriceThreshold { get; set; }
        public List<ProductStore> StoreList { get; set; }
        public List<ProductCriteria> ProductCriteriaList { get; set; }
        public int? LastPostId { get; set; }
        public int CreateByUserId { get; set; }
    }
}
