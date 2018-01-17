var MenuController = function (serviceContext) {
    var _self = this;

    var _homeController = new HomeController(serviceContext)
    var _categoryController = new CategoryController(serviceContext)

    var _menuElements = [
        {
            Id: "Home",
            ContainerId: "divHomeContainer",
            Controller : _homeController
        },
        {
            Id: "Photos",
            ContainerId: "divPhotosContainer",
            Controller: _categoryController
        },
        {
            Id: "Blog",
            ContainerId: "divBlogContainer",
            Controller: null
        },
        {
            Id: "Challenges",
            ContainerId: "divChallengesContainer",
            Controller:null
        },
        {
            Id: "About",
            ContainerId: "divAboutContainer",
            Controller: null
        }
    ];

    this.GenerateMenu = function () {
        var jqNavbarContainer = $("#navbarContainer"); 
        for (i = 0; i < _menuElements.length; i++) {
            var jqListItem = $("<li id='" + _menuElements[i].Id + "' class='nav-item'>").append("<a class='nav-link'>" + _menuElements[i].Id + "</a>");
            jqNavbarContainer.append(jqListItem);
        }

        jqNavbarContainer.on("click", "li", goToPage);
    }

    function goToPage() {
        var jqSelectedListItem = $(this); 
        
        var selectedId = jqSelectedListItem.attr("id");
        var menuElementId;
        var selectedContainerId;
        for (index = 0; index < _menuElements.length; index++) {
            if (_menuElements[index].Id === selectedId) {
                selectedContainerId = _menuElements[index].ContainerId;
                menuElementId = index;
                break;
            }
        }

        if (!selectedContainerId) 
            return;

        var mainContainers = $("main > div");
        for (i = 0; i < mainContainers.length; i++) {
            if (mainContainers[i].id != selectedContainerId) {
                $(mainContainers[i]).hide();
                location.hash = selectedId;
            }
            else {
                $(mainContainers[i]).show();
                _menuElements[menuElementId].Controller.RenderPage();

            }
        
        }
    }
}