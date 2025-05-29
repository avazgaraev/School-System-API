using ExamSystemForSchool.Models;
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
    }
}
