using DAO.Entities;
using System;
using System.Collections.Generic;

namespace RecetasTP.Models
{
    public class ConfirmBookViewModel
    {
        public Event evnt { get; set; }
        public User evntChef { get; set; }
        public int ReservedAmount { get; set; }
        public int RecipeId { get; set; }
    }
}
