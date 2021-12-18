$(document).ready(function () {
    $('#rate').on('change', function () {
        $(this).closest('form').submit();
    });
});