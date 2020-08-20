using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revifast.Api.Models.Reserva
{
    public class UpdateReservaViewModel
    {
        // ID
        public int ReservaId { get; set; }
        // ---------- HAS ONE
        // VEHICULO (CONDUCTOR)
        public int VehiculoId { get; set; }
        // LOCAL (EMPRESA)
        public int LocalId { get; set; }
        // PAGO ADELANTADO
        public int PagoAdelantadoId { get; set; }
        // RESERVA ESTADO
        public int ReservaEstadoId { get; set; }
    }
}
