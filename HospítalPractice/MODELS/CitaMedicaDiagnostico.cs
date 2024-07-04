using System.ComponentModel.DataAnnotations;

namespace HospítalPractice.MODELS
{
    public class CitaMedicaDiagnostico
    {
        [Key]
        public int IdCitaMedicaDiagnostico { get; set; }
        public int IdCitaMedica { get; set; }
        public int IdDiagnostico { get; set; }
        public CitaMedico CitaMedico { get; set; }
        public Diagnostico Diagnostico { get; set; }
    }
}
