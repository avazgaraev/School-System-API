using ExamSystemForSchool.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExamSystemForSchool.DTOs.StudentDTO
{
    public class StudentUpdateDTO
    {
        //public int Code { get; set; }

        [MaxLength(30)]
        [Column(TypeName = "varchar(30)")]
        public string Name { get; set; }

        [MaxLength(30)]
        [Column(TypeName = "varchar(30)")]
        public string Surname { get; set; }

        [Range(0, 99)]
        public byte ClassNum { get; set; }

    }
}
