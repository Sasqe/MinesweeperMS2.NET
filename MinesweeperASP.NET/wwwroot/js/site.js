$(function () {
    console.log("Page is ready");
    $(document).bind("contextmenu", function (e) {
        e.preventDefault();
        console.log("Right click. Prevent context menu from showing.")
    });

    $(document).on("mousedown", ".game-button", function (event) {

        switch (event.which) {

            case 1:
                
                var buttonNumber = $(this).val();
                console.log("Button number " + buttonNumber + " was left clicked");
            
                break;
            case 2:
                alert('Middle mouse button is pressed');
                break;
            case 3:
                event.preventDefault();
                var buttonNumber = $(this).val();
                console.log("Button Number " + buttonNumber + " was right clicked");
                doFlag(buttonNumber);
                break;
            default:
                alert('Nothing');
        }

    });
});
    function doFlag(buttonNumber) {
        $.ajax({
            datatype: "json",
            method: 'POST',
            url: '/grid/flag',
            data: {
                "cellNumber": buttonNumber
            },
            success: function (data) {
                console.log(data);
                console.log($("#" + buttonNumber));
                $("#" + buttonNumber).html(data);
            }
        })
    }
