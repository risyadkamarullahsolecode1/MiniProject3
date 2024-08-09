using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MiniProject3.Models
{
    public class DepartmentDto
    {
        [Key]
        [Column("deptno")]
        public int Deptno { get; set; }

        [Column("deptname")]
        [StringLength(50)]
        public string? Deptname { get; set; }
    }
}
