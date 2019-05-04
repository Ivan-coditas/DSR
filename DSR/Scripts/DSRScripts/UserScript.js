$(document).ready(function () {
    $.ajax({
        type: "Post",
        url: "/User/GetUserRole",
        dataType: "json",
        contentType: "application/json",
        
        success: function (res) {
            $.each(res, function (data, value) {
                {
                    $("#ddlRole").append($("<option></option>").val(value.Id).html(value.Role));

                }
            })
        }
    });


    //Appending UserNames to DropDown

    $.ajax({
        type: "Post",
        url: "/User/GetTeamLeads",
        dataType: "json",
        contentType: "application/json",
        success: function (res) {
            $.each(res, function (data, value) {
                {
                    $("#ddlLead").append($("<option></option>").val(value.Id).html(value.UserName));
                }
            })
        }
    });


    $("#ddlRole").on('change', function () {

        if (this.value == '1') {
            $("#RID").hide();

        }

        else if (this.value == '2') {
            $("#RID").show();

        }
    });


    $("#Submit").click(function ()
    {
        if ($("#UserName").val() == '' || $("#Password").val() == '' || $("#ddlRole").val() == '' || $("#LoginId").val() == '' || $("#EmailId").val() == '' || ($("#ddlRole").val() == '2' && $("#ddlLead").val() ==''))
        {
            alert("Some field is missing");
        }
        else
        {
            var user =
            {
                Id: activeId,
                UserName: $("#UserName").val(),
                LoginId: $("#LoginId").val(),
                EmailId: $("#EmailId").val(),
                Password: $("#Password").val(),
                RoleId: $("#ddlRole").val(),
                ReportingId: $("#ddlLead").val(),
                Description: $("#Description").val(),
                IsActive: $('#IsActive').is(':checked')
            }

            var PostUrl = "";
            if ($("#Submit").text() == "Update") {
                PostUrl = "/User/UpdateUser";
            }
            else {
                PostUrl = "/User/AddUser";
            }

           

            $.ajax
            ({
                type: "POST",
                url: PostUrl,
                data: user,
                cache: false,
                success: function (result)
                {
                    alert("User Saved");
                    $("#Submit").text("Submit");

                    reset();
                    getUsers();
                }
                });
          
        }

    });
    getUsers();

});


var activeId = 0;
function UserDisplay(ctl) {
    var row = $(ctl).parents("tr");
    var cols = row.children("td");

    activeId = $($(cols[0]).children("button")[0]).data("id");
    var selectedRole = $(cols[6]).text()
    $("#UserName").val($(cols[2]).text());
    $("#LoginId").val($(cols[3]).text());
    $("#EmailId").val($(cols[4]).text());
    $("#Password").val($(cols[5]).text());
    $("#ddlRole").val($(cols[6]).text());
    $("#ddlLead").val($(cols[8]).text());

    if ($("#ddlRole").val() == '1')
    {
        $("#RID").hide();

    }

    else if ($("#ddlRole").val() == '2') {
        $("#RID").show();

    }
    $("#Description").val($(cols[10]).text());
    $("#IsActive").prop('checked',($(cols[11]).text()=='true'));
  

    // Change Update Button Text
  $("#Submit").text("Update");
}

//    Delete User from table
function UserDelete(ctl) {
    var row = $(ctl).parents("tr");
    var cols = row.children("td");

    var Id = $($(cols[0]).children("button")[0]).data("id");
    
    $.ajax
        ({
            type: "POST",
            url: "/User/DeleteUser",
            data: { 'Id': Id },
            cache: false,
            success: function (result) {
                alert("User Deleted");
               

                reset();

                $(ctl).parents("tr").remove();
               
            }
        });

      
}

function reset() {
    activeId = 0;
  
    $("#UserName").val('');
    $("#LoginId").val('');
    $("#EmailId").val('');
    $("#Password").val('');
    $("#ddlRole").val('');
    $("#ddlLead").val('');
    $("#Description").val('');
    $("#IsActive").prop('checked', false);


}

// Add users to <table>

function getUsers() {
    $("#UserTable > tbody").html(""); 
    // First check if a <tbody> tag exists, add one if not
    if ($("#UserTable tbody").length == 0)  //Counts no. of rows in table(total <tr> tags)
    {
        $("#UserTable").append("<tbody></tbody>");
    }

    
 $.ajax({
        type: "Post",
        url: "/User/GetUsers",
        dataType: "json",
        contentType: "application/json",
        success: function (res) {
            $.each(res, function (data, value) {
                {
                    // Append Users to the table
                    $("#UserTable tbody").append(
                        "<tr>" +
                        "<td>" +
                        "<button type='button' " +
                        "onclick='UserDisplay(this);' " +
                        "class='btn btn-default' " +
                        "data-id='" + value.Id  + "'>" +
                        "<span class='glyphicon glyphicon-edit' />" +
                        "</button>" +
                        "</td>" +

                        "<td style=\"display: none\">" + value.Id + "</td>" +
                        "<td>" + value.UserName + "</td>" +
                        "<td>" + value.LoginId + "</td>" +
                        "<td>" + value.EmailId + "</td>" +
                        "<td>" + value.Password + "</td>" +
                        "<td style=\"display: none\">" + value.RoleId + "</td>" +
                        "<td>" + value.RoleName + "</td>" +

                        "<td style=\"display: none\">" + value.ReportingId + "</td>" +
                        "<td>" + value.ReportingName + "</td>" +

                        "<td>" + value.Description + "</td>" +
                        "<td style=\"display: none\">" + value.IsActive + "</td>" +
                        "<td>" + value.Active + "</td>" +
                       
                        "<td>" +
                        "<button type='button' " +
                        "onclick='UserDelete(this);' " +
                        "class='btn btn-default' " +
                        "data-id='" + value.Id+ "'>" +
                        "<span class='glyphicon glyphicon-remove' />" +
                        "</button>" +
                        "</td>" +

                        "</tr>"
                    );
                }
            })
        }
    });
  
    
}
