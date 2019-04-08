$(document).ready(function () {
    //$.ajax({
    //    type: "Post",
    //    url: "User/GetUserRole",
    //    dataType: "json",
    //    contentType: "application/json",

    //    success: function (res) {
    //        $.each(res, function (data, value) {
    //            {
    //                $("#UserId").append($("<option></option>").val(value.Id).html(value.UserId));

    //            }
    //        })
    //    }
    //});


    ////Reporting DropDown

    //$.ajax({
    //    type: "Post",
    //    url: "User/GetTeamLeads",
    //    dataType: "json",
    //    contentType: "application/json",
    //    success: function (res) {
    //        $.each(res, function (data, value) {
    //            {
    //                $("#ProjectId").append($("<option></option>").val(value.Id).html(value.ProjectId));
    //            }
    //        })
    //    }
    //});


    $("#Submit").click(function () {
        if ($("#ProjectId").val() == '' || $("#UserId").val() == '' || $("#Description").val() == '' || $("#IsActive").val() == '') {
            alert("Some fields are misssing");
        }
        else {
            var projectteam = {
                Id: activeId,
                ProjectId: $("#ProjectId").val(),
                UserId: $("#UserId").val(),
                Description: $("#Description").val(),
                IsActive: $("#IsActive").is(':checked')

            }
            var PostUrl = "";
            if ($("#Submit").text() == "Update") {
                PostUrl = "/AssignProjects/UpdateProjectTeam";
            }
            else {
                PostUrl = "/AssignProjects/AddProjectTeam";
            }

            $.ajax({
                type: "Post",
                url: PostUrl,
                cache: false,
                data: projectteam,
                success: function () {
                    alert("Project Team Saved");
                    $("#Submit").text("Submit");

                    reset();
                    getProjectTeam();
                }


            });
        }
        });
    getProjectTeam();

});


//To reset registration form
function reset() {
    $("#ProjectId").val() == '';
    $("#UserId").val() == '';
    $("#Description").val() == '';
    $("#IsActive").prop('checked', false);

}

//Add ProjectTeam to <table>
function getProjectTeam() {

    $("#ProjectTeamTable > tbody").html("");
    //first check if a <tbody> tag exists, add one if not
    if ($("#ProjectTeamTable tbody").length == 0) {
        $("#ProjectTeamTable").append("<tbody></tbody>");
    }

    $.ajax({
        type: "Post",
        url: "/AssignProjects/GetProjectTeam",
        dataType: "json",
        contentType: "application/json",
        success: function (res) {
            $.each(res, function (data, value) {

                //Append projects to table
                $("#ProjectTeamTable tbody").append(
                    "<tr>" +
                    "<td>" +
                    "<button type='button' " +
                    "onclick='ProjectTeamDisplay(this);'" +
                    "class='btn btn-default' " +
                    "data-id='" + value.Id + "'>" +
                    "<span class='glyphicon glyphicon-edit' />" +
                    "</button>" +
                    "</td>" +

                    "<td style=\"display:none\"\">" + value.Id + "</td>" +

                    "<td>" + value.ProjectId + "</td>" +
                    "<td>" + value.UserId + "</td>" +

                    "<td>" + value.Description + "</td>" +
                    "<td>" + value.IsActive + "</td>" +

                    "<td>" +
                    "<button type='button' " +
                    "onclick='ProjectTeamDelete(this);' " +
                    "class='btn btn-default' " +
                    "data-id='" + value.UserId + "'>" +
                    "<span class='glyphicon glyphicon-remove' />" +
                    "</button>" +
                    "</td>" +

                    "</tr>"
                )

            });
        }
    })
}

//Display project on click event(edit button)
var activeId = 0;
function ProjectTeamDisplay(ctl) {
    var row = $(ctl).parents("tr");
    var cols = row.children("td");

    activeId = $($(cols[0]).children("button")[0]).data("id");

    $("#ProjectId").val($(cols[2]).text());
    $("#UserId").val($(cols[3]).text());

    $("#Description").val($(cols[4]).text());
    $("#IsActive").prop('checked', ($(cols[5]).text() == 'true'));

    $("#Submit").text("Update");

}

//delete from table

function ProjectTableDelete(ctl) {
    var row = $(ctl).parents("tr");
var cols = row.children("td");

var Id = $($(cols[0]).children("button")[0]).data("id");


$.ajax({
    type: "Post",
    url: "/AssignProjects/DeleteProjectTeam",
    data: { 'Id': Id },
    cache: false,
    success: function () {
        alert("ProjectTeam deleted");


        reset();
        $(ctl).parents("tr").remove();
    }
});
}