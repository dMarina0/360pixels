var CategoryService = function () {

    var _newCategory =
        {
            'CategoryID': 'D1F9FC1C-D39Q-11CE-A437-56C88306E024',
            'CategoryName': 'NewCategory'
        }
   

    this.ReadAll = function (GetData) {
       
        var result = $.ajax({
            url: 'http://localhost:64172/api/category',
            dataType: 'json',
            crossDomain: true,
        });

       result.then(function (data) { GetData(data) });
    }

    this.AddNewCategory = function () {
        $.ajax({
            type: "POST",
            url: "http://localhost:64172/api/category",
            data: JSON.stringify(_newCategory),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            crossDomain:true,
            success: function (msg) {
                alert(msg);
            }
        });
    }
}