$(document).ready(function () {
    $("#Submit").click(function ()
    {
        if ($("#Name").val() == '' || $("#Description").val() == '' || $("#IsActive").val()=='')
        {
            alert("Some field is missing");
        }
        else
        {
            var projects =
            {
                Id: activeId,
                Name: $("#Name").val(),
                Description: $("#Description").val(),
                IsActive: $('#IsActive').is(':checked')
            }
            var PostUrl = "";
            if ($("#Submit").text() == "Update") {
                PostUrl = "/Project/UpdateProject";

            }
            else
            {
                PostUrl = "/Project/AddProject";
            }

            $.ajax(
                {
                    type: "POST",
                    url: PostUrl,
                    cache: false,
                    data: projects,
                    success: function () {
                        alert("Project Saved");
                        $("#Submit").text("Submit");

                        reset();
                        getProjects();
                    }
                });
        }

        
    });
    getProjects();
});

// To reset registration form

function reset()
{
    activeId = 0;
    $("#Name").val('');
    $("#Description").val('');
    $("#IsActive").prop('checked', false);
}

    //// Add projects to <table>

function getProjects()
{
        $("#ProjectTable > tbody").html("");
// First check if a <tbody> tag exists, add one if not
        if ($("#ProjectTable tbody").length == 0)
        {
            $("#ProjectTable").append("<tbody></tbody");
        }


  //  debugger;
    $.ajax({
        
            type: "Post",
            url: "/Project/GetProjects",
            dataType: "json",
            contentType: "application/json",
            success: function (res) {
                $.each(res, function (data, value) {

                    //Append projects to table
                    $("#ProjectTable tbody").append(
                        "<tr>" +
                        "<td>" +
                        "<button type='button' " +
                        "onclick='ProjectDisplay(this);'" +
                        "class='btn btn-default' " +
                        "data-id='" + value.Id + "'>" +
                        "<span class='glyphicon glyphicon-edit' />" +
                        "</button>" +
                        "</td>" +

                        "<td style=\"display:none\"\">" + value.Id + "</td>" +
                        "<td>" + value.Name + "</td>" +
                        "<td>" + value.Description + "</td>" +
                        "<td>" + value.IsActive + "</td>" +

                        "<td>" +
                        "<button type='button' " +
                        "onclick='ProjectDelete(this);' " +
                        "class='btn btn-default' " +
                        "data-id='" + value.Id + "'>" +
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
function ProjectDisplay(ctl) {
    var row = $(ctl).parents("tr");
    var cols = row.children("td");

    activeId = $($(cols[0]).children("button")[0]).data("id");
    $("#Name").val($(cols[2]).text());
    $("#Description").val($(cols[3]).text());
    $("#IsActive").prop('checked', ($(cols[4]).text() == 'true'));

    // Change Update Button Text
    $("#Submit").text("Update");
}


//delete from table
function ProjectDelete(ctl) {
    var row = $(ctl).parents("tr");
    var cols = row.children("td");

    var Id = $($(cols[0]).children("button")[0]).data("id");
   

    $.ajax({
        type: "Post",
        url: "/Project/DeleteProject",
        data: { 'Id': Id },
        cache: false,
        success: function () {
            alert("Project deleted");


            reset();
            $(ctl).parents("tr").remove();
        }
    });
}