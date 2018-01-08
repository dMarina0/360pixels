var MenuController = function () {
    var _self = this;

    var _menuElements = [
        {
            Id: "Home",
            ContainerId: "divHomeContainer"
        },
        {
            Id: "Photos",
            ContainerId: "divPhotosContainer"
        },
        {
            Id: "Blog",
            ContainerId: "divBlogContainer"
        },
        {
            Id: "Challenges",
            ContainerId: "divChallengesContainer"
        },
        {
            Id: "About",
            ContainerId: "divAboutContainer"
        }
    ];

    this.GenerateMenu = function () {
        var jqNavbarContainer = $("#navbarContainer"); //ul ID
        for (i = 0; i < _menuElements.length; i++) {
            var jqListItem = $("<li id='" + _menuElements[i].Id + "' class='nav-item'>").append("<a class='nav-link'>" + _menuElements[i].Id + "</a>");
            jqNavbarContainer.append(jqListItem);
        }

        jqNavbarContainer.on("click", "li", goToPage);
    }

    function goToPage() {
        var jqSelectedListItem = $(this); 
        
        var selectedId = jqSelectedListItem.attr("id");
       
        var selectedContainerId;
        for (index = 0; index < _menuElements.length; index++) {
            if (_menuElements[index].Id === selectedId) {
                selectedContainerId = _menuElements[index].ContainerId;
               
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

            }
        
        }
    }
}