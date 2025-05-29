using ExamSystemForSchool.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExamSystemForSchool.DTOs.ExamDTO
{
    public class ExamUpdateDTO
    {
        [ForeignKey(nameof(Lesson))]
        [Column(TypeName = "char(3)")]
        public string LessonCode { get; set; }

        [ForeignKey(nameof(Student))]
        public int StudentCode { get; set; }

        public DateTime ExamDate { get; set; }

        [Range(0, 9)]
        public byte Score { get; set; }
    }
}
