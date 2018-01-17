var HomeController = function (serviceContext) {

    this.RenderPage = function () {
        var allPhotos = serviceContext.PhotoService().ReadAll();
        var descriptionPhotos = serviceContext.PhotoService().ReadHomePhotos();
        for (var i = 0; i < allPhotos.length; i++)
        {
            var homeImageGridController = new  HomeImageGridController("imageGridHome", allPhotos[i]);
            homeImageGridController.RenderGrid();
        }
        //for (var j = 0; j < descriptionPhotos.length; j++) {
        //    var homeDescription = new HomeDescription("heroImage", "firstDescription", descriptionPhotos[j]);
        //    homeDescription.RenderDescription();
        //}
    }
}