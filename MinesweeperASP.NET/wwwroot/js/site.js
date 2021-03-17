$(function () {
    console.log("Page is ready");

    $(".game-button").click(function (event) {
       

        var buttonNumber = $(this).val();
        
        console.log("button " + buttonNumber + "was clicked");
        
    })
    function doButtonUpdate(buttonNumber) {
        $.ajax({
            datatype: "json",
            method: 'POST',
            url: '/grid/ShowOneButton',
            data: {
                "cellNumber": buttonNumber
            },
            success: function (data) {
                console.log(data);
                $("#" + buttonNumber).html(data);
            }
        })
    }
})