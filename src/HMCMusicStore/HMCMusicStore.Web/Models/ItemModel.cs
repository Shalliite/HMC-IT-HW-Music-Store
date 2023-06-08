namespace HMCMusicStore.Web.Models
{
    public class ItemModel
    {
        public string? Title { get; set; }
        public int Price { get; set; }
        public string? ImageSource { get; set; }
        public string? Description { get; set; }
        public string? Uid { get; set; }
        public int CountInCart { get; set; }
        private static long? TotalItemCount = 0;

        public ItemModel()
        {
            Uid = "item_" + TotalItemCount;
            TotalItemCount++;
            CountInCart = 0;
            Price = 0;
        }
    }
}
