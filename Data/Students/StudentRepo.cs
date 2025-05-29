using ExamSystemForSchool.DTOs.StudentDTO;
using ExamSystemForSchool.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamSystemForSchool.Data.Students
{
    public class StudentRepo : IStudentRepo
    {
        private readonly AppDBContext _dbContext;
        
        public StudentRepo(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateStudentAsync(Student stud)
        {
            if(stud == null)
                throw new ArgumentNullException(nameof(stud));
            await _dbContext.Students.AddAsync(stud);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _dbContext.Students.Include(x => x.Exams).ToListAsync();
        }

        public async Task<Student> GetStudentAsync(int id)
        {
            return await _dbContext.Students.Include(x => x.Exams).FirstOrDefaultAsync(x => x.Code==id);
        }

        public async Task RemoveStudentAsync(Student stud)
        {
            _dbContext.Students.Remove(stud);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _dbContext.SaveChangesAsync())>=0;
        }

        public async Task UpdateStudentAsync(Student stud)
        {
            //controllerde edeceyik
        }
    }
}
