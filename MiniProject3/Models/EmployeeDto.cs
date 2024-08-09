using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MiniProject3.Models
{
    public class EmployeeDto
    {
        [Key]
        [Column("empno")]
        public int Empno { get; set; }

        [Column("fname")]
        [StringLength(50)]
        public string? Fname { get; set; }

        [Column("lname")]
        [StringLength(50)]
        public string? Lname { get; set; }

        [Column("address")]
        [StringLength(100)]
        public string? Address { get; set; }

        [Column("dob", TypeName = "timestamp without time zone")]
        public DateTime? Dob { get; set; }

        [Column("sex", TypeName = "character varying")]
        public string? Sex { get; set; }

        [Column("position")]
        [StringLength(50)]
        public string? Position { get; set; }

        [Column("deptno")]
        public int? Deptno { get; set; }
    }
}
