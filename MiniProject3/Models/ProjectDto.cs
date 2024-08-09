using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MiniProject3.Models
{
    public class ProjectDto
    {
        [Key]
        [Column("projno")]
        public int Projno { get; set; }

        [Column("projname")]
        [StringLength(50)]
        public string? Projname { get; set; }

        [Column("deptno")]
        public int? Deptno { get; set; }
    }
}
