namespace HMCMusicStore.Web.Models
{
    using HMCMusicStore.Web.Models.Resources;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Linq;

    public class CartModel
    {
        public string Title { get; set; }
        public List<ItemModel> Items { get; set; }
        public PaymentModel? Payment { get; set; }

        public CartModel(List<ItemModel> itemList)
        {
            Title = SectionNames.CartSection;
            Items = itemList;
        }
    }
}
