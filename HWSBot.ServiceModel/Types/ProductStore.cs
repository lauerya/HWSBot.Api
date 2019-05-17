namespace HWSBot.ServiceModel.Types
{
    public class ProductStore
    {
        public int ProductStoreId { get; set; }
        public int ProductId { get; set; }
        public StoreType StoreTypeId { get; set; }
        public string Category { get; set; }
    }
}
