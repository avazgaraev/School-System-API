using AutoMapper;
using Azure;
using ExamSystemForSchool.Data.Students;
using ExamSystemForSchool.DTOs.StudentDTO;
using ExamSystemForSchool.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ExamSystemForSchool.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private readonly IStudentRepo _studentRepo;
        private readonly IMapper _mapper;
        public StudentsController(IStudentRepo studentRepo, IMapper mapper)
        {
            _studentRepo = studentRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentReadDTO>>> GetAllStudents()
        {
            IEnumerable<Student> model = await _studentRepo.GetAllStudentsAsync();
            IEnumerable<StudentReadDTO> students = _mapper.Map<IEnumerable<StudentReadDTO>>(model);
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentReadDTO>> GetStudent(int id)
        {
            Student model = await _studentRepo.GetStudentAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            StudentReadDTO student = _mapper.Map<StudentReadDTO>(model);
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult> CreateStudent(StudentCreateDTO studentCreateDTO)
        {
            if (studentCreateDTO == null)
                return BadRequest("Student data is required.");
            await _studentRepo.CreateStudentAsync(_mapper.Map<Student>(studentCreateDTO));
            await _studentRepo.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStudent(int id, StudentUpdateDTO updateDTO)
        {
            Student model = await _studentRepo.GetStudentAsync(id);
            if (model == null)
                return NotFound();
            _mapper.Map<StudentUpdateDTO, Student>(updateDTO, model);
            //_commanderRepo.UpdateCommand(commandItem);
            await _studentRepo.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialUpdateStudent(int id, JsonPatchDocument<StudentUpdateDTO> document)
        {
            Student model = await _studentRepo.GetStudentAsync(id);
            StudentUpdateDTO updateDTO = _mapper.Map<StudentUpdateDTO>(model);
            document.ApplyTo(updateDTO);
            _mapper.Map(updateDTO, model);
            await _studentRepo.SaveChangesAsync();
            return NoContent();

            //json text to write on postman to update partially:
//            [
//	{
//		"op":"replace",
//		"path":"/classNum",
//		"value":"3"
//	}

//]
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            Student model = await _studentRepo.GetStudentAsync(id);
            if (model == null)
                return NotFound();
            await _studentRepo.RemoveStudentAsync(model);
            await _studentRepo.SaveChangesAsync();
            return NoContent();
        }
    }
}
