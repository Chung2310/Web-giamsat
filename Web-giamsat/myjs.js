//$(function () {
//    $(".nguoi").draggable();
//});

let currentVitrichungId;

function openDialog(nguoiName, vitrichungId) {
    document.getElementById('nguoi-name').textContent = nguoiName;
    currentVitrichungId = vitrichungId; 
    document.getElementById('infoDialog').showModal();
}

function closeDialog() {
    document.getElementById('infoDialog').close();
}

document.addEventListener("DOMContentLoaded", function () {
    const button = document.getElementById("btngui");

    button.addEventListener("click", function (event) {
        event.preventDefault(); 

        const input = document.getElementById("name").value;

        if (currentVitrichungId && input) {
            const output = document.getElementById(currentVitrichungId);
            output.textContent = input;
        }

        closeDialog();
    });
});

window.onclick = function (event) {
    var dialog = document.getElementById('infoDialog');
    if (event.target == dialog) {
        dialog.close();
    }
};

window.onkeydown = function (event) {
    var dialog = document.getElementById('infoDialog');
    if (event.key === 'Escape' && dialog.open) {
        dialog.close();
    }
};

$(function () {
    //    $(".nguoi").draggable();
    //});

    function request_api_get_status_room() {
        $.post('asp.aspx', {}, function (data) {
            var json = JSON.parse(data);
            if (json.ok) {
                for (var i = 0; i < json.sv.length; i++) {
                    if (json.sv[i] == 1) {
                        $('#vitrichung' + (i + 1)).text("chợ");
                    } else if (json.sv[i] == 2) {
                        $('#vitrichung' + (i + 1)).text("trường");
                    } else if (json.sv[i] == 3) {
                        $('#vitrichung' + (i + 1)).text("nhà");
                    } else if (json.sv[i] == 4) {
                        $('#vitrichung' + (i + 1)).text("trọ");
                    } else if (json.sv[i] == 5) {
                        $('#vitrichung' + (i + 1)).text("không biết");
                    }
                }
            } else {
                $('loioday').html(json.msg);
            }
        });
    }
    setInterval(function () { request_api_get_status_room(); }, 1000);
});