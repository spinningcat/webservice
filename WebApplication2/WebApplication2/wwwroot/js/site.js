$(function () {
    var $button = $('.sistem');
    var $tableButton = $('.tableButton');
    $button.on('click', function () {
       
        var username = $(this).closest('.LoginContainer').find('#user').val();
        var password = $(this).closest('.LoginContainer').find('#pass').val();
        console.log(password);

        $.ajax({
            type: "POST",
            url: "http://localhost:60809/Home/Login",
            data: { username: username, password: password },
            success: function () {
                console.log("giriş başarılı.");
                window.location = "http://localhost:60809/Dashboard/Index"
            }
             //dataType: "json",
             //contentType: "application/json;charset=utf-8",

        });


    });
    $('.tableButton').on('click', function () {
      
        $.ajax({
            type: "GET",
            url: "http://localhost:60809/Dashboard/ConstructATable",
            //data: { jsonTable: jsonTable },
            //  datatype: JSON,
            success: function (data) {
                console.log(data);

            }
        });
    });
});