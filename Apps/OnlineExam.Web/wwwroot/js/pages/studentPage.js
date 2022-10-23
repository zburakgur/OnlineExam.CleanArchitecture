
const TableSettings = {
    pageLength: 100,
    paging: false,
    ordering: false,
    info: false,
    filter: false,
}

const StudentTableHeaders = {
    id: { value: "Id", hidden: true },
    name: "Name",
    surname: "Surname"
}

const AssignmentTableHeaders = {
    id: { value: "Id", hidden: true },
    studentId: { value: "StudentId", hidden: true },
    examId: { value: "ExamId", hidden: true },
    code: "Exam Code",
    header: "Exam Header",
    isCompleted: "IsCompleted",
    score: "Score",
    deadline: "Deadline"
}

$.fn.dataTable.moment('DD.MM.YYYY');

var studentTable = new Table("studentTable", StudentTableHeaders, TableSettings);
studentTable.init();

studentTable.selectCallback(function () {
    var selectedStudent = studentTable.getSelectedItem();
    if (selectedStudent == null)
        return;

    loadAssignments(selectedStudent);
});

var assignmentTable = new Table("assignmentTable", AssignmentTableHeaders, TableSettings);
assignmentTable.init();

var loadStudentTable = function () {
    App.loading.start('#pageBody');
    App.post('/Students/GetStudentList', {}, function (result) {
        if (result.success) {

            if (result.data.length == 0)
                App.showMessage('warning', 'No record', '');
            else {
                studentTable.loadList(result.data);
            }
        }
        else
            App.showMessage('error', 'Operation fail.(' + result.message + ')', 'Error');
        App.loading.end('#pageBody');
    },
    false);
}

var loadAssignments = function (student) {
    App.loading.start('#pageBody');
    App.post('/Students/GetAssignmentList', { studentId: student.id }, function (result) {
        if (result.success) {

            if (result.data.length == 0)
                App.showMessage('warning', 'No record', '');
            else {
                assignmentTable.loadList(result.data);
            }
        }
        else
            App.showMessage('error', 'Operation fail.(' + result.message + ')', 'Error');
        App.loading.end('#pageBody');
    },
    false);
}


$(document).ready(function () {
    loadStudentTable();
});