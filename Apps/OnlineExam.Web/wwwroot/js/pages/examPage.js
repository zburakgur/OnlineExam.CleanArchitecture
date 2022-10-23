
const TableSettings = {
    pageLength: 100,
    paging: false,
    ordering: false,
    info: false,
    filter: false,
}

const ExamTableHeaders = {
    id: { value: "Id", hidden: true },
    code: "Code",
    header: "Header",
    questions: { value: "Questions", hidden: true }
}

const QuestionExamTableHeaders = {
    id: { value: "Id", hidden: true },
    examId: { value: "ExamId", hidden: true },
    text: "Text",
    a: "A",
    b: "B",
    c: "C",
    d: "D",
    trueAnswer: "TrueAnswer"
}

$.fn.dataTable.moment('DD.MM.YYYY');

var examTable = new Table("examTable", ExamTableHeaders, TableSettings);
examTable.init();

examTable.selectCallback(function () {
    var selectedExam = examTable.getSelectedItem();
    if (selectedExam == null)
        return;

    loadQuestions(selectedExam);
});

var questionTable = new Table("questionTable", QuestionExamTableHeaders, TableSettings);
questionTable.init();

var loadExamTable = function () {
    App.loading.start('#pageBody');
    App.post('/Exams/GetExamList', {}, function (result) {
        if (result.success) {

            if (result.data.length == 0)
                App.showMessage('warning', 'No record', '');
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

var loadQuestions = function (exam) {
    App.loading.start('#pageBody');
    App.post('/Exams/GetQuestionList', { examId: exam.id}, function (result) {
        if (result.success) {

            if (result.data.length == 0)
                App.showMessage('warning', 'No record', '');
            else {
                questionTable.loadList(result.data);
            }
        }
        else
            App.showMessage('error', 'Operation fail.(' + result.message + ')', 'Error');
        App.loading.end('#pageBody');
    },
        false);
}

$(document).ready(function () {
    loadExamTable();
});