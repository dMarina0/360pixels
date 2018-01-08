function showPage(pageId)
{
    $(".grid-photos").hide();
    $(pageId).show();
}

function defaultPage() {
    $("#all").show();
}

$(window).on("hashchange", function () {
    showPage(location.hash);
});

$("#Photos").on("click", function () {
    showPage("#all");
});


$("#read-more").click(function () {
    $(".normal-page").hide();
    $("#post").show();
    console.log(location.hash);
});

$("#photo-cat").click(function () {
    $(".card-deck").hide();
    $(".photos-challenges").show();
})

