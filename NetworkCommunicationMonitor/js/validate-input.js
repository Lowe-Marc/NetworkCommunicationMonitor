/*=====================================================================================================
                                               AJAX
 ======================================================================================================*/
function submitStore() {
    let ipOne = $("#storeIpAddress").val()
    let ipTwo = $("#storeIpConnectedTo").val()
    let name = $("#storeName").val();
    let weight = parseInt($("#storeWeight").val())

    let store = new Object();
    store.ipOne = ipOne;
    store.ipTwo = ipTwo;
    store.name = name;
    store.weight = weight;
    console.log("name: ", store.name);
    if (!store.name) {
        console.log("no name");
        $('#store-name-form').addClass('has-error');
    } else if (!store.weight) {
        $('#store-name-form').removeClass('has-error');
        $('#store-weight').addClass('has-error');
    } else {
        $('#store-weight').removeClass('has-error');
        //Database insertion
        $.ajax({
            method: "POST",
            url: "/Home/AddStore",
            data: store,
            success: (result) => {
                alert(result);
                if (result === "Store added successfully!") {
                    $('#close-store').click();
                    window.location.reload();
                }
            },
            error: (result) => {
                console.log(result);
            }
        });
    }
}

function submitConnection() {
    let ipOne = $("#ipOne").val()
    let ipTwo = $("#ipTwo").val()
    let weight = parseInt($("#connectionWeight").val())

    let connection = new Object();
    connection.ipOne = ipOne;
    connection.ipTwo = ipTwo;
    connection.weight = weight;

    if (!connection.weight) {
        $('#connect-form').addClass('has-error');
    } else {
        $('#connect-form').removeClass('has-error');
        //Database insertion
        $.ajax({
            method: "POST",
            url: "/Home/AddConnection",
            data: connection,
            success: (result) => {
                alert(result);
                if (result === "Connection added successfully!") {
                    $('#close-connection').click();
                    window.location.reload();
                }
            },
            error: (result) => {
                alert("Error on ajax request");
            }
        });
    }
}

function deleteAccount() {
    let accountID = parseInt($("#delete-accountID").val());
    let check = $("#confirmation-checkbox").is(":checked");

    if (!accountID) {
        $('#delete-accountId').addClass('has-error');
    } else if (!check) {
        $('#delete-accountId').removeClass('has-error');
        $('#delete-check').empty();
        $('#delete-check').append('<h4 class="text-danger text-center">you should select the checkbox</h4>');
        setTimeout(function () {
            $('#delete-check h4').fadeOut();
        }, 5000);
    } else {
        //Database insertion
        $.ajax({
            method: 'POST',
            url: `/Home/DeleteAccount`,
            data: { accountID: accountID } ,
            success: (result) => {
                alert(result);
                if (result === "Account " + accountID + " successfully deleted") {
                    $('#close-delete-card').click();
                    window.location.reload();
                }
            },
            error: (result) => {
                console.log(result);
            }
        });
    }
}

function deletCard() {
    let cardNumber = parseInt($("#delete_cardNumber").val());
    let confirmNum = parseInt($("#confirm_delete_cardNumber").val());
    let check = $("#confirmation-checkDelete").is(":checked");

    console.log("num:", cardNumber);
    console.log("confirm: ", confirmNum);
    console.log("check: ", check);

    if (!cardNumber) {
        $('#card-number').addClass('has-error');

    } else if (!confirmNum) {
        $('#card-number').removeClass('has-error');
        $('#confirm-card-number').addClass('has-error');

    } else if (confirmNum != cardNumber) {
        $('#confirm-card-number').removeClass('has-error');
        $('#confirm-card-number').addClass('has-error');
        $('#delete-card-check').empty();
        $('#delete-card-check').append('<h4 class="text-danger text-center">two card numbers are not the same, please input again</h4>');
        setTimeout(function () {
            $('#delete-card-check h4').fadeOut();
        }, 5000);

    } else if (!check) {
        $('#confirm-card-number').removeClass('has-error');
        $('#delete-card-check').empty();
        $('#delete-card-check').append('<h4 class="text-danger text-center">you should select the checkbox</h4>');
        setTimeout(function () {
            $('#delete-card-check h4').fadeOut();
        }, 5000);

    } else {
        $('#confirm-card-number').removeClass('has-error');
        //Database insertion
        $.ajax({
            method: 'POST',
            url: `/Home/DeleteCard`,
            data: { cardNumber: cardNumber },
            success: (result) => {
                alert(result);
                if (result === "Card " + cardNumber + " successfully deleted") {
                    $('#close-delete-card').click();
                    window.location.reload();
                }
            },
            error: (result) => {
                console.log(result);
            }
        });
    }
}