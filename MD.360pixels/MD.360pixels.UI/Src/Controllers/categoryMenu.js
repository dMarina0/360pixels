var CategoryMenu = function (containerID , categories)
{

    this.RenderMenu = function ()
    {
        var jqCategoryMenu = ("<a href ='" + categories.Href + "'> " + categories.Name + " </a>");

        $("#" + containerID).append(jqCategoryMenu);
    }
}