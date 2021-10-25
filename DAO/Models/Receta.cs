using System;
using System.Collections.Generic;

#nullable disable

namespace DAO.Models
{
    public partial class Receta
    {
        public Receta()
        {
            EventosReceta = new HashSet<EventosReceta>();
            Reservas = new HashSet<Reserva>();
        }

        public int IdReceta { get; set; }
        public int IdCocinero { get; set; }
        public string Nombre { get; set; }
        public int TiempoCoccion { get; set; }
        public string Descripcion { get; set; }
        public string Ingredientes { get; set; }
        public int IdTipoReceta { get; set; }

        public virtual TipoReceta IdTipoRecetaNavigation { get; set; }
        public virtual ICollection<EventosReceta> EventosReceta { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
