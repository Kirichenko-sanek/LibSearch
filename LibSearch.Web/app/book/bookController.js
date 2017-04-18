(function(app) {
  app.controller('bookController', bookController);
  bookController.$inject = ['$scope', 'bookService', '$rootScope', '$location'];

  function bookController($scope, bookService, $rootScope, $location) {
    $rootScope.pageHome = false;
    $scope.pageClass = 'page-books';
    $scope.model = {
      categories: [],
      books: []
    }
    bookService.getCategories($scope.model);

    $scope.getBooks = function(category) {
      bookService.getBooks($scope.model, category);
    };

    $scope.goInfo = function(id) {
      $location.path('/bookInfo/' + id);
    };

  };
})(angular.module('LibSearch'));
