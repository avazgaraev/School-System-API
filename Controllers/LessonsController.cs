using AutoMapper;
using ExamSystemForSchool.Data.Lessons;
using ExamSystemForSchool.Data.Students;
using ExamSystemForSchool.DTOs.LessonDTO;
using ExamSystemForSchool.DTOs.StudentDTO;
using ExamSystemForSchool.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ExamSystemForSchool.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LesonsController : Controller
    {
        private readonly ILessonRepo _lessonRepo;
        private readonly IMapper _mapper;
        public LesonsController(ILessonRepo lessonRepo, IMapper mapper)
        {
            _lessonRepo = lessonRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LessonReadDTO>>> GetAllLessons()
        {
            IEnumerable<Lesson> model = await _lessonRepo.GetAllLessonsAsync();
            IEnumerable<LessonReadDTO> lessons = _mapper.Map<IEnumerable<LessonReadDTO>>(model);
            return Ok(lessons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LessonReadDTO>> GetLesson(string id)
        {
            Lesson model = await _lessonRepo.GetLessonAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            LessonReadDTO lesson = _mapper.Map<LessonReadDTO>(model);
            return Ok(lesson);
        }

        [HttpPost]
        public async Task<ActionResult> CreateLesson(LessonCreateDTO lessonCreateDTO)
        {
            if (lessonCreateDTO == null)
                return BadRequest("Lesson data is required.");
            await _lessonRepo.CreateLessonAsync(_mapper.Map<Lesson>(lessonCreateDTO));
            await _lessonRepo.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLesson(string id, LessonUpdateDTO updateDTO)
        {
            Lesson model = await _lessonRepo.GetLessonAsync(id);
            if (model == null)
                return NotFound();
            _mapper.Map<LessonUpdateDTO, Lesson>(updateDTO, model);
            //_commanderRepo.UpdateCommand(commandItem);
            await _lessonRepo.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialUpdateLesson(string id, JsonPatchDocument<LessonUpdateDTO> document)
        {
            Lesson model = await _lessonRepo.GetLessonAsync(id);
            LessonUpdateDTO updateDTO = _mapper.Map<LessonUpdateDTO>(model);
            document.ApplyTo(updateDTO);
            _mapper.Map(updateDTO, model);
            await _lessonRepo.SaveChangesAsync();
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
        public async Task<ActionResult> DeleteLesson(string id)
        {
            Lesson model = await _lessonRepo.GetLessonAsync(id);
            if (model == null)
                return NotFound();
            await _lessonRepo.RemoveLessonAsync(model);
            await _lessonRepo.SaveChangesAsync();
            return NoContent();
        }
    }
}
