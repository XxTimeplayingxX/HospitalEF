using System.ComponentModel.DataAnnotations;

namespace HospítalPractice.MODELS
{
    public class Receta
    {
        [Key]
        public int Id_Receta { get; set; }
        public DateTime FechaEmision { get; set; }
        public string Comentarios { get; set; }
    }
}
