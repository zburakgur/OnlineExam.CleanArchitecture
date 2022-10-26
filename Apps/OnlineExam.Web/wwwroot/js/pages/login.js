var loginFunction = function () {
    var model = {
        UserName: $("#login").val(),
        Password: $("#password").val()
    }

    if (model.UserName.length == 0) {
        App.showMessage('warning', 'You should enter user name', '');
        return;
    }

    if (model.Password.length == 0) {
        App.showMessage('warning', 'You should enter password', '');
        return;
    }

    App.loading.start('#pageBody');
    App.post('/Login/CheckLogin', model, function (result) {
        if (result.success) {
            if (result.data == null) {
                App.showMessage('info', 'Username or password is invalid, please try again!', '');                
            }
            else {
                App.showMessage('success', 'Welcome to Online Exam Portal', '');
                location.replace("..")
            }
        }
        else
            App.showMessage('error', 'Operation fail.(' + result.message + ')', 'Error');
        App.loading.end('#pageBody');
    },
    false);
}