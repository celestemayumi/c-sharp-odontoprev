using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace c_sharp_odontoprev.Models
{
    [Table("OP_CIDADE")]
    public class Cidade
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("NOME_CIDADE")]
        [StringLength(30)]
        public string Nome { get; set; }

        [ForeignKey("OP_ESTADO")]
        [Column("ID_ESTADO")]
        public int IdEstado { get; set; }

        public virtual Estado Estado { get; set; }
    }
}
