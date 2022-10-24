using AutoMapper;
using OnlineExam.Application.Commands;
using OnlineExam.Application.Queries;
using OnlineExam.Application.Responses;
using OnlineExam.Domain.Entities;

namespace OnlineExam.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentResponse>().ReverseMap();
            CreateMap<Student, CreateStudentCommand>().ReverseMap();
            CreateMap<Assignment, AssignmentResponse>().ReverseMap();
            CreateMap<Assignment, CreateAssignmentCommand>().ReverseMap();
            CreateMap<Exam, ExamResponse>().ReverseMap();
            CreateMap<Question, QuestionResponse>().ReverseMap();
            CreateMap<Admin, CheckLoginQuery>().ReverseMap();
            CreateMap<Admin, CheckLoginResponse>().ReverseMap();
        }
    }
}
