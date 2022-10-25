
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
    id: "Id",
    examCode: "Exam Code",
    isCompleted: "IsCompleted",
    score: "Score",    
    deadline: "Deadline"
}

const ExamTableHeaders = {
    code: "Exam Code"
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

var examTable = new Table("examTable", ExamTableHeaders, TableSettings);
examTable.init();

var loadStudentTable = function () {
    App.loading.start('#pageBody');
    App.post('/Students/GetStudentList', {}, function (result) {
        if (result.success) {

            if (result.data.length == 0)
                App.showMessage('warning', 'There are no registered students, please add a student!', '');
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

            if (result.data.length == 0) {
                App.showMessage('warning', 'There is no exam assigned to this student!', '');
                assignmentTable.clearTable();
            }
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

var closeStudentModal = function () {
    $("#studentModal").modal("hide");
}

var showModalForAddStudent = function () {
    $('#studentModal').modal("show");

    $('#nameTxt').val("");
    $('#surnameTxt').val("");
}

var getStudentModel = function () {
    var model = {
        name: $('#nameTxt').val(),
        surname: $('#surnameTxt').val()
    }

    return model;
}

var saveStudentModal = function () {
    var model = getStudentModel();
    if (model.name.length == 0){
        App.showMessage('warning', 'Please fill name filed!', '');
        return;
    }

    App.loading.start('#pageBody');
    App.post('/Students/Add', model, function (result) {
        if (result.success) {
            loadStudentTable();
            closeStudentModal();
        }
        else
            App.showMessage('error', 'Operation fail.(' + result.message + ')', 'Error');
        App.loading.end('#pageBody');
    },
    false);
}

var closeAssignmentModal = function () {
    $("#assignmentModal").modal("hide");
}

var showModalForAddAssignment = function () {    
    var selectedStudent = studentTable.getSelectedItem();
    if (selectedStudent == null) {
        App.showMessage('warning', 'You should select a student!', '');
        return;
    }

    $('#assignmentModal').modal("show");

    App.loading.start('#form-body');
    App.post('/Exams/GetExamListAvailableForStudent', { studentId: selectedStudent.id}, function (result) {
        if (result.success) {

            if (result.data.length == 0) {
                App.showMessage('warning', 'There are no exams available for this student!', '');
                examTable.clearTable();
            }
            else {
                examTable.loadList(result.data);
            }
        }
        else
            App.showMessage('error', 'Operation fail.(' + result.message + ')', 'Error');
        App.loading.end('#pageBody');
    },
    false);
}

var saveAssignmentModal = function () {
    var selectedExam = examTable.getSelectedItem();
    if (selectedExam == null) {
        App.showMessage('warning', 'You should select an exam from the list!', '');
        return;
    }

    var selectedStudent = studentTable.getSelectedItem();
    if (selectedStudent == null) {
        App.showMessage('warning', 'You should select a student!', '');
        return;
    }

    var model = {
        StudentId: selectedStudent.id,
        ExamCode: selectedExam.code
    }

    App.loading.start('#form-body');
    App.post('/Students/Assign', model, function (result) {
        if (result.success) {
            loadAssignments(selectedStudent);
            closeAssignmentModal();
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