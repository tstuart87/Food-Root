using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRoot.Data
{
    public enum FoodType
    {
        Beverages,
        BreadsAndPastas,
        CannedGoods,
        CleaningSupplies,
        Condiments,
        DairyAndEggs,
        DeliGoods,
        FrozenFoods,
        Meats,
        Pharmaceuticals,
        Produce,
        Snacks,
        Spices,
        Toiletries
    } 

    public class Food
    {
        [Key]
        public int FoodId { get; set; }
        public FoodType Type { get; set; }
        public string FoodName { get; set; }
        public string LocationId { get; set; }
        public bool IsOnList { get; set; }
        public bool IsInKitchen { get; set; }
        public bool IsInCart { get; set; }
    }
}
