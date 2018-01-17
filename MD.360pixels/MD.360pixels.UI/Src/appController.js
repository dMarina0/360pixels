$(document).ready(function () {
    _serviceContext = new ServiceContext();
    var menuController = new MenuController(_serviceContext);
    menuController.GenerateMenu();
});