// VALIDATION START AND FINISH DATE [ATTR]: oninput
// #region Datepicker oninput
function validateStartDate() {
    var dateInput = document.getElementById("startdate");
    var date = dateInput.value;
    var dateRegex = /^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$/;

    dateInput.style.color = "white";

    if (dateRegex.test(date)) {
        dateInput.style.backgroundColor = "rgba(0, 193, 41, 0.5)";
        document.getElementById("SubPart").disabled = false;
    }
    else {
        dateInput.style.backgroundColor = "rgba(255, 0, 17, 0.6)";
        document.getElementById("SubPart").disabled = true;
    }
}
function validateStartDate1() {
    var dateInput = document.getElementById("startdate1");
    var date = dateInput.value;
    var dateRegex = /^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$/;

    dateInput.style.color = "white";

    if (dateRegex.test(date)) {
        dateInput.style.backgroundColor = "rgba(0, 193, 41, 0.5)";
        document.getElementById("filterButton").removeAttribute("disabled", "disabled");
    }
    else {
        dateInput.style.backgroundColor = "rgba(255, 0, 17, 0.6)";
        document.getElementById("filterButton").setAttribute("disabled", "disabled");
    }
    if (date === "") {
        dateInput.style.backgroundColor = "white";
        document.getElementById("filterButton").removeAttribute("disabled", "disabled");
    }
}

function validateEndDate() {
    var dateInput = document.getElementById("finishdate");
    var date = dateInput.value;
    var dateRegex = /^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$/;

    dateInput.style.color = "white";

    if (dateRegex.test(date)) {
        dateInput.style.backgroundColor = "rgba(0, 193, 41, 0.5)";
        document.getElementById("SubPart").disabled = false;
    }
    else {
        dateInput.style.backgroundColor = "rgba(255, 0, 17, 0.6)";
        document.getElementById("SubPart").disabled = true;
    }
}
function validateEndDate1() {
    var dateInput = document.getElementById("finishdate1");
    var date = dateInput.value;
    var dateRegex = /^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$/;

    dateInput.style.color = "white";

    if (dateRegex.test(date)) {
        dateInput.style.backgroundColor = "rgba(0, 193, 41, 0.5)";
        document.getElementById("filterButton").removeAttribute("disabled", "disabled");
    }
    else {
        dateInput.style.backgroundColor = "rgba(255, 0, 17, 0.6)";
        document.getElementById("filterButton").setAttribute("disabled", "disabled");
    }
    if (date === "") {
        dateInput.style.backgroundColor = "white";
        document.getElementById("filterButton").removeAttribute("disabled", "disabled");
    }
}
function validateDate() {
    var dateInput = document.getElementById("date");
    var date = dateInput.value;
    var dateRegex = /^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$/;

    dateInput.style.color = "white";

    if (dateRegex.test(date)) {
        dateInput.style.backgroundColor = "rgba(0, 193, 41, 0.5)";
        document.getElementById("editRows").removeAttribute("disabled", "disabled");
    }
    else {
        dateInput.style.backgroundColor = "rgba(255, 0, 17, 0.6)";
        document.getElementById("editRows").setAttribute("disabled", "disabled");
    }
    if (date === "") {
        dateInput.style.backgroundColor = "white";
        document.getElementById("editRows").removeAttribute("disabled", "disabled");
    }
}

// #endregion

// Price Update Sell AND Cost
// #region Price Update Fields
function PriceUpdateSell() {
    var dateInput = document.getElementById("LinkUpdSellText").textContent = document.getElementById("sell").value;
}
function PriceUpdateCost() {
    var dateInput = document.getElementById("LinkUpdCostText").textContent = document.getElementById("cost").value;

}
// #endregion

