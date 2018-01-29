var HomeController = function (serviceContext) {

    this.RenderPage = function () {

        serviceContext.PhotoService().ReadAll(function (allPhotos) {
            for (var i = 0; i < 9; i++) {
                var homeImageGridController = new HomeImageGridController("imageGridHome", allPhotos[i]);
                homeImageGridController.RenderGrid();

            }
        });
            
 };


}