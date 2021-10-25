using System;
using System.Collections.Generic;

#nullable disable

namespace DAO.Models
{
    public partial class Calificacione
    {
        public int IdCalificacion { get; set; }
        public int IdEvento { get; set; }
        public int IdComensal { get; set; }
        public int Calificacion { get; set; }
        public string Comentarios { get; set; }

        public virtual Usuario IdComensalNavigation { get; set; }
        public virtual Evento IdEventoNavigation { get; set; }
    }
}
