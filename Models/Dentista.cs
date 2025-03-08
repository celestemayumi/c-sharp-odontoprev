using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace c_sharp_odontoprev.Models
{
    [Table("OP_DENTISTA")]
    public class Dentista
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("NOME_DENTISTA")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Column("DATA_DE_NASCIMENTO")]
        public DateTime DataNascimento { get; set; }

        [Column("EMAIL_DENTISTA")]
        [StringLength(50)]
        public string Email { get; set; }

        [Column("CPF_DENTISTA")]
        public long Cpf { get; set; }

        [Column("TELEFONE_DENTISTA")]
        public long Telefone { get; set; }

        [Column("CRO")]
        [StringLength(20)]
        public string CRO { get; set; }

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

        [Column("DENTISTA_SUSPEITO")]
        [StringLength(1)]
        public string DentistaSuspeito { get; set; }

        public virtual ICollection<Consulta> Consultas { get; set; }
    }
}
