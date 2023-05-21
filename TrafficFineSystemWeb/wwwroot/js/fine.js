var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Fine/GetAll"
        },
        "columns": [
            { "data": "fineId", "width": "10%" },
            { "data": "vehicleNumber", "width": "10%" },
            { "data": "fineType", "width": "10%" },
            { "data": "licenseNumber", "width": "10%" },
            { "data": "amount", "width": "10%" },
            { "data": "driversAdd.name", "width": "10%" },
            { "data": "trafficAdd.name", "width": "10%" },
            {
                "data": "fineId",
                "render": function (data) {
                    return `
                    <div class="w-75 btn-group" role="group">

                  <a href = "/Fine/Upsert?fineId=${data}"
                  class="btn btn-primary mx-2">
                      <i class="bi bi-pencil-square"></i>Edit
                  </a>   
                  <a onClick=Delete('/Fine/Delete/${data}')
                  class="btn btn-danger mx-2">
                      <i class="bi bi-archive-fill"></i>Delete
                  </a>      
                    </div>
                    `
                },
                "width": "40%",
            },
        ]
    });
}

function Delete(url) {
    //Swal.fire({
    //    title: 'Are you sure?',
    //    text: "once deleted can't be reverted",
    //    icon: 'warning',
    //    showCancelButton: true,
    //    confirmButtonColor: '#3085d6',
    //    cancelButtonColor: '#d33',
    //    confirmButtonText: 'Yes, delete it!'
    //}).

    //    then((result) => {
    //    if (result.isConfirmed) {
    //        $.ajax({
    //            url: url,
    //            type: 'DELETE',
    //            success: function (data) {
    //                if (data.success) {
    //                    dataTable.ajax.reload();
    //                    toastr.success(data.message);
    //                }
    //                else {
    //                    toastr.error(data.message);
    //                }
    //            }
    //        })
    //    }
    //})

    $.ajax({
        url: url,
        type: 'DELETE',
        success: function (data) {
            if (data.success) {
                dataTable.ajax.reload();
                toastr.success(data.message);
            }
            else {
                toastr.error(data.message);
            }
        }
    })
}