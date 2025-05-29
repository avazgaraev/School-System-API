using ExamSystemForSchool.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamSystemForSchool.Data.Lessons
{
    public class LessonRepo : ILessonRepo
    {
        private readonly AppDBContext _dbContext;

        public LessonRepo(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateLessonAsync(Lesson lesson)
        {
            if (lesson == null)
                throw new ArgumentNullException(nameof(lesson));

            var random = new Random();
            lesson.Code = $"L{random.Next(10, 99)}";
            await _dbContext.Lessons.AddAsync(lesson);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Lesson>> GetAllLessonsAsync()
        {
            return await _dbContext.Lessons.Include(x=>x.Exams).ToListAsync();
        }

        public async Task<Lesson> GetLessonAsync(string id)
        {
            return await _dbContext.Lessons.Include(x => x.Exams).FirstOrDefaultAsync(x => x.Code == id);
        }

        public async Task RemoveLessonAsync(Lesson lesson)
        {
            _dbContext.Lessons.Remove(lesson);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _dbContext.SaveChangesAsync()) >= 0;
        }

        public async Task UpdateLessonAsync(Lesson lesson)
        {
            //controllerde edeceyik
        }
    }
}
