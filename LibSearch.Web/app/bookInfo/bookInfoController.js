(function(app) {
  app.controller('bookInfoController', bookInfoController);
  bookInfoController.$inject = ['$scope', 'bookService', '$rootScope','$routeParams'];

  function bookInfoController($scope, bookService, $rootScope,$routeParams) {
  	$rootScope.pageHome = false;
		$scope.pageClass = 'page-bookInfo';
		$scope.model = {
			book: {}
		}
		var currentId = $routeParams.id;

		bookService.getBook($scope.model, currentId);

		var a = 0;
  };
})(angular.module('LibSearch'));
