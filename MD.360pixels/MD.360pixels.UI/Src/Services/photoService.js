var PhotoService = function () {

    var _photos = [
        {
            Id: "1",
            Img: "Img/DSC_1050.JPG"

        },
        {
            Id: "2",
            Img: "Img/DSC_1059.JPG"
        },
        {
            Id: "3",
            Img: "Img/DSC_1063.JPG"
        },
        {
            Id: "4",
            Img: "Img/DSC_1089.JPG"
        },
        {
            Id: "5",
            Img: "Img/DSC_1097.JPG"
        },
        {
            Id: "6",
            Img: "Img/DSC_1097.JPG"
        },
        {
            Id: "7",
            Img: "Img/p2.jpg"
        },
        {
            Id: "8",
            Img: "Img/DSC_1360.JPG"
        },
        {
            Id: "9",
            Img: "Img/as.jpg"
        }

    ];

    var _homePhotos = [
        {
            Id: "1",
            Img: "Img/Things-Photographers-should-not-do.jpg"
        },
        {
            Id: "2",
            Img: "https://preview.ibb.co/e0YJXG/classes_abf873c02e5784b7041b0c37e2078d6f.jpg"
        },
        {
            Id: "3",
            Img: "https://preview.ibb.co/hbTegb/exhibited.jpg"
        }
    ];

    this.ReadAll = function () {
        return _photos;
    }

    this.ReadHomePhotos = function () {
        return _homePhotos;
    }
}