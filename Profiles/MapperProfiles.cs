using AutoMapper;
using ExamSystemForSchool.DTOs.ExamDTO;
using ExamSystemForSchool.DTOs.LessonDTO;
using ExamSystemForSchool.DTOs.StudentDTO;
using ExamSystemForSchool.Models;

namespace ExamSystemForSchool.Profiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<Student, StudentReadDTO>();
            CreateMap<StudentCreateDTO, Student>();
            CreateMap<StudentUpdateDTO, Student>();
            CreateMap<Student, StudentUpdateDTO>();

            CreateMap<Lesson, LessonReadDTO>();
            CreateMap<LessonCreateDTO, Lesson>();
            CreateMap<LessonUpdateDTO, Lesson>();
            CreateMap<Lesson, LessonUpdateDTO>();

            CreateMap<Exam, ExamReadDTO>();
            CreateMap<ExamCreateDTO, Exam>();
            CreateMap<ExamUpdateDTO, Exam>();
            CreateMap<Exam, ExamUpdateDTO>();
        }
    }
}
