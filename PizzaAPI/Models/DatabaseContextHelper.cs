using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaAPI.Models.Entities;

namespace PizzaAPI.Models.Helpers
{
    class DatabaseContextHelper
    {
        public static PizzaOrderContext Db = new PizzaOrderContext();
    }
}