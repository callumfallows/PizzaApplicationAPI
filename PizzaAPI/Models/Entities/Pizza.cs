using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaAPI.Interfaces.Entities;

namespace PizzaAPI.Models.Entities
{
    public class Pizza : IPizza
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public virtual List<Topping> Toppings { get; set; }
        private sealed class NameEqualityComparer : IEqualityComparer<Pizza>
        {
            public bool Equals(Pizza x, Pizza y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return string.Equals(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
            }

            public int GetHashCode(Pizza obj)
            {
                return (obj.Name != null ? StringComparer.OrdinalIgnoreCase.GetHashCode(obj.Name) : 0);
            }
        }
        public static IEqualityComparer<Pizza> NameComparer { get; } = new NameEqualityComparer();

    }
}