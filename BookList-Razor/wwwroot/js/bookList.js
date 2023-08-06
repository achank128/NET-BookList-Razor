var dataTable;

$(document).ready(function () {
    loadDataTable()
})

function loadDataTable() {
    dataTable = $("#DT_load").DataTable({
        "ajax": {
            "url": "/api/book",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {"data": "name", "width": "20%"},
            {"data": "author", "width": "20%"},
            {"data": "isbn", "width": "20%"},
            {
                "data": "id",
                "render": function (data) {
                    return `
                    <div class="text-center">
                        <a  class="btn btn-danger btn-sm text-white" style="width=70px;" onclick=Delete('/api/book?id='+${data}) >Delete</a>
                        &nbsp;
                        <a href="/BookList/Upsert?id=${data}" class="btn btn-success btn-sm text-white">Edit</a>
                    </div>
                `
                },
                "width": "40%"
            }
        ],
        "language": {
            "emptyTable": "No data found"
        },
        "width": "100%"
    })
}

function Delete(url) {
    console.log("Delete");
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able recover!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    } else {
                        toastr.error(date.message);
                    }
                }
            })
        }
    })

}