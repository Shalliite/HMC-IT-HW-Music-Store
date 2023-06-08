namespace HMCMusicStore.Web.Controllers
{
    using HMCMusicStore.Web.Logic;
    using HMCMusicStore.Web.Models;
    using HMCMusicStore.Web.Models.Resources;
    using Microsoft.AspNetCore.Mvc;

    public class CategoryController : Controller
    {
        private CategoryLogic _categoryLogic;
        private string _categoryView = "Views/CategoryView.cshtml";
        private string _cartView = "Views/CartView.cshtml";

        public CategoryController()
        {
            _categoryLogic = new CategoryLogic();
        }

        [HttpGet]
        public IActionResult Guitars()
        {
            CategoryModel model = _categoryLogic.ShowContent(SectionNames.GuitarCategory);
            return View(_categoryView, model);
        }

        [HttpGet]
        public IActionResult Drums()
        {
            CategoryModel model = _categoryLogic.ShowContent(SectionNames.DrumCategory);
            return View(_categoryView, model);
        }

        [HttpGet]
        public IActionResult Cart()
        {
            CartModel model = _categoryLogic.ShowCart();
            return View(_cartView, model);
        }

        [HttpPost]
        public IActionResult Cart(PaymentModel model)
        {
            _categoryLogic.Purchase(model);
            return Redirect("/Home/Index");
        }

        [HttpGet]
        public JsonResult GetTotalPrice()
        {
            return Json($"{DatabaseEmulator.TotalCartPrice}");
        }

        [HttpPost]
        public JsonResult AddToCart(UpdateCartModel addToCartModel)
        {
            _categoryLogic.AddToCart(addToCartModel);
            return Json("Added successfully!");
        }

        [HttpPost]
        public JsonResult UpdateCart(UpdateCartModel updateCartModel)
        {
            _categoryLogic.UpdateCart(updateCartModel);
            return Json("Item count in cart change successful!");
        }

        [HttpPost]
        public JsonResult RemoveFromCart(UpdateCartModel deleteCartModel)
        {
            _categoryLogic.RemoveFromCart(deleteCartModel);
            return Json("Item successfully removed!");
        }
    }
}
