$(document).ready(function () {
    $('.excluir-post').on('click', function (e) {
        if (!confirm('Deseja realmente excluir esse Usuario?')) {
            e.preventDefault();
        }
    });

    $('.editar-post').on('click', function (e) {
        if (!confirm('Deseja realmente editar esse Usuario?')) {
            e.preventDefault();
        }
    });
});