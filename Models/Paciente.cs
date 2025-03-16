using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace c_sharp_odontoprev.Models
{
    [Table("OP_PACIENTE")]
    public class Paciente
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("NOME_PACIENTE")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Column("DATA_DE_NASCIMENTO")]
        public DateTime DataNascimento { get; set; }

        [Column("EMAIL_PACIENTE")]
        [StringLength(50)]
        public string Email { get; set; }

        [Column("CPF_PACIENTE")]
        public long Cpf { get; set; }

        [Column("TELEFONE_PACIENTE")]
        public long Telefone { get; set; }

        [ForeignKey("OP_GENERO")]
        [Column("ID_GENERO")]
        public int? IdGenero { get; set; }

        public virtual Genero Genero { get; set; }

        [ForeignKey("OP_ENDERECO")]
        [Column("ID_ENDERECO")]
        public int? IdEndereco { get; set; }

        public virtual Endereco Endereco { get; set; }

        [ForeignKey("OP_LOGIN")]
        [Column("ID_LOGIN")]
        public int? IdLogin { get; set; }

        public virtual Login Login { get; set; }

        [Column("CLIENTE_SUSPEITO")]
        [StringLength(1)]
        public string ClienteSuspeito { get; set; }
    }
}
