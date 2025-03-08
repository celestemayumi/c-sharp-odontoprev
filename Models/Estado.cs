using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace c_sharp_odontoprev.Models
{
    [Table("OP_ESTADO")]
    public class Estado
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("NOME_ESTADO")]
        [StringLength(30)]
        public string Nome { get; set; }

        [Column("SIGLA_ESTADO")]
        [StringLength(5)]
        public string Sigla { get; set; }
        public virtual ICollection<Cidade> Cidades { get; set; }
    }
}
