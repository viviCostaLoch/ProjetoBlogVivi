$(document).ready(function () {
    $('.excluir-post').on('click', function (e) {
        if (!confirm('Deseja realmente excluir esse post?')) {
            e.preventDefault();
        }
    });

    $('.editar-post').on('click', function (e) {
        if (!confirm('Deseja realmente editar esse post?')) {
            e.preventDefault();
        }
    });

    
        $('.excluir-comentario').on('click', function (e) {
            if (!confirm('Deseja realmente excluir esse comentario?')) {
                e.preventDefault();
            }
        });


    });
