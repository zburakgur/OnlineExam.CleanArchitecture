using Infrastructure.Engine;
using Microsoft.Extensions.DependencyInjection;
using OnlineExam.Application.PersistencePorts;
using OnlineExam.Repository.Persistence;

namespace OnlineExam.Repository.Engine
{
    public class PersistenceRegister : IDynamicRegister
    {
        public void Configure(IServiceCollection service)
        {
            service.AddScoped<IUserEnrollemtPersistencePort, UserEnrollmentPersistence>();
            service.AddScoped<IExamEnrollmentPersistencePort, ExamEnrollmentPersistencePort>();
            service.AddScoped<IAssignmentPersistencePort, AssignmentPersistencePort>();            
        }
    }
}
