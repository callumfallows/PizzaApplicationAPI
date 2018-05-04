using System;
using System.Collections.Generic;
using PizzaAPI.Interfaces.Entities;

namespace PizzaAPI.Models.Entities
{
    public class Topping : ITopping
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public virtual List<Pizza> Pizza { get; set; }
        private sealed class NameEqualityComparer : IEqualityComparer<Topping>
        {
            public bool Equals(Topping x, Topping y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return string.Equals(x.Size, y.Size, StringComparison.OrdinalIgnoreCase);
            }

            public int GetHashCode(Topping obj)
            {
                return (obj.Name != null ? StringComparer.OrdinalIgnoreCase.GetHashCode(obj.Name) : 0);
            }
        }
        public static IEqualityComparer<Topping> SizeComparer { get; } = new Topping.NameEqualityComparer();
       
    }
}