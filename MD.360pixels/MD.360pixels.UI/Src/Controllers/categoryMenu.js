var CategoryMenu = function (containerID , categories)
{

    this.RenderMenu = function ()
    {
        var jqCategoryMenu = ("<a href ='" + '#'+ categories.CategoryName + "'> " + categories.CategoryName + " </a>");

        $("#" + containerID).append(jqCategoryMenu);
    }
}