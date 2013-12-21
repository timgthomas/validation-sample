$('form').on('submit', function() {

    var request,
        data = $(this).serialize();

    var request = $.ajax({
        type: 'post',
        data: data
    });

    request.fail(function(xhr) {
        var response,
            properties, property,
            i;

        if (xhr.status === 400) {
            response = JSON.parse(xhr.responseText);
            var fields = Object.keys(response);

            fields.forEach(function(field) {
                if (response[field].Errors && response[field].Errors.length > 0) {
                    $('[name=' + field + ']')
                        .closest('p')
                        .addClass('invalid');
                }
            });
        }
    });

    request.success(function() {

    });

    return false;

});