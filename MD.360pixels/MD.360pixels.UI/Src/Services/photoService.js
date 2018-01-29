var PhotoService = function () {

    this.ReadAll = function (GetData) {
        $.ajax({
            url: 'http://localhost:64172/api/photos',
            dataType: 'json',
            crossDomain: true,
            success: function (data) {
                GetData(data);
            }
        });
    }
}
    


