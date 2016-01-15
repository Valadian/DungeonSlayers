
function addSelectItem(t, ev) {
    ev.stopPropagation();

    var txt = $(t).prev().val().replace(/[|]/g, "");
    if ($.trim(txt) == '') return;
    //var p=$('#select1');
    var p = $(ev.currentTarget.parentElement.parentElement.parentElement.parentElement.parentElement.previousSibling);
    //var o=$('#select1 option').eq(-2);
    var o = p.children('option').eq(-2);
    o.before($("<option>", { "selected": true, "text": txt }));
    p.selectpicker('refresh');
}

function addSelectInpKeyPress(t, ev) {
    ev.stopPropagation();

    // do not allow pipe character
    if (ev.which == 124) ev.preventDefault();

    // enter character adds the option
    if (ev.which == 13) {
        ev.preventDefault();
        addSelectItem($(t).next(), ev);
    }
}

//$(document).ready(function () {
//    $('.selectpicker').selectpicker();
//});
(function () { Math.clamp = function (a, b, c) { return Math.max(b, Math.min(c, a)); } })();

$(document).ready(function () {
    var $width = $(window).width() / 10;
    $('img.resize-1b8').attr({
        width: Math.clamp($width, 90, 125)
    })
    $(window).bind('resize', function () {
        var $width = $(window).width() / 10;
        $('img.resize-1b8').attr({
            width: Math.clamp($width, 90, 125)
        })
    })
})

$(function () {
    $('.input-group:has(.input-group-vert-addon)').css('display', 'block');;
})

//jQuery(document).ready(function ($) {
//    $('#add-weapon').on('click', function () {
//        jQuery.get('/Characters/AddWeapon').done(function (html) {
//            $('#weapons-list').append(html);
//        });
//    });
//});