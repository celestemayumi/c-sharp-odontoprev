using Microsoft.ML.Data;

namespace c_sharp_odontoprev.Models
{
    public class InputML
    {
        [LoadColumn(0)]
        public float Idade { get; set; }

        [LoadColumn(1)]
        public float HistoricoFaltas { get; set; }

        [LoadColumn(2)]
        public string Especialidade { get; set; }

        [LoadColumn(3)]
        public float TempoAntecedenciaDias { get; set; }

        [LoadColumn(4)]
        public string DiaSemana { get; set; }

        [LoadColumn(5)]
        public string Horario { get; set; }

        [LoadColumn(6)]
        public bool Faltou { get; set; }
    }
}
