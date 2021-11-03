using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecetasTP.Models
{
    public class BookingsModel
    {
        public int EventId { get; set; }
        public string NameEvent { get; set; }
        public DateTime DateEvent { get; set; }
        public string DescriptionEvent { get; set; }
        public string StateEvent { get; set; }
        public bool Cancelated { get; set; }
        public bool Finished { get; set; }

        public static string GetState(int state) 
        {
            switch (state) 
            {
                case 1:
                    return "Pendiente";
                    break;
                case 2:
                    return "Finalizado";
                    break;
                case 3:
                    return "Cancelado";
                    break;
                default:
                    return "Pendiente";
                    break;
            }
        }
    }
}
