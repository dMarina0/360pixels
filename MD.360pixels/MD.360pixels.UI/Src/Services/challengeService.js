var ChallengeService = function () {
    
    this.ReadAll = function (GetData) {
        $.ajax({
            url: 'http://localhost:64172/api/challenges',
            dataType: 'jsonp',
            crossDomain:true,
            success: function (data) {
               GetData(data);
                alert(data);
            }
        });
    }
}