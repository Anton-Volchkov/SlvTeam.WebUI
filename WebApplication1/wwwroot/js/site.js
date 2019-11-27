$(document).ready(function () {
    $("#showFormWithQuestion").click(function () {
        $("#FormWithQuestion").slideDown("slow");
    });
});



function AddCoords() {
    navigator.geolocation.getCurrentPosition(
        function (position) {
            $.ajax({
                type: "POST",
                url: "/Location/SetLocation/",
                data: { lat: position.coords.latitude, lon: position.coords.longitude },

                success: function (data) {
                    location.reload();
                },
                error: function () {
                }
            });
        }
    );
}
