using AutoMapper;
using Infrastructure.Mapper;
using OnlineExam.Application.Commands;
using OnlineExam.Application.Responses;
using OnlineExam.Domain.Entities;

namespace OnlineExam.Api.Mapper
{
    public class MappingConfiguration : IMapperConfigure
    {
        public MapperConfiguration CreateMapperConfigure()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<CreateStudentCommand, Student>();
                    cfg.CreateMap<CheckLoginCommand, Admin>();
                    cfg.CreateMap<CreateExamCommand, Exam>();
                    cfg.CreateMap<CreateAssignmentCommand, Assignment>();
                    cfg.CreateMap<Assignment, AssignmentBelongtoUser>();
                });

            return config;
        }
    }
}
