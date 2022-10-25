
const TableSettings = {
    pageLength: 100,
    paging: false,
    ordering: false,
    info: false,
    filter: false,
}

const ExamTableHeaders = {
    code: "Exam Code"
}

const QuestionExamTableHeaders = {
    id: "Id",
    text: "Text",
    a: "A",
    b: "B",
    c: "C",
    d: "D",
    answer: "Answer"
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
                App.showMessage('warning', 'Exam file not found!', '');
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
    App.post('/Exams/GetQuestionList', { examCode: exam.code}, function (result) {
        if (result.success) {

            if (result.data.length == 0)
                App.showMessage('warning', 'Exam questions not found!', '');
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