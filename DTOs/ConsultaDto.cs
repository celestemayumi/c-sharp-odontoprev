namespace c_sharp_odontoprev.DTOs
{
    public class ConsultaDTO
    {
        public int ID { get; set; }
        public DateTime DATA_CONSULTA { get; set; }
        public int IdPaciente { get; set; }
        public int IdDentista { get; set; }
        public int IdUnidade { get; set; }
    }
}
