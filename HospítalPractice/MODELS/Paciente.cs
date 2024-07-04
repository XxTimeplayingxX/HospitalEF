using System.ComponentModel.DataAnnotations;

namespace HospítalPractice.MODELS
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }
        public string HistorialMedico { get; set; }
        public int Persona_id { get; set; }
        public Persona Persona { get; set; }
    }
}
