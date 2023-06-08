namespace HMCMusicStore.Web.Models
{
    public class CategoryModel
    {
        public string Title { get; set; }
        public List<ItemModel> Items { get; set; }

        public CategoryModel(string title, List<ItemModel> itemList)
        {
            Title = title;
            Items = itemList;
        }
    }
}