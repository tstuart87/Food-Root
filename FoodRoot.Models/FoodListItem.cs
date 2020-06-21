using FoodRoot.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRoot.Models
{
    public class FoodListItem
    {
        public int FoodId { get; set; }
        public FoodType Type { get; set; }
        public string FoodName { get; set; }
        public string LocationId { get; set; }
        public bool IsOnList { get; set; }
        public bool IsInKitchen { get; set; }
        public bool IsInCart { get; set; }
    }
}
