using System.ComponentModel.DataAnnotations;

namespace HospítalPractice.MODELS
{
    public class DetalleReceta
    {
        [Key]
        public int Id_DetalleReceta { get; set; }
        public int Receta_id { get; set; }
        public string Medicamento { get; set; }
        public string Dosis { get; set; }
        public string Frecuencia { get; set; }
        public string Duracion { get; set; }
        public string Instrucciones { get; set; }
        public Receta Receta { get; set; }
    }
}
