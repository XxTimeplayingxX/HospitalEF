using System.ComponentModel.DataAnnotations;

namespace HospítalPractice.MODELS
{
    public class Diagnostico
    {
        [Key]
        public int IdDiagnostico { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string Severidad { get; set; }
        public string Recomendaciones { get; set; }
    }
}
