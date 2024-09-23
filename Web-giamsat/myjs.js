//$(function () {
//    $(".nguoi").draggable();
//});

function openDialog(id, positionId) {
    // Sử dụng AJAX để lấy lịch sử từ server
    $.ajax({
        url: 'asp.aspx/get_history',  // File ASPX với WebMethod
        type: 'POST',
        data: JSON.stringify({ id: id }),  // Truyền tham số dưới dạng JSON
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            // Hiển thị dữ liệu lịch sử trong dialog
            $('#dialogContent').html(response.d);  // Dữ liệu trả về từ WebMethod

            // Mở hộp thoại
            $("#dialog").dialog({
                modal: true,
                width: 400,
                height: 200,
                buttons: {
                    "Đóng": function () {
                        $(this).dialog("close");
                    }
                }
            });
        },
        error: function (xhr, status, error) {
            $('#dialogContent').html("Đã có lỗi xảy ra: " + error);
            $("#dialog").dialog({
                modal: true,
                width: 400,
                height: 200,
                buttons: {
                    "Đóng": function () {
                        $(this).dialog("close");
                    }
                }
            });
        }
    });
}

$(function () {
    function set_status(id_sv, id_vitri){
        if (id_vitri == 1) {
            $(id_sv).text("chợ");
        }
        else if (id_vitri == 2) {
            $(id_sv).text("trường");
        }
        else if (id_vitri == 3) {
            $(id_sv).text("nhà");
        }
        else if (id_vitri == 4) {
            $(id_sv).text("trọ");
        }
        else if (id_vitri == 5) {
            $(id_sv).text("không rõ");
        } 
    }
    function request_api_get_status_room() {
        $.post('asp.aspx', { action: 'get_status' }, function (data) {
            try {
                var json = JSON.parse(data);
                if (json.ok === "true") {
                    for (var i = 0; i < json.vitrisv.length; i++) {

                        if (json.vitrisv[i] == 1) {
                            $('#vitrichung' + (i + 1)).text("chợ");
                        } else if (json.vitrisv[i] == 2) {
                            $('#vitrichung' + (i + 1)).text("trường");
                        } else if (json.vitrisv[i] == 3) {
                            $('#vitrichung' + (i + 1)).text("nhà");
                        } else if (json.vitrisv[i] == 4) {
                            $('#vitrichung' + (i + 1)).text("trọ");
                        } else if (json.vitrisv[i] == 5) {
                            $('#vitrichung' + (i + 1)).text("không biết");
                        }

                    }
                } else {
                    $('#loioday').html(json.msg);
                }
            } catch (e) {
                console.error("Lỗi phân tích JSON: ", e);
                $('#loioday').html("Có lỗi xảy ra khi xử lý dữ liệu.");
            }
        });
    }

    setInterval(function () { request_api_get_status_room(); }, 5000);
   //gọi 5000ms/lần
});
