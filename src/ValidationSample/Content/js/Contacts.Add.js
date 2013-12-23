$('form').on('submit', function() {

    var request,
        $page = $('body'),
        $form = $(this),
        $response = $('.response'),
        data = $form.serialize();

    var request = $.ajax({
        type: 'post',
        data: data
    });

    request.fail(function(xhr) {
        var response, i;

        $form.find('p.invalid').removeClass('invalid');

        if (xhr.status === 400) {
            response = JSON.parse(xhr.responseText);
            var fields = Object.keys(response);
            $response.text(vkbeautify.json(xhr.responseText, 2));

            fields.forEach(function(field) {
                if (response[field].Errors && response[field].Errors.length > 0) {
                    $('[name=' + field + ']')
                        .closest('p')
                        .addClass('invalid');
                }
            });
        }

        $page.removeClass('successful').addClass('invalid');
    });

    request.success(function() {
        $form.find('p.invalid').removeClass('invalid');
        $page.removeClass('invalid').addClass('successful');
        $response.text('(No response body)')
    });

    return false;

});