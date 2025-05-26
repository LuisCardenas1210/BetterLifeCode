function validateRutinaLength(sender, args) {
    var rutina = document.getElementById("txtRutina").value;
    args.IsValid = rutina.length >= 35 && rutina.length <= 4000;
}

$(function () {
    $("#lblMensaje").text("");
});
