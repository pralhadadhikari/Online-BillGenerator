//var dtable;
//$(document).ready(function () {
//    $('#ItemId').change(function(){
//        var itemId = $("#itemId").val()";
//        GetItemPrice(itemId);
//        )};

//});

//function GetItemPrice(ItemId) {
//    alert(ItemId);

//    $.ajax({
//        type: "Get",
//        url: "/home/allitems",
//        data: { itemid: itemid },
//        dataType: "JSON",
//        contentType:"application/JSON; CharSet=utf-8"
//        success: function (data) {
//            $("#txtUnitPrice").val(praisefloat(data).toFixed(2));

//        },
//}
//    $.ajax({
//        type: "Get",
//        url: "/home/allitems",
//        data: {itemid:itemid},
//        dataType: "JSON",
//        success: function (data) {

//        },
//        error: function () {
//            alert("Error fetching price");
//        }
//    });

var dtable;

$(document).ready(function () {


    $("input").change(function () {
        total();
    });

    $("#ItemId").change(function () {

        itemPrice();
    });

    $("#AddToList").click(function () {
        addItemToList();
    });

    $("#AddToList").click(function () {
        GrandTotal();
    });
    //var itemId = $("#Item").val();


    function itemPrice() {


        $(function () {

            $.ajax({

                url: "/Home/getUnitPrice",
                datatype: "Json",
                data: { Id: $('#ItemId').val() },

                success: function (data) {
                    $('#Price').val(data);
                    
                }
            });
        });
    }



    function total() {
        var UnitPrice = $("#Price").val();
        var Quantity = $("#Quantity").val();
        var Discount = $("#Discount").val();
        var amount = parseInt(UnitPrice) * parseInt(Quantity);
        Total = (amount - (amount * (parseInt(Discount)) * .01));
        $("#Total").val(Total);
    };

    function addItemToList() {

        var tblItem = $("#myTable");

        var UnitPrice = $("#Price").val();
        var Quantity = $("#Quantity").val();
        var Discount = $("#Discount").val();

        //var Snum = $("#myTable tbody").children().length + 1;
        var ItemName = $("#ItemId option:selected").text();
        var ItemIdd = $("#ItemId option:selected").val();
        var Amount = UnitPrice * Quantity;
        var Total = (Amount - (Amount * Discount) * .01)

        var ItemList = "<tr><td>"
            + ItemIdd +
            "</td><td>"
            + ItemName +
            "</td><td>"
            + UnitPrice +
            "</td><td>"
            + Quantity +
            "</td><td>"
            + Discount +
            "</td><td>"
            + Total +
            "</td><td><button type='submit' class='btn btn-danger' id= 'RemoveItem'>Remove</button></td></tr>";

        tblItem.append(ItemList);
        calculateGT();
        ResetItem();

        $("#RemoveItem").click(function () {
            $(this).parent().parent().remove();

        });

        


    }



    function calculateGT() {
        $("#GrandTotal").val("0.00");
        var FinalTotal = 0.00;

        $("#myTable").find("tr:gt(0)").each(function(){
            var Total = parseFloat($(this).find("td:eq(5)").text());
            FinalTotal += Total;
           
        });

        $("#GrandTotal").val(FinalTotal); 

    }

     
    function ResetItem() {
        $("#Price").val('');
        $("#Quantity").val('');
        $("#Discount").val('0');
        $("#ItemId").val('');;
        $("#Total").val('');

    }

       

});



