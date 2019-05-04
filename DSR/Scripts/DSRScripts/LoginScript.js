$(document).ready(function () {


    window.history.pushState(null, "", window.location.href);
    window.onpopstate = function () {
        window.history.pushState(null, "", window.location.href);
    };

    $("#LogIn").click(function () {
        if ($("#LoginId").val() == '' || $("#Password").val() == '') {
            alert("Some fields are missing");
        }
        else {
            $.ajax({
                type: "Post",
                url: "/Login/Authentication",
                cache: false,
                data: {
                    LoginId: $("#LoginId").val(),
                    Password: $("#Password").val()
                },
                success: function (result) {
                    if (result.IsValid) {
                        window.location = "/Dashboard/Index";

                    }
                    else {
                        alert(result.ErrorMessage);
                    }
                }

            })

        }
    });
}
);


