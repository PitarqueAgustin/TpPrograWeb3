using System;
using System.Collections.Generic;

#nullable disable

namespace DAO.Models
{
    public partial class Evento
    {
        public Evento()
        {
            Calificaciones = new HashSet<Calificacione>();
            EventosReceta = new HashSet<EventosReceta>();
            Reservas = new HashSet<Reserva>();
        }

        public int IdEvento { get; set; }
        public int IdCocinero { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public int CantidadComensales { get; set; }
        public string Ubicacion { get; set; }
        public string Foto { get; set; }
        public decimal Precio { get; set; }
        public int Estado { get; set; }

        public virtual Usuario IdCocineroNavigation { get; set; }
        public virtual ICollection<Calificacione> Calificaciones { get; set; }
        public virtual ICollection<EventosReceta> EventosReceta { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
