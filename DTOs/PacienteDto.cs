namespace c_sharp_odontoprev.DTOs
{
    public class PacienteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public long Cpf { get; set; }
        public long Telefone { get; set; }
        public int? IdGenero { get; set; }
        public int? IdEndereco { get; set; }
        public int? IdLogin { get; set; }
        public string ClienteSuspeito { get; set; }
    }
}
