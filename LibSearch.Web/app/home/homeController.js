(function(app) {
  app.controller('homeController', homeController);
  homeController.$inject = ['$scope', '$rootScope'];

  function homeController($scope, $rootScope) {
  	$rootScope.pageHome = true;
    $scope.pageClass = 'page-home';
  }
})(angular.module('LibSearch'));
