var page = 1;

var _inCallBack = false;

$(window).scroll(function () {
    if ($(window).scrollTop() == $(document).height() - $(window).height()) {
        loadUnits();
    }
});

function loadUnits() {
    if (page > -1 && !_inCallBack) {
        _inCallBack = true;
        page++;
        $('div#loading').html('<p><img src="Images/loader.gif"/></p>');

        $.get('/Unidad/Index/' + page, function (data) {
            if (data != '') {
                $('#unidades').html(data);
            }
            else {
                page = -1;
            }

            _inCallBack = false;
            $('div#loading').empty();
        });
    }
}