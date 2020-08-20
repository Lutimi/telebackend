using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revifast.Api.Models.PagoAdelantado
{
    public class UpdatePagoAdelantadoViewModel
    {
        // ID
        public int PagoAdelantadoId { get; set; }
        // NOMBRE
        public string Nombre { get; set; }
        // PORCENTAJE   
        public decimal Procentaje { get; set; }
        // DESCRIPCION
        public string Descripcion { get; set; }
    }
}
