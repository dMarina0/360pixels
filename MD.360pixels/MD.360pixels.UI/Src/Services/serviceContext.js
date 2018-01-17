﻿var ServiceContext = function () {
    var _photoService;
    var _homeService;
    var _categoryService;

    this.PhotoService = function () {
        if (!_photoService)
        {
            _photoService = new PhotoService();
        }
        return _photoService;
    }
    this.HomeService = function () {
        if (!_homeService) {
            _homeService = new HomeService();
        }
        return _homeService;
    }
    this.CategoryService = function () {
        if (!_categoryService) {
            _categoryService = new CategoryService();
        }
        return _categoryService;
    }
}