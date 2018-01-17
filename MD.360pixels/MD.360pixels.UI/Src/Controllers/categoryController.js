var CategoryController = function (serviceContext)
{
    this.RenderPage = function ()
    {
        var menuCategory = serviceContext.CategoryService().ReadAll();

        for (var i = 0; i < menuCategory.length ; i++)
        {
            var categoryMenu = new CategoryMenu("verticalMenu", menuCategory[i]);
            categoryMenu.RenderMenu();
        }
    }
}