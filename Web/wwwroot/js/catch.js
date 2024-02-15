

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
            { data: 'session.sessionName', "width": "15%" }
        ]
    });
}

