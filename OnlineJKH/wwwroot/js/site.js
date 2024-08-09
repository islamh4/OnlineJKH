$("#Image").change(function (e) {
    var files = e.target.files;
    $("#DisplayImage").attr("src", window.URL.createObjectURL(files[0]));
})
var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
    return new bootstrap.Tooltip(tooltipTriggerEl)
})
$('#modalWin').click(function (e) {
    e.preventDefault();
    $.get("/Home/ImportUser", function (data) {
        $('#dialogContent').html(data);
        $('#modDialog').modal('show');
    });
});
function ButSumbit() {
    if (window.FormData === undefined) {
        alert('В вашем браузере FormData не поддерживается')
    }
    var data = new FormData();
    var files = $("#fileExcel").get(0).files;
    if (files.length > 0) {
        data.append("excel", files[0]);
    }
    $.ajax(
        {
            url: "/Home/ImportUserPost",
            data: data,
            processData: false,
            contentType: false,
            type: "POST",
            success: function (data) {
                if (data.length > 0) {
                    console.log(data);
                    alert(data);
                }
            },
            complete: function () {
                $('#modDialog').modal('hide');
                location.reload();
            }
        }
    );
}