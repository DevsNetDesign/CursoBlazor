﻿using System.ComponentModel.DataAnnotations;

namespace Curso.Shared.Entities
{
    public class Country
    {
        public int Id { get; set; }

        [Display(Name = "Pais")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} no pude tener mas de {1} caractéres")]
        public string? Name { get; set; }
    }
}
