namespace HMCMusicStore.Web
{
    using HMCMusicStore.Web.Models;
    using HMCMusicStore.Web.Models.Resources;

    public static class DatabaseEmulator
    {
        public static CategoryModel? UnknownCategoryModel;
        public static List<CategoryModel>? CategoryModels;
        public static CategoryModel? CartModel;
        public static int TotalCartPrice;

        public static void Initialize()
        {
            CategoryModels = new List<CategoryModel>
            {
                new CategoryModel(SectionNames.GuitarCategory, new List<ItemModel> {
                    new ItemModel
                    {
                        Title = "Martin Guitars DJr-10E StreetMaster",
                        Price = 869,
                        ImageSource = "https://th.bing.com/th/id/OIP.pmWFAzk1EckQZnOGKoEpxQHaHa?pid=ImgDet&rs=1",
                    },
                    new ItemModel
                    {
                        Title = "Fender Player Series Strat MN CAR",
                        Price = 789,
                        ImageSource = "https://th.bing.com/th/id/OIP.XoS9U7hd9U_uCNuq0QU2NAHaHa?pid=ImgDet&rs=1",
                    },
                    new ItemModel
                    {
                        Title = "Fender Player Series Tele MN CAR",
                        Price = 798,
                        ImageSource = "https://th.bing.com/th/id/OIP.2X7YIxkwLfrdSfF9rzXjoAHaHa?pid=ImgDet&rs=1",
                    },
                    new ItemModel
                    {
                        Title = "Gretsch G6136T-55VS White Falcon",
                        Price = 4199,
                        ImageSource = "https://th.bing.com/th/id/OIP.75-nT-6dR7v3Adv_iPgGGwHaHa?pid=ImgDet&rs=1",
                    },
                }),

                new CategoryModel(SectionNames.DrumCategory, new List<ItemModel> {
                    new ItemModel
                    {
                        Title = "Pearl EXX705NBR/C Export Bl. Cherry",
                        Price = 1089,
                        ImageSource = "https://s1.kuantokusta.pt/img_upload/produtos_imagemsom/363773_3_pearl-exx705nbr-c-export-bl-cherry.jpg",
                    },
                    new ItemModel
                    {
                        Title = "Sonor SQ2 Set 2up2down Deep Black",
                        Price = 5498,
                        ImageSource = "https://th.bing.com/th/id/OIP.gJap7Q9nUua52ZYi1oLj6gAAAA?pid=ImgDet&rs=1",
                    },
                    new ItemModel
                    {
                        Title = "Ludwig Classic Maple Rock Vintage Wh.",
                        Price = 3799,
                        ImageSource = "https://s1.kuantokusta.pt/img_upload/produtos_imagemsom/363375_3_ludwig-classic-maple-rock-black-oy.jpg",
                    },
                    new ItemModel
                    {
                        Title = "Gretsch Drums USA Custom Standard Maple",
                        Price = 7898,
                        ImageSource = "https://th.bing.com/th/id/OIP.0t4-9YIE44XNtQgQq_BXNQHaHn?pid=ImgDet&rs=1",
                    },
                }),
            };

            UnknownCategoryModel = new CategoryModel(SectionNames.DrumCategory, new List<ItemModel> {
                new ItemModel
                {
                    Title = "NotSpecified",
                    Price = 0,
                    ImageSource = null,
                },
            });
        }
    }
}
