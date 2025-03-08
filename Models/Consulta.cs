using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace c_sharp_odontoprev.Models
{
    [Table("OP_CONSULTA")]
    public class Consulta
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("DATA_CONSULTA")]
        public DateTime DATA_CONSULTA { get; set; }

        [ForeignKey("OP_PACIENTE")]
        [Column("ID_PACIENTE")]
        public int IdPaciente { get; set; }

        public virtual Paciente Paciente { get; set; }

        [ForeignKey("OP_DENTISTA")]
        [Column("ID_DENTISTA")]
        public int IdDentista { get; set; }

        public virtual Dentista Dentista { get; set; }

        [ForeignKey("OP_UNIDADE")]
        [Column("ID_UNIDADE")]
        public int IdUnidade { get; set; }

        public virtual Unidade Unidade { get; set; }
    }
}
