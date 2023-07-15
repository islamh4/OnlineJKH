$("#Image").change(function (event) {
    var files = event.target.files;
    $("#DisplayImage").attr("src", window.URL.createObjectURL(files[0]));
});
var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
    return new bootstrap.Tooltip(tooltipTriggerEl)
})