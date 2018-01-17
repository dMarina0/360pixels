var HomeImageGridController = function (containerId, photos) {


    this.RenderGrid = function () {
        var jqGrid = $("<div class='photo'>")
            .append("<img class='photo-image' src='" + photos.Img + "'>");
    

            $("#" + containerId).append(jqGrid);
        }
}