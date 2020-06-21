using FoodRoot.Models;
using FoodRoot.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodRoot.WebMVC.Controllers
{
    [Authorize]
    public class FoodController : Controller
    {
        public ActionResult ListBuilder(string foodType)
        {
            var service = new FoodService();
            var model = service.GetFullListOfFoodsByName();

            //ViewBag.FoodType = "beverages";

            if (foodType != null)
            {
                ViewBag.FoodType = foodType;
            }

            if (TempData["FoodType"] != null)
            {
                ViewBag.FoodType = TempData["FoodType"];
            }

            switch (ViewBag.FoodType)
            {
                case "beverages":
                    model = model.Where(e => e.Type == FoodRoot.Data.FoodType.Beverages);
                    break;
                case "breadsAndPastas":
                    model = model.Where(e => e.Type == FoodRoot.Data.FoodType.BreadsAndPastas);
                    break;
                case "cannedGoods":
                    model = model.Where(e => e.Type == FoodRoot.Data.FoodType.CannedGoods);
                    break;
                case "cleaningSupplies":
                    model = model.Where(e => e.Type == FoodRoot.Data.FoodType.CleaningSupplies);
                    break;
                case "condiments":
                    model = model.Where(e => e.Type == FoodRoot.Data.FoodType.Condiments);
                    break;
                case "dairyAndEggs":
                    model = model.Where(e => e.Type == FoodRoot.Data.FoodType.DairyAndEggs);
                    break;
                case "frozenFoods":
                    model = model.Where(e => e.Type == FoodRoot.Data.FoodType.FrozenFoods);
                    break;
                case "meats":
                    model = model.Where(e => e.Type == FoodRoot.Data.FoodType.Meats);
                    break;
                case "pharmaceuticals":
                    model = model.Where(e => e.Type == FoodRoot.Data.FoodType.Pharmaceuticals);
                    break;
                case "produce":
                    model = model.Where(e => e.Type == FoodRoot.Data.FoodType.Produce);
                    break;
                case "snacks":
                    model = model.Where(e => e.Type == FoodRoot.Data.FoodType.Snacks);
                    break;
                case "spices":
                    model = model.Where(e => e.Type == FoodRoot.Data.FoodType.Spices);
                    break;
                case "toiletries":
                    model = model.Where(e => e.Type == FoodRoot.Data.FoodType.Toiletries);
                    break;
                default:
                    model = model.Where(e => e.Type == FoodRoot.Data.FoodType.Beverages);
                    break;
            }

            return View(model);
        }

        public ActionResult KitchenCheck(string foodType)
        {
            var service = new FoodService();
            var model = service.GetFoodsOnListForKitchenCheck();

            ViewBag.FoodType = "beverages";

            if (foodType != null)
            {
                ViewBag.FoodType = foodType;
            }

            if (TempData["FoodType"] != null)
            {
                ViewBag.FoodType = TempData["FoodType"];
            }

            switch (ViewBag.FoodType)
            {
                case "beverages":
                    model = model.Where(e => e.Type == FoodRoot.Data.FoodType.Beverages);
                    break;
                case "breadsAndPastas":
                    model = model.Where(e => e.Type == FoodRoot.Data.FoodType.BreadsAndPastas);
                    break;
                case "cannedGoods":
                    model = model.Where(e => e.Type == FoodRoot.Data.FoodType.CannedGoods);
                    break;
                case "cleaningSupplies":
                    model = model.Where(e => e.Type == FoodRoot.Data.FoodType.CleaningSupplies);
                    break;
                case "condiments":
                    model = model.Where(e => e.Type == FoodRoot.Data.FoodType.Condiments);
                    break;
                case "dairyAndEggs":
                    model = model.Where(e => e.Type == FoodRoot.Data.FoodType.DairyAndEggs);
                    break;
                case "frozenFoods":
                    model = model.Where(e => e.Type == FoodRoot.Data.FoodType.FrozenFoods);
                    break;
                case "meats":
                    model = model.Where(e => e.Type == FoodRoot.Data.FoodType.Meats);
                    break;
                case "pharmaceuticals":
                    model = model.Where(e => e.Type == FoodRoot.Data.FoodType.Pharmaceuticals);
                    break;
                case "produce":
                    model = model.Where(e => e.Type == FoodRoot.Data.FoodType.Produce);
                    break;
                case "snacks":
                    model = model.Where(e => e.Type == FoodRoot.Data.FoodType.Snacks);
                    break;
                case "spices":
                    model = model.Where(e => e.Type == FoodRoot.Data.FoodType.Spices);
                    break;
                case "toiletries":
                    model = model.Where(e => e.Type == FoodRoot.Data.FoodType.Toiletries);
                    break;
                default:
                    model = model.Where(e => e.Type == FoodRoot.Data.FoodType.Beverages);
                    break;
            }

            return View(model);
        }

        public ActionResult GroceryCart()
        {
            var service = new FoodService();
            var model = service.GetFoodsOnListForGroceryCart();
            return View(model.OrderByDescending(e => e.LocationId));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FoodCreate model)
        {
            if (ModelState.IsValid)
            {
                var service = new FoodService();
                service.CreateFood(model);

                return RedirectToAction("Create");
            }

            return View(model);
        }

        public ActionResult AddToList(int foodId, string foodType)
        {
            var service = new FoodService();
            service.AddToList(foodId);
            TempData["FoodType"] = foodType;

            return RedirectToAction("ListBuilder");
        }

        public ActionResult RemoveFromList(int foodId, string foodType)
        {
            var service = new FoodService();
            service.RemoveFromList(foodId);
            TempData["FoodType"] = foodType;

            return RedirectToAction("ListBuilder");
        }

        public ActionResult RemoveFromKitchenCheck(int foodId, string foodType)
        {
            var service = new FoodService();
            service.RemoveFromList(foodId);
            TempData["FoodType"] = foodType;

            return RedirectToAction("KitchenCheck");
        }

        public ActionResult RemoveFromListInTheCart(int foodId, string foodType)
        {
            var service = new FoodService();
            service.RemoveFromList(foodId);

            return RedirectToAction("GroceryCart");
        }

        public ActionResult StartNewShoppingList()
        {
            var service = new FoodService();
            service.ClearShoppingList();

            return RedirectToAction("ListBuilder", "Food");
        }
    }
}