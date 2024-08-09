using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MiniProject3.Models
{
    public class WorksonDto
    {
        [Key]
        [Column("empno")]
        public int Empno { get; set; }

        [Key]
        [Column("projno")]
        public int Projno { get; set; }

        [Column("dateworked", TypeName = "timestamp without time zone")]
        public DateTime? Dateworked { get; set; }

        [Column("hoursworked")]
        public int? Hoursworked { get; set; }
    }
}
