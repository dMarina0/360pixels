var HomeImageGridController = function (containerId, photos) {


    this.RenderGrid = function () {
        var jqGrid = $("<div class='photo'>")
            .append("<img class='photo-image' src='" + photos.Photo + "'>");

            $("#" + containerId).append(jqGrid);
        }
}