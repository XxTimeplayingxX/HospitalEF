﻿using System.ComponentModel.DataAnnotations;

namespace HospítalPractice.MODELS
{
    public class Persona
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
    }
}
