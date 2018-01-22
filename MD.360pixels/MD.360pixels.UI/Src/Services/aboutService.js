$(function () {
    var $c = $("#test");
    $.ajax({
        type: 'GET',
        url: '/api/blog',
        success: function (challenges) {
            $.each(challenges, function (i, challenge) {
                $c.append("<li>" + challenges.Title + "</li>");
                console.log('success', challenges);
            });
        }
    });
});


