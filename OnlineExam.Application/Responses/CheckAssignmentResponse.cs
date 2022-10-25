﻿using OnlineExam.Domain.Enums;

namespace OnlineExam.Application.Responses
{
    public class CheckAssignmentResponse
    {
        public AssignmentStatus Status { get; set; }

        public string ExamCode { get; set; }

        public string StudentName { get; set; }

        public string StudentSurname { get; set; }

        public DateTime Deadline { get; set; }

        public List<QuestionInExamResponse> QuestionList { get; set; }
    }
}
