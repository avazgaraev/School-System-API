using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExamSystemForSchool.DTOs.LessonDTO
{
    public class LessonUpdateDTO
    {
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
    }
}
