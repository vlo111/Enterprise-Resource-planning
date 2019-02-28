
// Module Revealing Pattern For Order Related Scripts
var OrderJs = function () {

    var nameOfTag = "";

    $('#create_tag_btn').on('click', function () {
        var tagName = $('#tag_name').val();
        var custOrderId = $('#custOrderId').val();
        if (tagName !== null && tagName !== "") {
            createNewTag(tagName, custOrderId);
            $('#tag_name').val("");
        } else {
            toastr.error("Please enter tag name first");
        }
    });

    function saveTagInOrder(tagName, custOrderId) {
        var tagId = 0;
        $.ajax({
            dataType: "json",
            url: "/Order/AddNewTagInOrder",
            async: false,
            type: "POST",
            data: { "custOrderId": custOrderId, "tagName": tagName, "shipmentId": 0 },
            success: function (data) {
                if (data.status) {
                    toastr.success("Tag saved in Order");
                    tagId = data.tagId;
                } else {
                    toastr.error("An error occurred. Try again");
                }
            },
            failure: function (data) {

            }
        });
        return tagId;
    }

    function createNewTag(tagName, custOrderId) {
        var tagId = saveTagInOrder(tagName, custOrderId);
        if (tagId > 0) { // this means tag was successfully saved in the tag table
            createTag(tagName, tagId);
        }
    }

    function createTag(tagName, tagId) {
        var parentDiv = $('.tagPanelDetail');
        var emptyTagFormDiv = $('.emptyFormTag');
        var containerDiv = document.createElement("div");
        $(containerDiv).attr('data-tagid', tagId);
        $(containerDiv).addClass("panel panel-default tagPanel newAddedTagDiv active");
        //$(containerDiv).addClass("panel panel-default tagPanel newAddedTagDiv");

        var formHorizontalDiv = document.createElement("div");
        $(formHorizontalDiv).addClass("form-horizontal");

        createNameFormGroup(tagName, containerDiv, formHorizontalDiv);
        createProfilePriorityFormGroup(containerDiv, formHorizontalDiv);
        createColorFormGroup(containerDiv, formHorizontalDiv);
        createPartsTable(containerDiv, null);
        $(parentDiv).prepend(containerDiv); // putting form-horizontal in panel-default div
        checkIfAnyOtherActiveTagIsPresent();
        showSelectButtonOnDefaultTag();
    }

    function createNameFormGroup(tagName, containerDiv, formHorizontalDiv) {
        var divFormGroup = document.createElement("div");
        $(divFormGroup).addClass("form-group");

        var nameLabel = document.createElement("label");
        $(nameLabel).addClass("col-sm-6 col-md-2 col-lg-2 tagLabel");
        nameLabel.innerHTML = "Name";

        var nameInputDiv = document.createElement("div");
        $(nameInputDiv).addClass("col-sm-6 col-md-4 col-lg-4");

        var nameInputField = document.createElement("input");
        nameInputField.type = "text";
        $(nameInputField).addClass("form-control input-xs");
        nameInputField.id = "tagName";
        nameInputField.placeHolder = "99418-2";
        nameInputField.value = tagName;

        $(nameInputDiv).append(nameInputField); // putting input field in its div

        var groupLabel = document.createElement("label");
        $(groupLabel).addClass("col-sm-6 col-md-2 col-lg-2 tagLabel");
        groupLabel.innerHTML = "Group";

        var groupDropDownDiv = document.createElement("div");
        $(groupDropDownDiv).addClass("col-sm-6 col-md-4 col-lg-4");

        var selectLabel = document.createElement("label");
        $(selectLabel).addClass("select");

        var selectGroup = document.createElement("select");
        selectGroup.id = "TagGroup";
        $(selectGroup).addClass("input-xs tagDropDown");

        var option1 = document.createElement('option');
        option1.value = 0;
        option1.text = 'Select';
        var option2 = document.createElement('option');
        option2.value = 1;
        option2.text = 'Alexandra';
        var option3 = document.createElement('option');
        option3.value = 2;
        option3.text = 'Alice';
        var option4 = document.createElement('option');
        option4.value = 3;
        option4.text = 'Anastasia';
        var option5 = document.createElement('option');
        option5.value = 4;
        option5.text = 'Avelina';
        selectGroup.appendChild(option1); // adding options to Group dropdown
        selectGroup.appendChild(option2);
        selectGroup.appendChild(option3);
        selectGroup.appendChild(option4);
        selectGroup.appendChild(option5);

        selectLabel.appendChild(selectGroup); // putting dropdown in its label

        groupDropDownDiv.appendChild(selectLabel); // putting label in the div

        divFormGroup.appendChild(nameLabel); // putting name label in the form-group
        divFormGroup.appendChild(nameInputDiv); // putting name input field in the form-group
        divFormGroup.appendChild(groupLabel); // putting group label in the form-group
        divFormGroup.appendChild(groupDropDownDiv); // putting group dropdown in the form-group
        formHorizontalDiv.appendChild(divFormGroup); // putting form-group in form-horizontal
        containerDiv.appendChild(formHorizontalDiv); // putting form-group in form-horizontal
    }

    function createProfilePriorityFormGroup(containerDiv, formHorizontalDiv) {
        var divFormGroup = document.createElement("div");
        $(divFormGroup).addClass("form-group");

        var profileLabel = document.createElement("label");
        $(profileLabel).addClass("col-sm-6 col-md-2 col-lg-2 tagLabel");
        profileLabel.innerHTML = "Profile";

        var profileDropDownDiv = document.createElement("div");
        $(profileDropDownDiv).addClass("col-sm-6 col-md-4 col-lg-4");

        var selectLabel = document.createElement("label");
        $(selectLabel).addClass("select");

        var selectProfile = document.createElement("select");
        selectProfile.id = "TagProfile";
        $(selectProfile).addClass("input-xs tagDropDown");

        var profileOption1 = document.createElement('option');
        profileOption1.value = 0;
        profileOption1.text = 'Select';
        var profileOption2 = document.createElement('option');
        profileOption2.value = 1;
        profileOption2.text = 'Century';
        var profileOption3 = document.createElement('option');
        profileOption3.value = 2;
        profileOption3.text = 'Alice';
        var profileOption4 = document.createElement('option');
        profileOption4.value = 3;
        profileOption4.text = 'Anastasia';
        var profileOption5 = document.createElement('option');
        profileOption5.value = 4;
        profileOption5.text = 'Avelina';
        selectProfile.appendChild(profileOption1); // adding options to Group dropdown
        selectProfile.appendChild(profileOption2);
        selectProfile.appendChild(profileOption3);
        selectProfile.appendChild(profileOption4);
        selectProfile.appendChild(profileOption5);

        selectLabel.appendChild(selectProfile); // putting dropdown in its label

        profileDropDownDiv.appendChild(selectLabel); // putting label in the div

        selectLabel = null; // so that is can be used again for priority
        /////////// profile label and its dropdown has been appended here /////////////////


        var priorityLabel = document.createElement("label");
        $(priorityLabel).addClass("col-sm-6 col-md-2 col-lg-2 tagLabel");
        priorityLabel.innerHTML = "Priority";

        var priorityDropDownDiv = document.createElement("div");
        $(priorityDropDownDiv).addClass("col-sm-6 col-md-4 col-lg-4");

        selectLabel = document.createElement("label");
        $(selectLabel).addClass("select");

        var selectPriority = document.createElement("select");
        selectPriority.id = "TagProfile";
        $(selectPriority).addClass("input-xs tagDropDown");

        var priorityOption1 = document.createElement('option');
        priorityOption1.value = 0;
        priorityOption1.text = 'Select';
        var priorityOption2 = document.createElement('option');
        priorityOption2.value = 1;
        priorityOption2.text = 'Normal';
        var priorityOption3 = document.createElement('option');
        priorityOption3.value = 2;
        priorityOption3.text = 'Alice';
        var priorityOption4 = document.createElement('option');
        priorityOption4.value = 3;
        priorityOption4.text = 'Anastasia';
        var priorityOption5 = document.createElement('option');
        priorityOption5.value = 4;
        priorityOption5.text = 'Avelina';
        selectPriority.appendChild(priorityOption1); // adding options to Group dropdown
        selectPriority.appendChild(priorityOption2);
        selectPriority.appendChild(priorityOption3);
        selectPriority.appendChild(priorityOption4);
        selectPriority.appendChild(priorityOption5);

        selectLabel.appendChild(selectPriority); // putting dropdown in its label

        priorityDropDownDiv.appendChild(selectLabel); // putting label in the div
        /////////// priority label and its dropdown has been appended here /////////////////

        divFormGroup.appendChild(profileLabel); // putting profile label in the form-group
        divFormGroup.appendChild(profileDropDownDiv); // putting profile dropdown
        divFormGroup.appendChild(priorityLabel); // putting priority label in the form-group
        divFormGroup.appendChild(priorityDropDownDiv); // putting priority dropdown in the form-group
        formHorizontalDiv.appendChild(divFormGroup); // putting form-group in form-horizontal
        containerDiv.appendChild(formHorizontalDiv); // putting form-group in form-horizontal
    }

    function createColorFormGroup(containerDiv, formHorizontalDiv) {
        var divFormGroup = document.createElement("div");
        $(divFormGroup).addClass("form-group");

        var colorLabel = document.createElement("label");
        $(colorLabel).addClass("col-sm-6 col-md-2 col-lg-2 tagLabel");
        colorLabel.innerHTML = "Color";

        var colorDropDownDiv = document.createElement("div");
        $(colorDropDownDiv).addClass("col-sm-6 col-md-4 col-lg-4");

        var selectLabel = document.createElement("label");
        $(selectLabel).addClass("select");

        var selectColor = document.createElement("select");
        selectColor.id = "TagGroup";
        $(selectColor).addClass("input-xs tagDropDown");

        var option1 = document.createElement('option');
        option1.value = 0;
        option1.text = 'Select';
        var option2 = document.createElement('option');
        option2.value = 1;
        option2.text = 'Mil Finish';
        var option3 = document.createElement('option');
        option3.value = 2;
        option3.text = 'Alice';
        var option4 = document.createElement('option');
        option4.value = 3;
        option4.text = 'Anastasia';
        var option5 = document.createElement('option');
        option5.value = 4;
        option5.text = 'Avelina';
        selectColor.appendChild(option1); // adding options to Group dropdown
        selectColor.appendChild(option2);
        selectColor.appendChild(option3);
        selectColor.appendChild(option4);
        selectColor.appendChild(option5);

        selectLabel.appendChild(selectColor); // putting dropdown in its label

        colorDropDownDiv.appendChild(selectLabel); // putting label in the div
        /////////// color label and its dropdown has been appended here /////////////////
        var saveBtn = document.createElement("button");
        $(saveBtn).addClass("btn btn-xs btn-success");
        saveBtn.innerHTML = "Save";
        saveBtn.style.marginRight = '3px';


        var selectBtn = document.createElement("button");
        $(selectBtn).addClass("btn btn-xs btn-warning pin-it");
        selectBtn.innerHTML = "Select";
        $(selectBtn).css('display', 'none');

        divFormGroup.appendChild(colorLabel); // putting group label in the form-group
        divFormGroup.appendChild(colorDropDownDiv); // putting group dropdown in the form-group
        divFormGroup.appendChild(saveBtn); // putting Save button in the form-group
        divFormGroup.appendChild(selectBtn); // putting Select button in the form-group
        formHorizontalDiv.appendChild(divFormGroup); // putting form-group in form-horizontal
        containerDiv.appendChild(formHorizontalDiv); // putting form-group in form-horizontal
    }

    function createPartsTable(containerDiv, data) {
        var tableDiv = document.createElement("div");
        $(tableDiv).addClass('custom-scroll table-responsive');
        tableDiv.style.maxHeight = '150px';
        tableDiv.style.overflow = 'scroll';

        var table = document.createElement("table");
        $(table).addClass('table table-bordered');

        var tableHead = document.createElement('thead');
        var tableHeadRow = document.createElement('tr');

        var tableHeadRowCol1 = document.createElement('th');
        tableHeadRowCol1.innerHTML = '#';
        var tableHeadRowCol2 = document.createElement('th');
        tableHeadRowCol2.innerHTML = 'PartsId';
        var tableHeadRowCol3 = document.createElement('th');
        tableHeadRowCol3.innerHTML = 'Description';
        var tableHeadRowCol4 = document.createElement('th');
        tableHeadRowCol4.innerHTML = 'Act';

        tableHeadRow.appendChild(tableHeadRowCol1); // appending THs in TR in table head
        tableHeadRow.appendChild(tableHeadRowCol2);
        tableHeadRow.appendChild(tableHeadRowCol3);
        tableHeadRow.appendChild(tableHeadRowCol4);

        tableHead.appendChild(tableHeadRow); // appending TR in THEAD

        var tableBody = document.createElement('tbody'); // empty table body
        if (data !== null && data.length > 0) {
            var rowCount = $(tableBody).children().length;
            // this is the case when order is shown in edit mode and a tag has some order parts in it
            for (var i = 0; i < data.length; i++) {
                var partObj = data[i].Part;
                if (partObj !== null) {
                    var tableBodyRow = document.createElement('tr');
                    $(tableBodyRow).attr('data-partId', partObj.PartID);
                    var tableBodyRowCol1 = document.createElement('td');
                    tableBodyRowCol1.innerHTML = (i + 1);
                    var tableBodyRowCol2 = document.createElement('td');
                    tableBodyRowCol2.innerHTML = partObj.PartID;
                    var tableBodyRowCol3 = document.createElement('td');
                    tableBodyRowCol3.innerHTML = partObj.Name;
                    var tableBodyRowCol4 = document.createElement('td');
                    var anchorTag = document.createElement('a');
                    anchorTag.setAttribute("onclick", "removePartFrmTag(this)");
                    anchorTag.setAttribute("href", "javascript:void(0);");
                    var icon = document.createElement('i');
                    $(icon).addClass('fa fa-remove text-danger');
                    anchorTag.appendChild(icon);
                    tableBodyRowCol4.appendChild(anchorTag);

                    tableBodyRow.appendChild(tableBodyRowCol1); // appending TDs in TR in table body
                    tableBodyRow.appendChild(tableBodyRowCol2);
                    tableBodyRow.appendChild(tableBodyRowCol3);
                    tableBodyRow.appendChild(tableBodyRowCol4);

                    tableBody.appendChild(tableBodyRow); // appending TR in TBODY
                }
            }
        }

        table.appendChild(tableHead); // appedning THEAD in TABLE
        table.appendChild(tableBody); // appedning TBODY in TABLE
        tableDiv.appendChild(table); // appending TABLE in div
        containerDiv.appendChild(tableDiv); // putting table div in container i.e. panel panel-default tagPanel active
    }

    function saveCommentsAndQuantity(quantity, comment, orderPartId) {
        $.ajax({
            dataType: "json",
            type: "POST",
            async: false,
            url: "/Order/SaveQuantityAndCommentsByOrderPartId",
            data: { 'quantity': quantity, 'comment': comment, 'orderPartId': orderPartId },
            success: function (data) {
                if (data) {
                    toastr.success("Record updated successfully");
                } else {
                    toastr.error("Something went wrong. Try again.");
                }
            }
        });
    }

    $('#save_shipping_edit_changes').on('click', function () {
        var orderPartId = $('#shipping_edit_modal').data('orderpartid');
        var quantity = $('#quantity').val();
        var comment = $('#comment').val();

        saveCommentsAndQuantity(quantity, comment, orderPartId);
    });

    function showSelectButtonOnDefaultTag() {
        // this code will show pin it button on default tag
        var defaultTagDiv = $('.emptyFormTag');
        var formHorizontalDiv = $(defaultTagDiv).children()[0];
        var buttonFormGroupDiv = $(formHorizontalDiv).children()[2];
        var button = $(buttonFormGroupDiv).children()[3];
        $(button).css('display', 'inline');
    }

    $(document).on('click', '.pin-it', function () {
        var activeTagsLength = $('.tagPanelDetail').children('.active').length;
        if (activeTagsLength > 0) {
            // there will be only one active tag at a time, this code will make the already active tag inactive
            var activeTag = $('.tagPanelDetail').children('.active');
            $(activeTag).removeClass('active');

            //this code shows the select button in the div which is made inactive
            var formHorizontalDiv = $(activeTag).children()[0];
            var buttonFormGroupDiv = $(formHorizontalDiv).children()[2];
            var button = $(buttonFormGroupDiv).children()[3];
            $(button).css('display', 'inline');

            //this code will make div active whose select button was clicked
            var divToMakeActive = $(this).closest(".tagPanel");
            $(divToMakeActive).addClass('active');
            $(this).hide();
        }
    });

    function deletePartFromTag(custOrderId, partId, tagId) {
        var status = false;
        if (partId !== "" && tagId !== "") {
            $.ajax({
                dataType: "json",
                url: "/Order/DeletePartFromOrderTag",
                async: false,
                type: "POST",
                data: { "partId": parseInt(partId), "tagId": parseInt(tagId) },
                success: function (data) {
                    if (data) {
                        toastr.success("Part successfully deleted from Tag");
                        status = true;
                    } else {
                        toastr.error("An error occurred. Try again");
                        status = false;
                    }
                }
            });
            return status;
        }
    }

    $('#deleteTagPartBtn').on('click', function () {
        var custOrderId = "";
        var partId = "";
        var tagId = "";

        var rowToBeDeleted = $('.toBeDeleted'); // when remove button is clicked we add a class to the row toBeDeleted
        partId = $(rowToBeDeleted).data('partid');
        custOrderId = $(rowToBeDeleted).data('custorderid');
        var tagDiv = $(rowToBeDeleted).closest('.tagPanel');
        tagId = $(tagDiv).data('tagid');
        var check = deletePartFromTag(custOrderId, partId, tagId);
        if (check) {
            $(rowToBeDeleted).remove();
        }
    });

    function checkIfAnyOtherActiveTagIsPresent() {
        // this function is executed after another active tag is added i.e. 2 active tags
        var activeTagsLength = $('.tagPanelDetail').children('.active').length;
        if (activeTagsLength > 1) {
            var activeTags = $('.tagPanelDetail').children('.active');
            $(activeTags).each(function () {
                if ($(this).is(':first-child')) {
                    // here first child is the one that is newly added so we don't have to do anything with it
                } else {
                    // we will be in the else part when there is any other tag active that was previously added so we have to remove its active class
                    // and display its select button
                    $(this).removeClass('active');
                    var formHorizontalDiv = $(this).children()[0];
                    var buttonFormGroupDiv = $(formHorizontalDiv).children()[2];
                    var button = $(buttonFormGroupDiv).children()[3];
                    $(button).css('display', 'inline');
                }
            });
        }
    }

    function renderTagsInView(tags) {
        // this function is used to show all the tags of an order including default and others
        if (tags.length > 0) {
            for (var i = 0; i < tags.length; i++) {
                var tag = tags[i];
                var parentDiv = $('.tagPanelDetail');
                var emptyTagFormDiv = $('.emptyFormTag');
                var containerDiv = document.createElement("div");
                $(containerDiv).attr('data-tagid', tag.TagID);
                $(containerDiv).addClass("panel panel-default tagPanel newAddedTagDiv active");
                var formHorizontalDiv = document.createElement("div");
                $(formHorizontalDiv).addClass("form-horizontal");

                if (tag.TagName.toLowerCase().indexOf("default") >= 0) {
                    //this means this tag was a default one because we create default tag Default-OrderNo
                    createNameFormGroup(tag.TagName, containerDiv, formHorizontalDiv);
                    createProfilePriorityFormGroup(containerDiv, formHorizontalDiv);
                    createColorFormGroup(containerDiv, formHorizontalDiv);
                    createPartsTable(containerDiv, tag.OrderParts);
                    $(parentDiv).prepend(containerDiv); // putting form-horizontal in panel-default div
                    //checkIfAnyOtherActiveTagIsPresent();
                    //showSelectButtonOnDefaultTag();
                } else {
                    // here those tags will come that were added above default tag
                    console.log("not default");
                    createNameFormGroup(tag.TagName, containerDiv, formHorizontalDiv);
                    createProfilePriorityFormGroup(containerDiv, formHorizontalDiv);
                    createColorFormGroup(containerDiv, formHorizontalDiv);
                    createPartsTable(containerDiv, tag.OrderParts);
                    $(parentDiv).prepend(containerDiv); // putting form-horizontal in panel-default div
                    checkIfAnyOtherActiveTagIsPresent();
                    showSelectButtonOnDefaultTag();
                }
            }
        }
    }

    function getTagsForCurrentCustomerOrder() {
        var custOrderId = $('#custOrderId').val();
        $.ajax({
            dataType: "json",
            type: "GET",
            async: false,
            url: "/Order/GetAllTagsByOrderId",
            data: { 'custOrderId': custOrderId },
            success: function (data) {
                if (data !== null) {
                    OrderJs.renderTagsInView(data);
                }
            }
        });
    }

    function saveOrderPartInOrderPartTag(partId, tagId) {
        var custOrderId = $('#custOrderId').val();
        $.ajax({
            dataType: "json",
            type: "GET",
            async: false,
            url: "/Order/SaveOrderPartInOrderPartTag",
            data: { 'partId': partId, 'tagId': tagId, 'custOrderId': custOrderId},
            success: function (data) {
                if (data) {
                    toastr.success("Part successfully added into Tag");
                } else {
                    toastr.error("An error occured");
                }

            }
        });
    }

    function addPartToTag(partId) {
        var check;
        //we are getting count of the tags that are active
        var activeTagsCount = $('.tagPanelDetail').children('.active').length;
        // only 1 tag can be active
        if (activeTagsCount > 0) {
            var part = getPartById(partId);

            //check = checkIfPartAlreadyExistsInAnyTag();

            // we are getting the tag that is active in the tags section
            var activeTagSection = $('.tagPanelDetail').children('.active');
            var tagId = $(activeTagSection).data('tagid');
            //finding the active tag's table container that holds the table with class custom-scroll
            var tableContainer = $(activeTagSection).children('.custom-scroll');
            //getting the table in which we have to add the part
            var activeTagTable = $(tableContainer).children('.table');
            //getting table body of the table as our will have thead and tbody as its children
            var activeTagTableBody = $(activeTagTable).children()[1];
            //getting row count of the tbody
            var rowCount = $(activeTagTableBody).children().length;
            var item = part;
            if (item !== null) {
                check = checkIfPartAlreadyExistsInTag(activeTagTableBody, rowCount, item.PartID);
                //check = false;
                if (!check) {
                    var tr = document.createElement('tr');
                    $(tr).attr('data-partId', item.PartID);
                    var trCol1 = document.createElement('td');
                    var trCol2 = document.createElement('td');
                    var trCol3 = document.createElement('td');
                    var trCol4 = document.createElement('td');

                    trCol1.innerHTML = rowCount + 1;
                    trCol2.innerHTML = item.PartID;
                    trCol3.innerHTML = item.Name;
                    var anchorTag = document.createElement('a');
                    anchorTag.setAttribute("onclick", "removePartFrmTag(this)");
                    anchorTag.setAttribute("href", "javascript:void(0);");
                    var icon = document.createElement('i');
                    $(icon).addClass('fa fa-remove text-danger');
                    anchorTag.appendChild(icon);
                    trCol4.appendChild(anchorTag);

                    tr.appendChild(trCol1);
                    tr.appendChild(trCol2);
                    tr.appendChild(trCol3);
                    tr.appendChild(trCol4);
                    $(activeTagTableBody)[0].appendChild(tr);

                    saveOrderPartInOrderPartTag(part.PartID, tagId);
                } else {
                    toastr.error("This part already exists in " + nameOfTag + " Tag");
                }
            }
        } else {
            toastr.info("No tag is active. Create a new tag.");
        }
    }

    function getPartById(part_id) {
        var returnData;
        var id = parseInt(part_id);
        if (!isNaN(id) && id > 0) {
            $.ajax({
                dataType: "json",
                type: "GET",
                async: false,
                url: "/Order/GetPartAgainstId",
                data: { 'partId': id },
                success: function (data) {
                    if (data !== null) {
                        returnData = data;
                        //addPartToTag(return_data);
                    } else {
                        toastr.error("An error occured");
                    }

                }
            });
            return returnData;
        }
    }

    function checkIfPartAlreadyExistsInTag(activeTagTableBody, count, partId) {
        var ids = [];
        var array = [];
        var tagPartObj = function (partId, tagName) {
            this.Id = partId;
            this.Name = tagName;
        };

        // we are getting all the tags in the tags section
        var allTagsDiv = $('.tagPanelDetail').children();

        for (var j = 0; j < allTagsDiv.length; j++) {
            var tagDiv = allTagsDiv[j];
            var formHorizontalDiv = $(tagDiv).children()[0];
            var nameFormGroup = $(formHorizontalDiv).children()[0];
            var nameInputElementContainer = $(nameFormGroup).children(1);
            var nameInputElement = $(nameInputElementContainer).children('#tagName')[0];
            var tagName = nameInputElement.value;
            var tagTableDiv = $(tagDiv).children()[1];
            var tagTableElement = $(tagTableDiv).children()[0];
            var tagTableBody = $(tagTableElement).children()[1];
            $(tagTableBody).children().each(function () {
                var part_id = $(this).data('partid');
                ids.push(part_id);
                array.push((new tagPartObj(part_id, tagName)));
            });
        }

        for (var i = 0; i < array.length; i++) {
            var obj = array[i];
            if (obj.Id === partId) {
                nameOfTag = obj.Name;
                return true;
            }
        }

        return false;
    }

    function UpdateOrderState(State) {
        var flag = checkAllPartsAreAddedInTags();
        if (flag) {
            $.ajax({
                dataType: "json",
                url: "/Order/UpdateOrderState",
                async: false,
                type: "POST",
                data: { 'custOrderID': $('#custOrderId').val(), "State": State },
                success: function (data) {
                    if (State === 'Draft') {
                        window.location.href = "/Dashboard/Index";
                    } else if (State === 'Primary') {
                        window.location.href = "/Dashboard/Index";
                    } else if (State === 'Secondary') {

                        window.location.href = "/Order/CompareOrder/" + $('#custOrderId').val();
                    } else if (State === 'Review') {

                        window.location.href = "/Order/OrderReview/" + $('#custOrderId').val();
                    } else {
                        window.location.reload();
                    }
                },
                failure: function (data) {

                }
            });
        }
    }
    function checkAllPartsAreAddedInTags() {
        var returnData;
        $.ajax({
            dataType: "json",
            url: "/Order/CheckAllOrderPartsAreAddedToTag",
            async: false,
            type: "GET",
            data: { 'custOrderID': $('#custOrderId').val() },
            success: function (data) {
                returnData = data;
                if (data === false) {
                    toastr.error("One of the Order Parts is not in any Tag. Add it to Selected Tag to Continue.");
                }
            },
            failure: function (data) {

            }
        });
        return returnData;
    }
    $('#order_approve_btn').on('click', function () {
    
        var status = true;
        var custOrderId = $('#custOrderId').val();
        var approverId = $("#approvers option:selected").val();
        var poNumber = $('#po_number').val();

        if (poNumber === "") {
            status = false;
            toastr.error("Please enter PO Number to approve.");
        }
        if (approverId <= 0) {
            status = false;
            toastr.error("Please select valid approver.");
        }
        if (status) {
            $.ajax({
                dataType: "json",
                async: false,
                type: "POST",
                url: "/Order/ApproveOrder",
                data: { "approverId": approverId, "poNumber": poNumber, "custOrderId": custOrderId },
                success: function (data) {
                    if (data) {
                        toastr.success("Order successfully updated.");
                        window.location.reload();
                    } else {
                        toastr.error("An error occurred while updating order.");
                    }
                }
            });
        }
    });

    return {
        createNewTag: createNewTag,
        renderTagsInView: renderTagsInView,
        getTagsForCurrentCustomerOrder: getTagsForCurrentCustomerOrder,
        addPartToTag: addPartToTag,
        UpdateOrderState: UpdateOrderState
    }
}();
