using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace c_sharp_odontoprev.Models
{
    [Table("OP_UNIDADE")]
    public class Unidade
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("NOME_UNIDADE")]
        [StringLength(255)]
        public string Nome { get; set; }

        [Column("TELEFONE")]
        public long Telefone { get; set; }

        [ForeignKey("OP_ENDERECO")]
        [Column("ID_ENDERECO")]
        public int IdEndereco { get; set; }

        public virtual Endereco Endereco { get; set; }

        public virtual ICollection<Consulta> Consultas { get; set; }
    }
}
