namespace HMCMusicStore.Web.Logic
{
    using HMCMusicStore.Web;
    using HMCMusicStore.Web.Models;
    using HMCMusicStore.Web.Models.Resources;
    using System.Xml.Schema;

    public class CategoryLogic
    {
        public CategoryModel ShowContent(string sectionName)
        {
            if (sectionName == SectionNames.GuitarCategory)
            {
                return DatabaseEmulator.CategoryModels.First(category => category.Title == sectionName);
            }

            if (sectionName == SectionNames.DrumCategory)
            {
                return DatabaseEmulator.CategoryModels.First(category => category.Title == sectionName);
            }

            return DatabaseEmulator.UnknownCategoryModel;
        }

        public CartModel ShowCart()
        {
            List<ItemModel> itemList = new List<ItemModel>();
            foreach (var category in DatabaseEmulator.CategoryModels)
            {
                foreach (var item in category.Items)
                {
                    if (item.CountInCart > 0)
                    {
                        itemList.Add(item);
                    }
                }
            }

            return new CartModel(itemList);
        }

        public void AddToCart(UpdateCartModel addToCartModel)
        {
            if (addToCartModel.CountToUpdate <= 0)
            {
                addToCartModel.CountToUpdate = 1;
            }

            foreach (var category in DatabaseEmulator.CategoryModels)
            {
                foreach (var item in category.Items)
                {
                    if (item.Uid == addToCartModel.UidToUpdate)
                    {
                        DatabaseEmulator.TotalCartPrice =
                            DatabaseEmulator.TotalCartPrice + (item.Price * addToCartModel.CountToUpdate);
                        item.CountInCart = item.CountInCart + addToCartModel.CountToUpdate;
                    }
                }
            }
        }

        public void UpdateCart(UpdateCartModel updateCartModel)
        {
            foreach (var category in DatabaseEmulator.CategoryModels)
            {
                foreach (var item in category.Items)
                {
                    if (item.Uid == updateCartModel.UidToUpdate)
                    {
                        if (updateCartModel.CountToUpdate <= 0)
                        {
                            updateCartModel.CountToUpdate = 1;
                        }

                        if (updateCartModel.CountToUpdate < item.CountInCart)
                        {
                            DatabaseEmulator.TotalCartPrice = 
                                DatabaseEmulator.TotalCartPrice - 
                                (item.Price * (item.CountInCart - updateCartModel.CountToUpdate));
                        }

                        if (updateCartModel.CountToUpdate > item.CountInCart)
                        {
                            DatabaseEmulator.TotalCartPrice = DatabaseEmulator.TotalCartPrice - (item.CountInCart * item.Price);
                            DatabaseEmulator.TotalCartPrice =
                                DatabaseEmulator.TotalCartPrice + (item.Price * updateCartModel.CountToUpdate);
                        }

                        item.CountInCart = updateCartModel.CountToUpdate;
                    }
                }
            }
        }

        public void RemoveFromCart(UpdateCartModel deleteCartModel)
        {
            foreach (var category in DatabaseEmulator.CategoryModels)
            {
                foreach (var item in category.Items)
                {
                    if ((item.Uid == deleteCartModel.UidToUpdate) && (deleteCartModel.CountToUpdate == 0))
                    {
                        DatabaseEmulator.TotalCartPrice =
                            DatabaseEmulator.TotalCartPrice - (item.Price * item.CountInCart);
                        item.CountInCart = 0;
                    }
                }
            }
        }

        public void Purchase(PaymentModel model)
        {
            foreach (var category in DatabaseEmulator.CategoryModels)
            {
                foreach (var item in category.Items)
                {
                    item.CountInCart = 0;
                    DatabaseEmulator.TotalCartPrice = 0;
                }
            }
        }
    }
}
