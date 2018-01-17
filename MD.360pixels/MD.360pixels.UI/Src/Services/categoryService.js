var CategoryService = function () {


    var _categoryMenu=[
        
        {
            Id: "1",
            Name: "All",
            Href: "#all"
        },
        {
            Id: "2",
            Name: "Abstract",
            Href: "#abstract"
        },
        {
            Id: "3",
            Name: "Action",
            Href: "#action"
        },
        {
            Id: "4",
            Name: "Street",
            Href: "#street"
        },
        {
            Id: "5",
            Name: "Macro",
            Href: "#macro"
        },
        {
            Id: "6",
            Name: "Night",
            Href: "#night"
        },
        {
            Id: "7",
            Name: "Portrait",
            Href: "#portrait"
        },
        {
            Id: "8",
            Name: "Landscape",
            Href: "#landscape"
        },
        {
            Id: "9",
            Name: "People",
            Href: "#people"
        }

    ];

    this.ReadAll = function () {

        return _categoryMenu;
    }
}