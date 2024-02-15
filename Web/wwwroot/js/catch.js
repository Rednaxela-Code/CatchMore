

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/customer/catch/getall' },
        "columns": [
            { data: 'date', "width": "15%" },
            { data: 'species', "width": "15%" },
            { data: 'length', "width": "10%" },
            { data: 'weight', "width": "10%" },
            { data: 'session.sessionName', "width": "15%" },
            { data: 'id',
            "render": function(data){
                return `<div class="w-75 btn-group" role="group">
                <a href="/customer/catch/edit?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i>Edit</a>
                <a href="/customer/catch/delete?id=${data}" class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i>Delete</a>
                </div>`
            },
            "width": "20%" },
        ]
    });
}

