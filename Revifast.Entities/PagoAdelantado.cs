using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Revifast.Entities
{
    public partial class PagoAdelantado
    {
        public PagoAdelantado()
        {
            Reservas = new HashSet<Reserva>();
        }

        // ID
        public int PagoAdelantadoId { get; set; }
        // NOMBRE
        public string Nombre { get; set; }
        // PORCENTAJE   
        public decimal Procentaje { get; set; }
        // DESCRIPCION
        public string Descripcion { get; set; }
        // ---------- HAS ONE
        // ---------- HAS MANY
        // RESERVAS
        public virtual ICollection<Reserva> Reservas { get; set; }

    }
}
