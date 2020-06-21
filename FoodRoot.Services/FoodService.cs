using FoodRoot.Data;
using FoodRoot.Models;
using FoodRoot.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRoot.Services
{
    public class FoodService
    {
        private readonly Guid _userId;

        public FoodService (Guid userId)
        {
            _userId = userId;
        }

        public FoodService ()
        {

        }

        public IEnumerable<FoodListItem> GetFullListOfFoodsByName ()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Foods
                        .Select(
                            e =>
                                new FoodListItem
                                {
                                    FoodId = e.FoodId,
                                    LocationId = e.LocationId,
                                    FoodName = e.FoodName,
                                    Type = e.Type,
                                    IsInCart = e.IsInCart,
                                    IsInKitchen = e.IsInKitchen,
                                    IsOnList = e.IsOnList
                                });

                return query.ToArray().OrderBy(e => e.FoodName);
            }
        }

        public IEnumerable<FoodListItem> GetFoodsOnListForKitchenCheck()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Foods
                        .Where(e => e.IsOnList == true)
                        .Select(
                            e =>
                                new FoodListItem
                                {
                                    FoodId = e.FoodId,
                                    LocationId = e.LocationId,
                                    FoodName = e.FoodName,
                                    Type = e.Type,
                                    IsInCart = e.IsInCart,
                                    IsInKitchen = e.IsInKitchen,
                                    IsOnList = e.IsOnList
                                });

                return query.ToArray().OrderBy(e => e.LocationId);
            }
        }

        public IEnumerable<FoodListItem> GetFoodsOnListForGroceryCart()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Foods
                        .Where(e => e.IsOnList == true)
                        .Select(
                            e =>
                                new FoodListItem
                                {
                                    FoodId = e.FoodId,
                                    LocationId = e.LocationId,
                                    FoodName = e.FoodName,
                                    Type = e.Type,
                                    IsInCart = e.IsInCart,
                                    IsInKitchen = e.IsInKitchen,
                                    IsOnList = e.IsOnList
                                });

                return query.ToArray().OrderBy(e => e.LocationId);
            }
        }

        public bool CreateFood(FoodCreate model)
        {
            var entity = new Food()
            {
                FoodId = model.FoodId,
                LocationId = model.LocationId,
                FoodName = model.FoodName,
                Type = model.Type,
                IsInCart = false,
                IsInKitchen = false,
                IsOnList = false
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Foods.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool AddToList(int foodId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Foods.Single(e => e.FoodId == foodId);
                entity.IsOnList = true;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool RemoveFromList(int foodId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Foods.Single(e => e.FoodId == foodId);
                entity.IsOnList = false;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool ClearShoppingList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                foreach(Food f in ctx.Foods)
                {
                    f.IsInCart = false;
                    f.IsInKitchen = false;
                    f.IsOnList = false;
                }

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
