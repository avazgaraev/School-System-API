using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExamSystemForSchool.Models
{
    public class Exam
    {
        public long Id { get; set; }

        [ForeignKey(nameof(Lesson))]
        [Column(TypeName = "char(3)")]
        public string LessonCode { get; set; }

        [ForeignKey(nameof(Student))]
        public int StudentCode { get; set; }

        public DateTime ExamDate { get; set; }

        [Range(0, 9)]
        public byte Score { get; set; }

        public Lesson Lesson { get; set; }
        public Student Student { get; set; }
    }
}
