using ExamSystemForSchool.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExamSystemForSchool.DTOs.ExamDTO
{
    public class ExamReadDTO
    {
        public long Id { get; set; }

        public string LessonCode { get; set; }

        public int StudentCode { get; set; }

        public DateTime ExamDate { get; set; }

        public byte Score { get; set; }
    }
}
