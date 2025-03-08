using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace c_sharp_odontoprev.Models
{
    [Table("OP_GENERO")]
    public class Genero
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("TITULO")]
        [StringLength(30)]
        public string TITULO { get; set; }

        public virtual ICollection<Paciente> Pacientes { get; set; }
        public virtual ICollection<Dentista> Dentistas { get; set; }
    }
}
