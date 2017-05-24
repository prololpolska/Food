using System;
using System.Collections.Generic;

namespace App.Models
{
    public class AdminModel
    {
        public string AddMeal { get; set; }
        public short Meal { get; set; }
        public DateTime Date { get; set; }
        public Dictionary<short, string> Meals { get; set;}
    }
}
