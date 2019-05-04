$(document).ready(function () {
    $("#AllTask").click(function () {
        $("#DashBoard > tbody").html("");

        if ($("#DashBoard tbody").length == 0) {
            $("#DashBoard").append("<tbody></tbody>");
        }
        $.ajax({
            type: "Post",
            url: "/Task/GetTasks",
            contentType: "application/json",
            dataType: "json",
            success: function (res) {
                $.each(res, function (data, value) {

                    $("#DashBoard tbody").append(
                        "<tr>" +
                        "<td style:\"display:none\">" + value.Id + "</td>" +
                        "<td>" + value.ProjectName + "</td>" +
                        "<td>" + value.TaskName + "</td>" +
                        "<td>" + value.TaskDescription + "</td>" +

                        "<td>" + moment(value.DueDate).format('MM/DD/YYYY') + "</td>" +
                        "<td style=\"display:none\">" + value.TaskStatus + "</td>" +
                        "<td>" + value.StatusName + "</td>" +
                        "<td style=\"display:none\">" + value.IsActive + "</td>" +
                        "<td>" + value.Active + "</td>" +
                        "<td>" + value.AssignTo + "</td>" +

                        "<td>" +
                        "<button type='button' " +
                        "onclick='TaskDelete(this);' " +
                        "class='btn btn-default' " +
                        "data-id='" + value.Id + "'>" +
                        "<span class='glyphicon glyphicon-remove' />" +
                        "</button>" +
                        "</td>" +
                        "</tr>"
                    )
                })
            }
        })
    });
});
