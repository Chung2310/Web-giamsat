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
