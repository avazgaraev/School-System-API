using ExamSystemForSchool.Models;

namespace ExamSystemForSchool.Data.Exams
{
    public interface IExamRepo
    {
        Task<IEnumerable<Exam>> GetAllExamsAsync();
        Task<Exam> GetExamAsync(int id);
        Task CreateExamAsync(Exam exam);
        Task UpdateExamAsync(Exam exam);
        Task RemoveExamAsync(Exam exam);
        Task<bool> SaveChangesAsync();
    }
}
