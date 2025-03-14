using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace c_sharp_odontoprev.Models
{
    [Table("OP_ENDERECO")]
    public class Endereco
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("LOGRADOURO")]
        [StringLength(50)]
        public string? Logradouro { get; set; }

        [Column("NUMERO")]
        public int? Numero { get; set; }

        [Column("CEP")]
        public int? Cep { get; set; }

        [Column("COMPLEMENTO")]
        [StringLength(100)]
        public string? Complemento { get; set; }

        [ForeignKey("OP_BAIRRO")]
        [Column("ID_BAIRRO")]
        public int? IdBairro { get; set; }

        public virtual Bairro? Bairro { get; set; }
    }
}
