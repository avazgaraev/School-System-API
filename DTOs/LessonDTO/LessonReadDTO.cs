using ExamSystemForSchool.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExamSystemForSchool.DTOs.LessonDTO
{
    public class LessonReadDTO
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public byte ClassNum { get; set; }

        public string TeacherName { get; set; }

        public string TeacherSurname { get; set; }

        public ICollection<Exam> Exams { get; set; }
    }
}
