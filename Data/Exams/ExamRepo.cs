using ExamSystemForSchool.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamSystemForSchool.Data.Exams
{
    public class ExamRepo : IExamRepo
    {
        private readonly AppDBContext _dbContext;

        public ExamRepo(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task CreateExamAsync(Exam exam)
        {
            if (exam == null)
                throw new ArgumentNullException(nameof(exam));
            await _dbContext.Exams.AddAsync(exam);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Exam>> GetAllExamsAsync()
        {
            return await _dbContext.Exams.ToListAsync();
        }

        public async Task<Exam> GetExamAsync(int id)
        {
            return await _dbContext.Exams.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveExamAsync(Exam exam)
        {
            _dbContext.Exams.Remove(exam);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _dbContext.SaveChangesAsync()) >= 0;
        }

        public async Task UpdateExamAsync(Exam exam)
        {
            //controllerde edeceyik
        }

        public async Task<IEnumerable<Exam>> GetExamsByStudentAsync(int studentCode)
        {
            var exams = await _dbContext.Exams
                .Where(e => e.StudentCode == studentCode)
                .Include(e => e.Lesson)
                .ToListAsync();

            return exams;
        }

        public async Task<IEnumerable<Exam>> GetExamsByLessonAsync(string lessonCode)
        {
            var exams = await _dbContext.Exams
                .Where(e => e.LessonCode == lessonCode)
                .Include(e => e.Student)
                .ToListAsync();

            return exams;
        }
    }
}
