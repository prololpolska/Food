using Infrastrkture.DTO;
using System.Collections.Generic;

namespace App.Models
{
    public class AccountModel
    {
        public Dictionary<short, string> Meals { get; set; }
        public Dictionary<int, string> Dates { get; set; }
        public List<MealDayDTO> MealDay { get; set; }
    }
}
