using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace HospítalPractice.MODELS
{
    public class CitaMedico
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Medico_Id { get; set; }
        public int Estado { get; set; }
        public int Receta_id { get; set; }
        public int Diagnostico_id { get; set; }
        public Medico Medico { get; set; }
        public Receta Receta { get; set; }
        public Diagnostico Diagnostico { get; set; }
    }
}
