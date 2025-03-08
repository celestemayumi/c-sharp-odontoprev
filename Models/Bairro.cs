using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace c_sharp_odontoprev.Models
{
    [Table("OP_BAIRRO")]
    public class Bairro
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("NOME_BAIRRO")]
        [StringLength(30)]
        public string Nome { get; set; }

        [ForeignKey("OP_CIDADE")]
        [Column("ID_CIDADE")]
        public int IdCidade { get; set; }

        public virtual Cidade Cidade { get; set; }
    }
}
