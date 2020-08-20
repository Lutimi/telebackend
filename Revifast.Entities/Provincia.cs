using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Revifast.Entities
{
    public partial class Provincia
    {
        public Provincia()
        {
            Distritos = new HashSet<Distrito>();
        }
        // ID
        public int ProvinciaId { get; set; }
        // NOMBRE
        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(20, ErrorMessage = "Nombre permite hasta 20 caracteres")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }
        // ---------- HAS ONE
        // DEPARTAMENTO
        [Required(ErrorMessage = "Departamento es requerido")]
        public int DepartamentoId { get; set; }
        public virtual Departamento Departamento { get; set; }
        // ---------- HAS MANY
        public virtual ICollection<Distrito> Distritos { get; set; }
    }
}
