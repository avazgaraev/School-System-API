using ExamSystemForSchool.DTOs.StudentDTO;
using ExamSystemForSchool.Models;

namespace ExamSystemForSchool.Data.Students
{
    public interface IStudentRepo
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentAsync(int id);
        Task CreateStudentAsync(Student stud);
        Task UpdateStudentAsync(Student stud);
        Task RemoveStudentAsync(Student stud);
        Task<bool> SaveChangesAsync();
    }
}