// #region multyple EDIT modal - Clear Fields
function clearDate() {
    $('input[name=radioDate]:checked').prop("checked", false);
    document.getElementById("date").value = "";
    document.getElementById("date").style.backgroundColor = "white";
    document.getElementById("errDate").innerHTML = "";
    $('input[name=checkboxDate]:checked').prop("checked", false);
}
function clearPgPrice() {
    $('input[name=radioPgPrice]:checked').prop("checked", false);
    document.getElementById("pgPrice").value = "";
    document.getElementById("pgPrice").style.backgroundColor = "white";
    document.getElementById("errPgPrice").innerHTML = "";
    $('input[name=checkboxPgPrice]:checked').prop("checked", false);
}
function clearFixedPrice() {
    $('input[name=radioFixedPrice]:checked').prop("checked", false);
    document.getElementById("fixedPrice").value = "";
    document.getElementById("fixedPrice").style.backgroundColor = "white";
    document.getElementById("errFPrice").innerHTML = "";
    $('input[name=checkboxFixedPrice]:checked').prop("checked", false);
}
// #endregion
// #region multyple_Delete_modal
function selRowId() {
    var selRowIds = $('#jqgrid').jqGrid('getGridParam', 'selarrrow');

    var postData = { values: selRowIds };

    $.ajax({
        //contentType: "application/json; charset=utf-8",
        type: "get",
        url: '/ERP/Delete',
        data: postData,
        success: function (response) {
            var datas = response.data.replace(new RegExp('"', 'g'), '').replace('{', '').replace('}', '').split(",");
            var arr = [];
            for (var i = 0; i < datas.length; i++) {
                arr[i] = datas[i].split(":");
            }
            // Dialog Content
            var parent_div = document.createElement("div");
            parent_div.setAttribute("class", "row");
            parent_div.setAttribute("style", "border-style: double;border-color:red");

            var div_customer = document.createElement("div");
            var div_product = document.createElement("div");

            div_customer.setAttribute("class", "col-sm-6");
            div_product.setAttribute("class", "col-sm-6");
            document.getElementById("dlgContent").appendChild(div_customer);
            document.getElementById("dlgContent").appendChild(div_product);
            var label_product = document.createElement("label");
            var label_customer = document.createElement("label");
            label_product.setAttribute("class", "fa fa-product");
            label_customer.setAttribute("class", "fa fa-customer");
            label_product.setAttribute("style", "color:#46b2ff");
            label_customer.setAttribute("style", "color:#46b2ff");
            label_product.innerHTML = "&#xf01c;  Product";
            label_customer.innerHTML = "&#xf2c0; Customer";

            div_product.appendChild(label_product);
            div_customer.appendChild(label_customer);

            for (var j = 0; j < arr.length; j++) {
                var paragrafp_product = document.createElement("p");
                var paragrafp_customer = document.createElement("p");
                paragrafp_product.appendChild(document.createTextNode(arr[j][0]));
                paragrafp_customer.appendChild(document.createTextNode(arr[j][1]));
                div_product.appendChild(paragrafp_product);
                div_customer.appendChild(paragrafp_customer);
            }
            parent_div.appendChild(div_product);
            parent_div.appendChild(div_customer);
            document.getElementById("dlgContent").appendChild(parent_div);

            // open alertify modal
            var dlgContentHTML = $('#dlgContent').html();
            $('#dlgContent').html("");
            alertify.confirm(dlgContentHTML).set('onok', function (closeevent, value) {
                //if (closeevent.button.text === "YES") {

                //}
            }).set({ title: "Are you sure you want to delete this item(s)?" }).set({ labels: { ok: 'YES', cancel: 'NO' } });
            // write id in Yes button for call post method
            document.getElementsByClassName("ajs-ok")[0].setAttribute("id", "deleteRows");
            // Create Trash Icon
            var header = document.getElementsByClassName("ajs-header");
            if (!document.getElementsByClassName("ajs-header")[0].contains(document.getElementById("trash"))) {
                var trash = document.createElement("span");
                trash.setAttribute("class", "fa fa-trash fa-2x");
                trash.setAttribute("id", "trash");
                trash.setAttribute("style", "color:red;float: left;padding-right: 10px;margin-top: -5px");
                header[0].appendChild(trash);
            }
        },
        error: function (response) {
            if (!alertify.myAlert) {
                //define a new dialog
                alertify.dialog('myAlert', function () {
                    return {
                        main: function (message) {
                            this.message = message;
                        },
                        setup: function () {
                            return {
                                buttons: [{ text: "cancel!", key: 27/*Esc*/ }],
                                focus: { element: 0 }
                            };
                        },
                        prepare: function () {
                            this.setContent(this.message);
                        }
                    };
                });
            }
            //launch it.
            alertify.myAlert(response.responseText);
            $('#jqgrid').trigger('reloadGrid');
        },
        dataType: "json",
        traditional: true
    });

}

