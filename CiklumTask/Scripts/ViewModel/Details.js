$(document).ready(function () {

    var currentPosition = 0;
    var slideWidth = 200;
    var slides = $('.slide');
    var numberOfSlides = slides.length;
    var slideShowInterval;
    var speed = 3000;

    slideShowInterval = setInterval(changePosition, speed);
    slides.wrapAll('<div id="slidesHolder"></div>')
    slides.css({ 'float': 'left' });

    $('#slidesHolder').css('width', slideWidth * numberOfSlides);

    function changePosition() {
        if (currentPosition == numberOfSlides - 1) {
            currentPosition = 0;
        } else {
            currentPosition++;
        }
        moveSlide();
    }
    function moveSlide() {
        $('#slidesHolder')
            .animate({ 'marginLeft': slideWidth * (-currentPosition) });
    }
});
function showPrices() {
    $("#Popup").modal(
        {
            persist: true,
            maxheight: 500,
            autoResize: true,
            onClose: function (dialog) {
                $("#Popup").hide("slow");
            }
        })
}
$(function () {
    var $popup = $("#showPrices");
    $("#showPrices").click(function () {
        $('#myModal').modal('show');
    });
    $('body').on('click', function (ev) {
        $('#myModal').hide("slow"); // click anywhere to hide the popup; all click events will bubble up to the body if not prevented
    });
    $("#showPrices").on('click', function (ev) {
        ev.stopPropagation(); // prevent event from bubbling up to the body and closing the popup
    });
});