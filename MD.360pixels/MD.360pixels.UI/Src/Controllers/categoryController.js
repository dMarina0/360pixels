var CategoryController = function (serviceContext)
{
    
    this.RenderPage = function ()
    {
        serviceContext.CategoryService().ReadAll(function (menuCategory) {
            for (var i = 0; i < menuCategory.length; i++) {
                var categoryMenu = new CategoryMenu("verticalMenu", menuCategory[i]);
                categoryMenu.RenderMenu();
                
            }
        });

    }

}