$(document).on("click", '#deleteRows', function (event) {
    $.ajax({
        //contentType: "application/json; charset=utf-8",
        type: "post",
        url: '/ERP/Delete',
        data: null,
        success: function (response) {
            if (response.success) {
                alertify.success(response.responseText);
                $('#jqgrid').trigger("reloadGrid");
            }
            else {
                if (!alertify.myAlert) {
                    //define a new dialog
                    alertify.dialog('myAlert', function () {
                        return {
                            main: function (message) {
                                this.message = message;
                            },
                            setup: function () {
                                return {
                                    buttons: [{ text: "cancel!", key: 27/*Esc*/ }],
                                    focus: { element: 0 }
                                };
                            },
                            prepare: function () {
                                this.setContent(this.message);
                            }
                        };
                    });
                }
                //launch it.
                alertify.myAlert(response.responseText);
            }
        },
        error: function (response) {
            if (!alertify.myAlert) {
                //define a new dialog
                alertify.dialog('myAlert', function () {
                    return {
                        main: function (message) {
                            this.message = message;
                        },
                        setup: function () {
                            return {
                                buttons: [{ text: "cancel!", key: 27/*Esc*/ }],
                                focus: { element: 0 }
                            };
                        },
                        prepare: function () {
                            this.setContent(this.message);
                        }
                    };
                });
            }
            //launch it.
            alertify.myAlert(response.responseText);
            $('#jqgrid').trigger('reloadGrid');
        },
        dataType: "json",
        traditional: true
    });

});
// #endregion
// modal close
$('#myModal').on('hidden.bs.modal', function (e) {
    $('#jqgrid').trigger("reloadGrid");
    $('#modal').modal('toggle');
});
$(document).ready(function () {
    window.onload = function () {

        //#region Create "Search AutoC. Input" in Jqgrid footer
        var GridFooter_left = document.getElementById("pjqgrid_left");
        var div_one = document.createElement("div");
        div_one.setAttribute('class', 'col-sm-4');

        var input = document.createElement("input");
        input.setAttribute('type', 'search');
        input.setAttribute('title', 'Search Part Name');
        input.setAttribute('name', 'searchPart');
        input.setAttribute('id', 'searchPart');
        input.setAttribute('class', 'filterItem ui-autocomplete-input');
        input.setAttribute('placeholder', 'Name');
        input.setAttribute('autocomplete', 'Off');

        input.setAttribute('id', 'searchPart');
        div_one.appendChild(input);
        GridFooter_left.appendChild(div_one);
        // #endregion
        //#region Create Multiple Edit hyperlink in Jqgrid footer
        var div_two = document.createElement("div");
        div_two.setAttribute('class', 'col-sm-1');
        var update_link = document.createElement('a');
        update_link.setAttribute('data-modal', '');
        update_link.setAttribute('class', 'edit_hyperlink');
        update_link.setAttribute('role', 'menuitem');
        update_link.setAttribute('tabindex', '-1');
        update_link.setAttribute('href', 'ERP/Edit');
        div_two.appendChild(update_link);
        GridFooter_left.appendChild(div_two);
        // #endregion

        //#region Create Delete hyperlink in Jqgrid footer
        var div_three = document.createElement("div");
        div_three.setAttribute('class', 'col-sm-4');
        var delete_link = document.createElement('a');
        //delete_link.setAttribute('data-modal', '');
        delete_link.setAttribute('class', 'delete_hyperlink');
        delete_link.setAttribute('role', 'menuitem');
        delete_link.setAttribute('name', 'DelName');
        delete_link.setAttribute('href', 'javascript:void(0)');
        delete_link.setAttribute('onclick', 'selRowId()');
        delete_link.setAttribute('tabindex', '-1');
        //delete_link.setAttribute('href', 'ERP/Delete');
        div_three.appendChild(delete_link);
        GridFooter_left.appendChild(div_three);
        // #endregion
        // #region Autocomplete Search
        // ID and Name
        //$('#searchPart').autocomplete({ source: '/ERP/AutocompleteSearch' })
        //    .data("ui-autocomplete")._renderItem = function (ul, item) {
        //        return $("<li></li>")
        //            .data("item.autocomplete", item)
        //            .append("<a><span style='display: inline-block;width:90px;'><b>" + item.value + "</b></span>" + item.title + "</a>")
        //            .appendTo(ul);
        //    };

        $('#searchPart').autocomplete({ source: '/ERP/AutocompleteSearch' })
            .data("ui-autocomplete")._renderItem = function (ul, item) {
                return $("<li></li>")
                    .data("item.autocomplete", item)
                    .append("<a><span style='display: inline-block;width:90px;'><b>" + item.title + "</b></span></a>")
                    .appendTo(ul);
            };
        $('#searchPart').on('autocompleteselect', function (e, ui) {
            var title = ui.item.title;

            var postDatas = $("#jqgrid").jqGrid('getGridParam', 'postData');
            postDatas["name"] = title;
            $('#jqgrid').jqGrid().setGridParam({ postData: postDatas, page: 1 }).trigger('reloadGrid');
        });

        // #endregion

        // #region filter Search Fields

        $('#filterButton').click(function (event) {
            event.preventDefault();
            filterGrid();
        });
        function filterGrid() {
            var postDataValues = $("#jqgrid").jqGrid('getGridParam', 'postData');
            // grab all the filter ids and values and add to the post object
            $('.filterItem').each(function (index, item) {
                postDataValues[$(item).attr('id')] = $(item).val();
            });
            postDataValues["name"] = "";
            $('#jqgrid').jqGrid().setGridParam({ postData: postDataValues, page: 1 }).trigger('reloadGrid');
        }
        // #endregion
        // #region Modal
        $("a[data-modal]").on("click", function (e) {
            $('#myModalContent').load(this.href, function () {
                $('#myModal').modal({
                    keyboard: true
                }, 'show');

                bindForm(this);
            });
            return false;
        });

        function bindForm(dialog) {
            $('form', dialog).submit(function () {
                if (ViewBag.det === "true") {
                    $('#progress').show();
                }
                $.ajax({
                    url: this.action,
                    type: this.method,
                    data: $(this).serialize(),
                    success: function (result) {
                        if (result.success) {
                            $('#myModal').modal('hide');
                            $('#progress').hide();
                            location.reload();
                        } else {
                            $('#progress').hide();
                            $('#myModalContent').html(result);
                            bindForm();
                        }
                    }
                });
                return false;
            });
        }

        // #endregion        
    };


    // START AND FINISH DATE
    // #region Datepicker
    $("#startdate").datepicker({
        dateFormat: 'dd.mm.yy',
        prevText: '<i class="fa fa-chevron-left"></i>',
        nextText: '<i class="fa fa-chevron-right"></i>',
        onSelect: function (selectedDate) {
            $("#finishdate").datepicker('option', 'minDate', selectedDate);
            var dateRegex = /^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$/;

            var dateInput = document.getElementById("startdate");
            var date = dateInput.value;

            dateInput.style.color = "rgb(70, 178, 255)";

            if (dateRegex.test(date)) {
                dateInput.style.backgroundColor = "white";
                document.getElementById("SubPart").disabled = false;
            }
            else {
                dateInput.style.backgroundColor = "rgb(217, 83, 79)";
                document.getElementById("SubPart").disabled = true;
            }
        }
    });

    $("#startdate1").datepicker({
        dateFormat: 'dd.mm.yy',
        prevText: '<i class="fa fa-chevron-left"></i>',
        nextText: '<i class="fa fa-chevron-right"></i>',
        onSelect: function (selectedDate) {
            $("#finishdate1").datepicker('option', 'minDate', selectedDate);
            var dateRegex = /^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$/;

            var dateInput = document.getElementById("startdate1");
            var date = dateInput.value;

            dateInput.style.color = "rgb(70, 178, 255)";

            if (dateRegex.test(date)) {
                dateInput.style.backgroundColor = "white";
                document.getElementById("filterButton").removeAttribute("disabled", "disabled");
            }
            else {
                dateInput.style.backgroundColor = "rgb(217, 83, 79)";
                document.getElementById("filterButton").setAttribute("disabled", "disabled");
            }
        }
    });

    $("#finishdate").datepicker({
        dateFormat: 'dd.mm.yy',
        prevText: '<i class="fa fa-chevron-left"></i>',
        nextText: '<i class="fa fa-chevron-right"></i>',
        onSelect: function (selectedDate) {
            $("#startdate").datepicker('option', 'maxDate', selectedDate);
            var dateRegex = /^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$/;

            var dateInput = document.getElementById("finishdate");

            var date = dateInput.value;

            dateInput.style.color = "white";

            if (dateRegex.test(date)) {
                dateInput.style.backgroundColor = "rgba(0, 193, 41, 0.5)";
                document.getElementById("SubPart").disabled = false;
            }
            else {
                dateInput.style.backgroundColor = "rgb(217, 83, 79)";
                document.getElementById("SubPart").disabled = true;
            }
        }
    });

    $("#finishdate1").datepicker({
        dateFormat: 'dd.mm.yy',
        prevText: '<i class="fa fa-chevron-left"></i>',
        nextText: '<i class="fa fa-chevron-right"></i>',
        onSelect: function (selectedDate) {
            $("#startdate1").datepicker('option', 'maxDate', selectedDate);
            var dateRegex = /^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$/;

            var dateInput = document.getElementById("finishdate1");
            var date = dateInput.value;

            dateInput.style.color = "rgb(70, 178, 255)";

            if (dateRegex.test(date)) {
                dateInput.style.backgroundColor = "white";
                document.getElementById("filterButton").removeAttribute("disabled", "disabled");
            }
            else {
                dateInput.style.backgroundColor = "rgba(255, 0, 17, 0.7)";
                document.getElementById("filterButton").setAttribute("disabled", "disabled");
            }

        }
    });

    $("#startdate, #startdate1").removeAttr("data-val-date");
    $("#finishdate, #finishdate1").removeAttr("data-val-date");


    // #endregion

    // Custom Edit JQDrid
    // #region multyple EDIT modal

    $(document).on("click", '#editRows', function (event) {
        var flagRequired = true;
        if (event.target.name === "date") {
            if ($('input[name=radioDate]:checked').val() === null) {
                document.getElementById("errDate").innerHTML = "Please select at least one option to proceed";
                flagRequired = false;
            }
            if (document.getElementById("date").value === "") {
                document.getElementById("date").style.backgroundColor = "rgba(255, 0, 17, 0.6)";
                flagRequired = false;
            }
        }
        else if (event.target.name === "percentagePrice") {
            if ($('input[name=radioPgPrice]:checked').val() === null) {
                document.getElementById("errPgPrice").innerHTML = "Please select at least one option to proceed";
                flagRequired = false;
            }
            if (document.getElementById("pgPrice").value === "") {
                document.getElementById("pgPrice").style.backgroundColor = "rgba(247, 16, 33, 0.11)";
                flagRequired = false;
            }
            else {
                document.getElementById("pgPrice").style.backgroundColor = "white";
            }
        }
        else if (event.target.name === "FixedPrice") {
            if ($('input[name=radioFixedPrice]:checked').val() === null) {
                document.getElementById("errFPrice").innerHTML = "Please select at least one option to proceed";
                flagRequired = false;
            }
            if (document.getElementById("fixedPrice").value === "") {
                document.getElementById("fixedPrice").style.backgroundColor = "rgba(247, 16, 33, 0.11)";
                flagRequired = false;
            }
            else {
                document.getElementById("fixedPrice").style.backgroundColor = "white";
            }
        }
        if (flagRequired) {
            document.getElementById("errDate").innerHTML = "";
            document.getElementById("errPgPrice").innerHTML = "";
            document.getElementById("errFPrice").innerHTML = "";

            var selRowIds = $('#jqgrid').jqGrid('getGridParam', 'selarrrow');

            var list = [
                $('input[name=radioDate]:checked').val(),
                document.getElementById("date").value,
                $('input[name=checkboxDate]:checked').val(),

                $('input[name=radioPgPrice]:checked').val(),
                document.getElementById("pgPrice").value,
                $('input[name=checkboxPgPrice]:checked').val(),

                $('input[name=radioFixedPrice]:checked').val(),
                document.getElementById("fixedPrice").value,
                $('input[name=checkboxFixedPrice]:checked').val()

            ];

            var postData = { editList: list, values: selRowIds, name: event.target.name };

            $.ajax({
                //contentType: "application/json; charset=utf-8",
                type: "post",
                url: '/ERP/Edit',
                data: postData,
                success: function (response) {
                    if (response.success) {
                        alertify.success(response.responseText);
                        //var ids = $('#jqgrid').jqGrid('getGridParam', 'selarrrow');
                        // $('#jqgrid').trigger("reloadGrid");
                        //for (var i = 0; i < ids.length; i++) {
                        //    var Row = $("#jqgrid #".concat(ids[i]));
                        //    Row.addClass("ui-state-disabled ui-jqgrid-disablePointerEvents");
                        //    Row.removeClass("ui-state-highlight");
                        //    var Input = $("tr.jqgrow > td > input").prop("checked", false);
                        //}
                    }
                    else {
                        if (!alertify.myAlert) {
                            //define a new dialog
                            alertify.dialog('myAlert', function () {
                                return {
                                    main: function (message) {
                                        this.message = message;
                                    },
                                    setup: function () {
                                        return {
                                            buttons: [{ text: "cancel!", key: 27/*Esc*/ }],
                                            focus: { element: 0 }
                                        };
                                    },
                                    prepare: function () {
                                        this.setContent(this.message);
                                    }
                                };
                            });
                        }
                        //launch it.
                        alertify.myAlert(response.responseText);
                    }
                },
                error: function (response) {
                    if (!alertify.myAlert) {
                        //define a new dialog
                        alertify.dialog('myAlert', function () {
                            return {
                                main: function (message) {
                                    this.message = message;
                                },
                                setup: function () {
                                    return {
                                        buttons: [{ text: "cancel!", key: 27/*Esc*/ }],
                                        focus: { element: 0 }
                                    };
                                },
                                prepare: function () {
                                    this.setContent(this.message);
                                }
                            };
                        });
                    }
                    //launch it.
                    alertify.myAlert(response.responseText);
                    $('#jqgrid').trigger('reloadGrid');
                },
                dataType: "json",
                traditional: true
            });
        }
    });
    // #endregion

    // #region JQGrid view - data
    pageSetUp();
    jQuery("#jqgrid").jqGrid({
        url: '/ERP/GetJqGridValuesAsync',
        datatype: 'json',
        mtype: 'Get',
        height: 'auto',
        colNames: ['PartID', 'Name', 'Category', 'Description', 'Date Created', 'Start Date', 'End Date', 'Selling price', 'Cost price', 'Currency', 'Customer'],
        colModel: [
            // 'PartID', hidden: true!!! 
            {
                name: 'PartID', index: 'PartID', width: 100, editable: true,
                editrules: { required: true, edithidden: true },
                hidden: true,
                key: true,
                editoptions: { dataInit: function (element) { jq(element).attr("readonly", "readonly"); } }
            },
            { name: 'PartPrimary', index: 'orderby_partname', firstsortorder: 'desc' },
            { name: 'CategoryName', index: 'OrderBy_CategoryName', editable: true },
            { name: 'Description', index: 'OrderBy_Description', editable: true },
            { name: 'CreatedDate', index: 'OrderBy_DCreated', sorttype: "date", formatoptions: { newformat: 'm-d-Y' }, datefmt: 'm-d-Y', formatter: 'date', align: "left", editable: true },
            { name: 'ValidStart', index: 'OrderBy_Start', sorttype: "date", formatoptions: { newformat: 'm-d-Y' }, datefmt: 'm-d-Y', formatter: 'date', editable: true },
            { name: 'ValidEnd', index: 'OrderBy_End', sorttype: "date", align: "right", formatoptions: { newformat: 'm-d-Y' }, datefmt: 'm-d-Y', formatter: 'date', editable: true },
            { name: 'SellValue', index: 'OrderBy_Sell', formatter: 'currency', align: "right", editable: true, defaultvalue: null },
            { name: 'CostValue', index: 'OrderBy_Cost', formatter: 'currency', align: "right", editable: true },
            { name: 'CurrencyName', index: 'OrderBy_CurrencyName', align: "right", editable: true },
            { name: 'First', index: 'OrderBy_CustomerName', align: "center", editable: true }],
        onSelectRow: function (id, status) {
            //if (!status)
            //    document.getElementById("DelName").classList.remove('disabled');
        },
        onSelectAll: function (id, status) {
            //if (status)
            //    document.getElementById("DelName").classList.add('disabled');
            //else
            //    document.getElementById("DelName").classList.remove('disabled');
        },
        rowNum: 10,
        rowList: [10, 30, 50],
        pager: '#pjqgrid',
        sortname: 'id',
        toolbarfilter: true,
        viewrecords: true,
        sortorder: "asc",
        jsonReader: {
            root: "rows",
            page: "page",
            total: "total",
            records: "records",
            repeatitems: false,
            Id: "0"
        },
        caption: "Price Management",
        multiselect: true,
        autowidth: true
    }).navGrid("#pjqgrid", { edit: false, del: false, add: false, search: false, refresh: false });
    // #endregion

    // #region JQGrid set up
    //jQuery("#jqgrid").jqGrid('inlineNav', "#pjqgrid");

    /* Add tooltips */
    $('.navtable .ui-pg-button').tooltip({
        container: 'body'
    });

    jQuery("#m1s").click(function () {
        jQuery("#jqgrid").jqGrid('setSelection', "13");
    });
    // #endregion

    // #region remove and add classes

    // remove classes
    $(".ui-jqgrid").removeClass("ui-widget ui-widget-content");
    $(".ui-jqgrid-view").children().removeClass("ui-widget-header ui-state-default");
    $(".ui-jqgrid-labels, .ui-search-toolbar").children().removeClass("ui-state-default ui-th-column ui-th-ltr");
    $(".ui-jqgrid-pager").removeClass("ui-state-default");
    $(".ui-jqgrid").removeClass("ui-widget-content");

    //$("#jqgrid").closest("div.ui-jqgrid-view").children("div.ui-jqgrid-titlebar").children("span.ui-jqgrid-title").css("text-color", "black");
    $("#jqgrid").closest("div.ui-jqgrid-view").children("div.ui-jqgrid-titlebar").css("text-align", "center").children("span.ui-jqgrid-title").css("float", "none");
    // add classes
    $(".ui-jqgrid-htable").addClass("table table-bordered table-hover");
    $(".ui-jqgrid-btable").addClass("table table-bordered table-striped");

    $(".ui-pg-div").removeClass().addClass("btn btn-sm btn-primary");
    $(".ui-icon.ui-icon-plus").removeClass().addClass("fa fa-plus");
    $(".ui-icon.ui-icon-pencil").removeClass().addClass("fa fa-pencil");
    $(".ui-icon.ui-icon-trash").removeClass().addClass("fa fa-trash-o");
    $(".ui-icon.ui-icon-search").removeClass().addClass("fa fa-search");
    $(".ui-icon.ui-icon-refresh").removeClass().addClass("fa fa-refresh");
    $(".ui-icon.ui-icon-disk").removeClass().addClass("fa fa-save").parent(".btn-primary").removeClass("btn-primary").addClass("btn-success");
    $(".ui-icon.ui-icon-cancel").removeClass().addClass("fa fa-times").parent(".btn-primary").removeClass("btn-primary").addClass("btn-danger");

    $(".ui-icon.ui-icon-seek-prev").wrap("<div class='btn btn-sm btn-default'></div>");
    $(".ui-icon.ui-icon-seek-prev").removeClass().addClass("fa fa-backward");

    $(".ui-icon.ui-icon-seek-first").wrap("<div class='btn btn-sm btn-default'></div>");
    $(".ui-icon.ui-icon-seek-first").removeClass().addClass("fa fa-fast-backward");

    $(".ui-icon.ui-icon-seek-next").wrap("<div class='btn btn-sm btn-default'></div>");
    $(".ui-icon.ui-icon-seek-next").removeClass().addClass("fa fa-forward");

    $(".ui-icon.ui-icon-seek-end").wrap("<div class='btn btn-sm btn-default'></div>");
    $(".ui-icon.ui-icon-seek-end").removeClass().addClass("fa fa-fast-forward");

    $(window).on('resize.jqGrid', function () {
        $("#jqgrid").jqGrid('setGridWidth', $("#content").width());
    });
    // #endregion
});