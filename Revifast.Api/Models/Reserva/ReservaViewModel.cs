﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revifast.Api.Models.Reserva
{
    public class ReservaViewModel
    {
        // ID
        public int ReservaId { get; set; }
        // FECHA
        public string Fecha { get; set; }
        // HORA ATENCION
        public string Hora { get; set; }
        // OBSERVACIONES
        public string Observaciones { get; set; }
        // ---------- HAS ONE
        //VEHICULO (CONDUCTOR)
        public string Vehiculo { get; set; }
        //LOCAL (EMPRESA)
        public string Local { get; set; }
        //PAGO ADELANTADO
        public string PagoAdelantado { get; set; }
        public decimal PaAdPorcentaje { get; set; }
        //RESERVA ESTADO
        public string Estado { get; set; }
    }
}
