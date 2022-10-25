using AutoMapper;
using MediatR;
using OnlineExam.Application.Queries;
using OnlineExam.Application.Responses;
using OnlineExam.Domain.Entities;
using OnlineExam.Domain.Ports;
using OnlineExam.Domain.Enums;

namespace OnlineExam.Application.Handlers
{
    public class CheckAssignmentHandler : IRequestHandler<CheckAssignmentQuery, CheckAssignmentResponse>
    {
        private readonly IRepositoryPort _repositoryPort;
        private readonly IMapper _mapper;

        public CheckAssignmentHandler(IRepositoryPort _repositoryPort, IMapper _mapper)
        {
            this._repositoryPort = _repositoryPort;
            this._mapper = _mapper;
        }

        public async Task<CheckAssignmentResponse> Handle(CheckAssignmentQuery request, CancellationToken cancellationToken)
        {
            Assignment assignment = await _repositoryPort.CheckAssignment(request.AssignmentId);
            var response = new CheckAssignmentResponse();
            response.QuestionList = new List<QuestionInExamResponse>();

            if (assignment == default)
            {
                response.Status = AssignmentStatus.INVALID;
                return response;
            }

            if (assignment.IsCompleted)
            {
                response.Status = AssignmentStatus.DONE;
                return response;
            }                

            if (DateTime.Now > assignment.Deadline)
            {
                response.Status = AssignmentStatus.EXPIRED;
                return response;
            }

            List<Question> questions = await _repositoryPort.GetQuestionListWithExamCode(assignment.ExamCode, request.Path);
            response = _mapper.Map<CheckAssignmentResponse>(assignment);
            response.AssignmentId = assignment.Id;
            response.Status = AssignmentStatus.OK;
            response.QuestionList = _mapper.Map<List<QuestionInExamResponse>>(questions);

            Student student = await _repositoryPort.GetStudentWithId(assignment.StudentId);
            response.StudentName = student.Name;
            response.StudentSurname = student.Surname;

            return response;
        }
    }
}
