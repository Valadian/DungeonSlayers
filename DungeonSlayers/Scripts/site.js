
(function () { Math.clamp = function (a, b, c) { return Math.max(b, Math.min(c, a)); } })();

function switchTo(character,weapon){
    for (var w in character.Weapons) {
        w.Equipped(false);
    }
    weapon.Equipped(true);
}

$(document).ready(function () {
    var $width = $(window).width() / 10;
    $('img.resize-1b8').attr({
        width: Math.clamp($width, 90, 125)
    });
    $(window).bind('resize', function () {
        var $width = $(window).width() / 10;
        $('img.resize-1b8').attr({
            width: Math.clamp($width, 90, 125)
        })
    });
    $('.pull-down').each(function () {
        $(this).css('margin-top', $(this).parent().height() - $(this).height() - 10)
    });
    //$(window).scroll(function () {
    //    var floats = $('.float-me');
    //    //for (var i in $('.float-me')) {
    //    for (var i = 0; i < floats.length; i++) {
    //        var float = $(floats.get(i))
    //        if ($(window).scrollTop() > float.offset().top - $('.navbar').height() - 5) {
    //            float.addClass("floating");
    //            if (float.data('spaceholder').length > 0) {
    //                float.css(
    //                    { 'width': $('#' + float.data('spaceholder')).width() + 1 })
    //            }
    //        } else {
    //            float.removeClass("floating");
    //            if (float.data('spaceholder').length > 0) {
    //                float.css(
    //                    { 'width': '' })
    //            }
    //        }
    //    }
    //})
})

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


$(function () {
    $('.input-group:has(.input-group-vert-addon)').css('display', 'block');;
});

ko.bindingHandlers.selectPicker = {
    init: function (element, valueAccessor, allBindingsAccessor) {
        if ($(element).is('select')) {
            if (ko.isObservable(valueAccessor())) {
                if ($(element).prop('multiple') && $.isArray(ko.utils.unwrapObservable(valueAccessor()))) {
                    // in the case of a multiple select where the valueAccessor() is an observableArray, call the default Knockout selectedOptions binding
                    ko.bindingHandlers.selectedOptions.init(element, valueAccessor, allBindingsAccessor);
                } else {
                    // regular select and observable so call the default value binding
                    ko.bindingHandlers.value.init(element, valueAccessor, allBindingsAccessor);
                }
            }
            $(element).addClass('selectpicker').selectpicker();
        }
    },
    update: function (element, valueAccessor, allBindingsAccessor) {
        if ($(element).is('select')) {
            var selectPickerOptions = allBindingsAccessor().selectPickerOptions;
            if (typeof selectPickerOptions !== 'undefined' && selectPickerOptions !== null) {
                var options = selectPickerOptions.optionsArray,
                    optionsText = selectPickerOptions.optionsText,
                    optionsValue = selectPickerOptions.optionsValue,
                    optionsCaption = selectPickerOptions.optionsCaption,
                    isDisabled = selectPickerOptions.disabledCondition || false,
                    resetOnDisabled = selectPickerOptions.resetOnDisabled || false;
                if (ko.utils.unwrapObservable(options).length > 0) {
                    // call the default Knockout options binding
                    ko.bindingHandlers.options.update(element, options, allBindingsAccessor);
                }
                if (isDisabled && resetOnDisabled) {
                    // the dropdown is disabled and we need to reset it to its first option
                    $(element).selectpicker('val', $(element).children('option:first').val());
                }
                $(element).prop('disabled', isDisabled);
            }
            if (ko.isObservable(valueAccessor())) {
                if ($(element).prop('multiple') && $.isArray(ko.utils.unwrapObservable(valueAccessor()))) {
                    // in the case of a multiple select where the valueAccessor() is an observableArray, call the default Knockout selectedOptions binding
                    ko.bindingHandlers.selectedOptions.update(element, valueAccessor);
                } else {
                    // call the default Knockout value binding
                    ko.bindingHandlers.value.update(element, valueAccessor);
                }
            }

            $(element).selectpicker('refresh');
        }
    }
};

//ko.bindingHandlers.chosen =
//{
//    init: function (element) {
//        $(element).addClass('chosen-select');
//        $(element).chosen();
//    },
//    update: function (element) {
//        $(element).trigger('liszt:updated');
//        $(element).trigger('chosen:updated');
        
//    }
//};
ko.bindingHandlers.chosen = {
    init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        var $element = $(element);
        var options = ko.unwrap(valueAccessor());

        if (typeof options === 'object')
            $element.chosen(options);
        else
            $element.chosen();

        ['options', 'selectedOptions', 'value'].forEach(function (propName) {
            if (allBindings.has(propName)) {
                var prop = allBindings.get(propName);
                if (ko.isObservable(prop)) {
                    prop.subscribe(function () {
                        $element.trigger('chosen:updated');
                    });
                }
            }
        });
    }
}