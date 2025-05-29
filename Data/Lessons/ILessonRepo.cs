using ExamSystemForSchool.Models;

namespace ExamSystemForSchool.Data.Lessons
{
    public interface ILessonRepo
    {
        Task<IEnumerable<Lesson>> GetAllLessonsAsync();
        Task<Lesson> GetLessonAsync(string id);
        Task CreateLessonAsync(Lesson lesson);
        Task UpdateLessonAsync(Lesson lesson);
        Task RemoveLessonAsync(Lesson lesson);
        Task<bool> SaveChangesAsync();
    }
}
