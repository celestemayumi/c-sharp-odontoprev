namespace c_sharp_odontoprev.DTOs
{
    public class CidadeDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdEstado { get; set; }  // Relacionamento com Estado
    }
}
