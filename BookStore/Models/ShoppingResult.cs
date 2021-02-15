using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class ShoppingResult
    {
        public static List<CompleteShopping> shoppingUsers= new List<CompleteShopping>();
        public static void Add(CompleteShopping completeShopping)
        {
            shoppingUsers.Add(completeShopping);
        }
    }
}
