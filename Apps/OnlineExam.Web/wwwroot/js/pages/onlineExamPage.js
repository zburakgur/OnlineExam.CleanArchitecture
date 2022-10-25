
var completeTheExam = function () {
    var answerList = [];
    for (var i = 1; i <= questionListSize; i++) {
        var selected = $("input[type='radio'][name='question_" + i + "_option']:checked");
        if (selected.length == 0) {
            App.showMessage('warning', 'You shoud select an answer for the question ' + i + '', '');
            return;
        }

        // radio id's last character is the option
        answerList.push(selected[0].id.substr(selected[0].id.length - 1));
    }

    $.confirm({
        title: 'Are you sure to complete the exam?!',
        content: 'Simple confirm!',
        buttons: {
            confirm: function () {
                sendAnswer(answerList);
            },
            cancel: function () {
                //$.alert('Canceled!');
            }
        }
    });
}

var sendAnswer = function (answerList) {
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