$(document).ready(function () {


        $("#DueDate").datepicker();
  
    


    //DropDown For Projects
    $.ajax({
        type: "Post",
        url: "/Project/GetProjects",
        dataType: "json",
        contentType: "application/json",
        success: function (res) {
            $.each(res, function (data, value) {
                {
                    $("#ProjectId").append($("<option></option>").val(value.Id).html(value.Name));
                }
            })
        }
    });


   

    $("#Submit").click(function () {
        if ($("#ProjectId").val() == '' || $("#TaskName").val() == '' || $("#TaskDescription").val() == '' || $("#DueDate").val() == '' || $("#TaskStatus").val() == '' || $("#IsActive").val() == '') {
            alert("Some fields are missing");
        }
        else {
            var task = {
                Id: activeId,
                ProjectId: $("#ProjectId").val(),
                TaskName: $("#TaskName").val(),
                TaskDescription: $("#TaskDescription").val().toString(),
                DueDate: $("#DueDate").val(),
                TaskStatus: $("#TaskStatus").val(),
                IsActive: $("#IsActive").is(':checked')

            }

            var PostUrl = "";
            if ($("#Submit").text() == "Update") {
                PostUrl = "/Task/UpdateTask";
            } else {
                PostUrl = "/Task/AddTask";
            }
            $.ajax({
                type: "Post",
                url: PostUrl,
                cache: false,
                data: task,
                success: function () {
                    alert("Task Saved");
                    $("#Submit").text("Submit");
                    reset();
                    getTask();
                }
            });
        }
    });
    getTask();
});





function reset() {
    $("#ProjectId").val() == '';
    $("#TaskName").val() == '';
    $("#TaskDescription") == '';
    $("#DueDate") == '';
    $("#TaskStatus") == '';
    $("#IsActive") == '';
}

//Add Task to <table>
function getTask() {
    $("#TaskTable > tbody").html("");
    //first check if a <tbody> tag exists, add one if not
    if ($("#TaskTable tbody").length == 0) {
        $("#TaskTable").append("<tbody></tbody>");
    }
    $.ajax({
        type: "Post",
        url: "/Task/GetTasks",
        dataType: "json",
        contentType: "application/json",
        success: function (res) {
            $.each(res, function (data, value) {


                //Append tasks to table
                $("#TaskTable tbody").append(
                "<tr>" +
                    "<td>" +
                    "<button type='button' " +
                    "onclick='TaskDisplay(this);'" +
                    "class='btn btn-default' " +
                    "data-id='" + value.Id + "'>" +
                    "<span class='glyphicon glyphicon-edit' />" +
                    "</button>" +
                    "</td>" +

                    "<td style=\"display:none\"\">" + value.Id + "</td>" +

                    "<td style=\"display:none\">" + value.ProjectId + "</td>" +
                    "<td>" + value.ProjectName + "</td>" +



                    "<td>" + value.TaskName + "</td>" +



                    "<td>" + value.TaskDescription + "</td>" +
                    "<td>" + moment(value.DueDate).format('MM/DD/YYYY')+ "</td>" +
                    "<td style=\"display:none\">" + value.TaskStatus + "</td>" +


                    "<td>" + value.StatusName+"</td>"+
                    "<td style=\"display:none\">" + value.IsActive + "</td>" +
                    "<td>" + value.Active + "</td>" +


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

   }



//Display project on click event(edit button)
var activeId = 0;

function TaskDisplay(ctl) {
    var row = $(ctl).parents("tr");
    var cols = row.children("td");

    activeId = $($(cols[0]).children("button")[0]).data("id");

    $("#ProjectId").val($(cols[2]).text());
    $("#TaskName").val($(cols[4]).text());

    $("#TaskDescription").val($(cols[5]).text());
    $("#DueDate").val(moment($(cols[6]).text()).format('MM/DD/YYYY'));

    $("#TaskStatus").val($(cols[7]).text());

    $("#IsActive").prop('checked', ($(cols[8]).text() == 'true'));

    $("#Submit").text("Update");

}

function TaskDelete(ctl) {
    var row = $(ctl).parents("tr");
    var cols = row.children("td");

    var Id = $($(cols[0]).children("button")[0]).data("id");


    $.ajax({
        type: "Post",
        url: "/Task/DeleteTask",
        data: { 'Id': Id },
        cache: false,
        success: function () {
            alert("Task deleted");


            reset();
            $(ctl).parents("tr").remove();
        }
    });
}