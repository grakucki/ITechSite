


//dataType : " json " ,
//    contentType : " application / json; charset = utf-8 " ,
//    Dane :  JSON . stringify ({pierwszy : " aaa " , druga : " dwa " }),
// dane: {pierwsza: "aaa", druga: "dwóch"},

// odświeża w tle Combobox
// cScr żródłowa kontrolka która wyzwoli pobranie nowych danych
// cDes kontrolka która będzie odświeżona
// Nazwa metody na serwerze
// Nazwa panelu z informacją o pracy
function CascadingOption(cScr, cDes, onAction, onProgress) {
    $(document.getElementById(cScr)).change(function () {
        var selectedItem = $(this).val();
        var ddlStates = $(document.getElementById(cDes));
        var statesProgress = $(document.getElementById(onProgress));
        statesProgress.show();
        $.ajax({
            cache: false,
            type: "POST",
            url: onAction,
            data: cScr + "=" + selectedItem,
            success: function (data) {
                var select23 = ddlStates.val();
                ddlStates.html('');
                $.each(data, function (id, option) {
                    ddlStates.append($('<option></option>').val(option.id).html(option.name));
                });
                //                ddlStates.value = select23;
                document.getElementById(cDes).value = select23;
                statesProgress.hide();
                var newsel = ddlStates.val();
                if (newsel == null)
                    document.getElementById(cDes).selectedIndex = 0;
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert('Failed to retrieve.');
                statesProgress.hide();
            }
        });
    });
}


function CascadingOption2(cScr, cScr2, cDes, onAction, onProgress) {
    $(document.getElementById(cScr)).change(function () {
        var selectedItem = $(this).val();
        var selectedItem2 = document.getElementById(cScr2).value;

        var ddlStates = $(document.getElementById(cDes));
        var statesProgress = $(document.getElementById(onProgress));
        statesProgress.show();
        $.ajax({
            cache: false,
            type: "POST",
            url: onAction,
            data: cScr + "=" + selectedItem + "&" + cScr2 + "=" + selectedItem2,
            success: function (data) {
                var select23 = ddlStates.val();
                ddlStates.html('');
                $.each(data, function (id, option) {
                    ddlStates.append($('<option></option>').val(option.id).html(option.name));
                });
                //                ddlStates.value = select23;
                document.getElementById(cDes).value = select23;
                statesProgress.hide();
                var newsel = ddlStates.val();
                if (newsel == null)
                    document.getElementById(cDes).selectedIndex = 0;
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert('Failed to retrieve.');
                statesProgress.hide();
            }
        });
    });
}

function OptionChangeCss(cScr) {
    //$(document.getElementById(cScr)).change(function () {
    $(cScr).change(function () {
            OnOptionChangeCss(cScr)
        }
    );
    OnOptionChangeCss(cScr)
}

function OnOptionChangeCss(cScr) {
    //var a = $(cScr+' :selected').text();
    //var b = $(cScr+' :selected').val();
    
    var c = $(cScr+ " option:selected").attr("class");
    $(cScr).removeClass();
    $(cScr).addClass("form-control " + c);
    //$("#" + "NewNews").removeClass();
    //$("#" + "NewNews").addClass("form-control text-News "+ c);
    //console.debug(c);
}


function InitModal() {
    $('.someclass').on('click', function () {
        var itemid = $(this).attr('id');
        $(".modal-content2").load("../ShowRoles?id=" + itemid, function( response, status, xhr ) {
            if (status == "error") {
                var msg = "Sorry but there was an error: ";
                $("#error").html(msg + xhr.status + " " + xhr.statusText);
            }
        });
    });

};

function AddDatePicker(control)
{
    //$.datepicker.setDefaults($.datepicker.regional['pl']);
    $(control).datepicker({ changeMonth: true, changeYear: true, dateFormat: "yy-mm-dd" });
    $.datepicker.regional['pl']
    //$("#ValidEnd").datepicker({ changeMonth: true, changeYear: true, dateFormat: "yy-mm-dd" });
};

function AddDateTimePicker(control) {
    $.datetimepicker.setLocale('pl');
    $(control).datetimepicker({ format: "Y-m-d H:i:s"});
};