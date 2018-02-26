var page = 1;


function loadUnitsPage() {
    if (page > -1 ) {
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