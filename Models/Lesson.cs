using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExamSystemForSchool.Models
{
    public class Lesson
    {
        //public int Id { get; set; }

        [Key]
        [MaxLength(3)]
        [Column(TypeName = "char(3)")]
        public string Code { get; set; }

        [MaxLength(30)]
        [Column(TypeName = "varchar(30)")]
        public string Name { get; set; }

        [Range(0, 99)]
        public byte ClassNum { get; set; }

        [MaxLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string TeacherName { get; set; }

        [MaxLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string TeacherSurname { get; set; }

        public ICollection<Exam> Exams { get; set; }

    }
}
