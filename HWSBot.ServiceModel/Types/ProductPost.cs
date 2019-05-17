namespace HWSBot.ServiceModel.Types
{
    public class ProductPost
    {
        public long ProductPostId { get; set; }
        public Product Product { get; set; }
        public Post Post { get; set; }
        public int TotalRank { get; set; }
        public bool HasBeenRead { get; set; }
    }
}
