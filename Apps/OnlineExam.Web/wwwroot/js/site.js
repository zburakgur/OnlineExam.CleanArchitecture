
var App = function () {
    "use strict";

    //// show loading in container
    var loading = {
        start: function () {
            $.blockUI()
        },
        end: function () {
            $.unblockUI();
        }
    }

    // toastr message types
    var messageType = {
        success: 'success',
        warning: 'warning',
        info: 'info',
        error: 'error'
    }

    // show toastr message 
    var showMessage = function (messageType, message, title) {
        if (message) {
            toastr[messageType](message, title);
        }
    }

    // jquery ajax post method
    var post = function (url, data, successCallBack, errorCallBack, isShowMessage) {
        var promise = $.ajax({
            url: url,
            type: 'POST',
            data: data,
            timeout: 200000
        });

        promise.done(function (d) {
            if (isShowMessage === true) {
                if (d.includes != null) {
                    if (d.includes('<!DOCTYPE html>')) {
                        var errorUrl = $($.parseHTML(d)).find('input[name="ErrorUrl"]').val();
                        if (errorUrl.includes('NotAccess'))
                            showMessage(messageType.error, 'Bu işlem için yetkiniz bulunmamaktadır.');
                        else if (errorUrl.includes('NotFound'))
                            showMessage(messageType.error, 'İşlem sayfası bulunamadı!');
                        else if (errorUrl.includes('Index'))
                            showMessage(messageType.error, 'Beklenmeyen bir hata oluştu!');
                    }
                }
                if (d.Status === 0) {
                    showMessage(messageType.error, d.Message);
                } else if (d.Status === 1) {
                    showMessage(messageType.success, d.Message);
                }
            }
            successCallBack(d);
        });
        if (errorCallBack) {
            promise.fail(function (d) {
                if (isShowMessage) {
                    showMessage(messageType.error, d.Message !== undefined ? d.Message : 'Beklenmeyen bir hata olustu. Hata Kodu: ' + d.status, 'Oupps!!');
                }
                errorCallBack(d);
            });
        } else {
            promise.fail(function (d) {
                showMessage(messageType.error, 'Beklenmeyen bir hata olustu. Hata Kodu: ' + d.status, 'Oupps!!');
            });
        }
    }

    return {
        /* global variables */
        post: post, // jquery ajax post method
        loading: loading, //show loading in container
        showMessage: showMessage,
        /* init */
        init: function () {
            //Metronic.init(); // init metronic core components
        }
    }

}();

var logoutFunction = function () {
    App.loading.start('#pageBody');
    App.post('/Login/Logout', {}, function (result) {        
        if (result.success) {
            App.showMessage('success', 'Goodbye', '');
            location.replace("..")
        }
        else
            App.showMessage('error', 'Operation fail.(' + result.message + ')', 'Error');
        App.loading.end('#pageBody');
    },
    false);
}