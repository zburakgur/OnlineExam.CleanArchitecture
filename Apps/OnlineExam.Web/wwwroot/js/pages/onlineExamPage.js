
var completeTheExam = function () {
    var answerList = [];
    for (var i = 1; i <= questionListSize; i++) {
        var selected = $("input[type='radio'][name='question_" + i + "_option']:checked");
        if (selected.length == 0) {
            App.showMessage('warning', 'You shoud select an answer for the question ' + i + '', '');
            return;
        }

        // radio id's last character is the option
        var answer = { QuestionId: i, Code:  selected[0].id.substr(selected[0].id.length - 1) };
        answerList.push(answer);
    }

    $.confirm({
        title: 'Are you sure to complete the exam?',
        content: '',
        buttons: {
            confirm: function () {
                sendAnswer(answerList);
            },
            cancel: function () {}
        }
    });
}

var sendAnswer = function (answerList) {
    App.loading.start('#pageBody');

    var model = {
        AssignmentId: assignmentId,
        AnswerList: answerList
    }

    App.post('/OnlineExam/CompleteExam', model, function (result) {
        if (result.success) {
            $.confirm({
                title: 'Exam score is ' + result.data.score,
                content: '',
                buttons: {
                    confirm: function () {
                        location.reload();
                    }
                }
            });            
        }
        else
            App.showMessage('error', 'Operation fail.(' + result.message + ')', 'Error');
        App.loading.end('#pageBody');
    },
    false);
}