using AutoMapper;
using ExamSystemForSchool.Data.Exams;
using ExamSystemForSchool.DTOs.ExamDTO;
using ExamSystemForSchool.DTOs.LessonDTO;
using ExamSystemForSchool.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ExamSystemForSchool.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamsController : Controller
    {
        private readonly IExamRepo _examRepo;
        private readonly IMapper _mapper;

        public ExamsController(IExamRepo examRepo, IMapper mapper)
        {
            _examRepo = examRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExamReadDTO>>> GetAllExams()
        {
            IEnumerable<Exam> model = await _examRepo.GetAllExamsAsync();
            return Ok(_mapper.Map<IEnumerable<ExamReadDTO>>(model));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExamReadDTO>> GetExam(int id)
        {
            Exam model = await _examRepo.GetExamAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            ExamReadDTO exam = _mapper.Map<ExamReadDTO>(model);
            return Ok(exam);
        }

        [HttpPost]
        public async Task<ActionResult> CreateExam(ExamCreateDTO examCreateDTO)
        {
            if (examCreateDTO == null)
                return BadRequest("Lesson data is required.");
            await _examRepo.CreateExamAsync(_mapper.Map<Exam>(examCreateDTO));
            await _examRepo.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateExam(int id, ExamUpdateDTO updateDTO)
        {
            Exam model = await _examRepo.GetExamAsync(id);
            if (model == null)
                return NotFound();
            _mapper.Map<ExamUpdateDTO, Exam>(updateDTO, model);
            //_commanderRepo.UpdateCommand(commandItem);
            await _examRepo.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialUpdateExam(int id, JsonPatchDocument<ExamUpdateDTO> document)
        {
            Exam model = await _examRepo.GetExamAsync(id);
            ExamUpdateDTO updateDTO = _mapper.Map<ExamUpdateDTO>(model);
            document.ApplyTo(updateDTO);
            _mapper.Map(updateDTO, model);
            await _examRepo.SaveChangesAsync();
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
        public async Task<ActionResult> DeleteExam(int id)
        {
            Exam model = await _examRepo.GetExamAsync(id);
            if (model == null)
                return NotFound();
            await _examRepo.RemoveExamAsync(model);
            await _examRepo.SaveChangesAsync();
            return NoContent();
        }
    }
}
