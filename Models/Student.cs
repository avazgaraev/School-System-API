using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamSystemForSchool.Models
{
    public class Student
    {

        //[Key]
        //public long Id { get; set; }

        [Key]
        [Range(0, 99999)]
        public int Code { get; set; }

        [MaxLength(30)]
        [Column(TypeName = "varchar(30)")]
        public string Name { get; set; }

        [MaxLength(30)]
        [Column(TypeName = "varchar(30)")]
        public string Surname { get; set; }
        
        [Range(0,99)]
        public byte ClassNum { get; set; }

        public ICollection<Exam> Exams { get; set; }
    }
}
