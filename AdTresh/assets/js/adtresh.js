$(document).ready(function () {
    // script for member page - 
    var t = document.getElementById("showmwmberform");
    t.style.display = "none";

    //Bind the click event for the button
    $(".display").bind("click", function (evt) {
        evt.preventDefault();
        var x = document.getElementById("showmwmberform");
        var y = document.getElementById("showmembertable");

        if (x.style.display === "none") {
            x.style.display = "block";
            y.style.display = "none";
            $(".display").html("View Members");

        } else {
            x.style.display = "none";
            y.style.display = "block";
            $(".display").html("Add New Member");
        }
        return false;
    });

});

$(document).ready(function () {

    // script for report page - to hide and show input fields 
    var x = document.getElementById("showMonthlyFields");
    var y = document.getElementById("showWeeklyFields");
    var z = document.getElementById("showSimpleSumamry");
    x.style.display = "none";
    y.style.display = "none";
    z.style.display = "none";

    $("select.selectreport").change(function () {
        var selectedreport = $(this).children("option:selected").val();
        if (selectedreport === "monthlyReport") {
            x.style.display = "block";
            y.style.display = "none";
            z.style.display = "none";
        } else if (selectedreport === "weeklySummary") {
            y.style.display = "block";
            x.style.display = "none";
            z.style.display = "none";
        } else if (selectedreport === "simpleSummary") {
            z.style.display = "block";
            x.style.display = "none";
            y.style.display = "none";
        } else {
            x.style.display = "none";
            y.style.display = "none";
            z.style.display = "none";
        }

    });
});

