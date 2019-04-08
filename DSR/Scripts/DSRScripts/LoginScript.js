$(document).ready(function () {
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
                        alert("Successfully Logged in");

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


