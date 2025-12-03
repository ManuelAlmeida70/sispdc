$(document).ready(function () {
    // Inicializar DataTables com tradução em Português
    $('#especialidade').DataTable({
        "language": {
            "decimal": ",",
            "thousands": ".",
            "emptyTable": "Nenhum registro encontrado",
            "info": "Mostrando _START_ até _END_ de _TOTAL_ registros",
            "infoEmpty": "Mostrando 0 até 0 de 0 registros",
            "infoFiltered": "(filtrado de _MAX_ registros no total)",
            "infoPostFix": "",
            "lengthMenu": "Mostrar _MENU_ registros por página",
            "loadingRecords": "Carregando...",
            "processing": "Processando...",
            "search": "Pesquisar:",
            "zeroRecords": "Nenhum registro encontrado",
            "paginate": {
                "first": "Primeiro",
                "last": "Último",
                "next": "Próximo",
                "previous": "Anterior"
            },
            "aria": {
                "sortAscending": ": ativar para ordenar a coluna em ordem crescente",
                "sortDescending": ": ativar para ordenar a coluna em ordem decrescente"
            }
        },
        "pageLength": 5,
        "lengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "Todos"]],
        "order": [[0, "asc"]],
        "columnDefs": [
            { "orderable": false, "targets": 3 }
        ]
    });

    //setTimeout(function () {
    //    $(".alert").fadeOut("slow", function (){
    //        $(this).alert("close")
    //    })
    //}, 500)
});