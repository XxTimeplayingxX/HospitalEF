using System.ComponentModel.DataAnnotations;

namespace HospítalPractice.MODELS
{
    public class SignosVitales
    {
        [Key]
        public int Id { get; set; }
        public string Temperatura { get; set; }
        public string Pulso { get; set; }
        public string FrecuenciaCardiaca { get; set; }
        public int Paciente_id { get; set; }
        public Paciente Paciente { get; set; }
    }
}
