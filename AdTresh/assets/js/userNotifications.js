function accountCreatedone() {
    swal({
        title: "Success !",
        text: "Record Saved Successfully !",
        icon: "success",
    });
}

function accountCreatedtwo() {
    swal({
        title: "Success !",
        text: "Record Saved Successfully !",
        icon: "success",
    });
}

function createMember() {
    swal({
        title: "Success !",
        text: "Member created Successfully !",
        icon: "success",
    });
}

function memberError() {
    swal({
        title: "Warning !",
        text: "Provide MembershipID !",
        icon: "warning",
    });
}

function noRecord() {
    swal({
        title: "Warning !",
        text: "No Regular / Other Offering record found !",
        icon: "warning",
    });
}

function noRecordII() {
    swal({
        title: "Warning !",
        text: "No record found !",
        icon: "warning",
    });
}


function MyFilter(tablename, inputname) {
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById(inputname);
    filter = input.value.toUpperCase();
    table = document.getElementById(tablename);
    tr = table.getElementsByTagName("tr");
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[0];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}


