﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Revifast.Api.Models.Provincia
{
    public class UpdateProvinciaViewModel
    {
        public int ProvinciaId { get; set; }
        // NOMBRE
        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(20, ErrorMessage = "Nombre permite hasta 20 caracteres")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }
        // DEPARTAMENTO
        [Required(ErrorMessage = "Departamento es requerido")]
        public int DepartamentoId { get; set; }
    }
}
