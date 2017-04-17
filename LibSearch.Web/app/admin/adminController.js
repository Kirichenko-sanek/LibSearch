(function(app) {
  app.controller('adminController', adminController);

  adminController.$inject = ['$scope', 'bookService', '$http'];

  function adminController($scope, bookService, $http) {
    $scope.pageClass = 'page-admin';



    $scope.file = {};

    $scope.options = {
      change: function(file) {
        file.$preview($scope.model);
        $scope.file = file;
      }
    }

    $scope.addInfo = function() {
      bookService.addAllBook($scope.file);
    };





  };
})(angular.module('LibSearch'));
