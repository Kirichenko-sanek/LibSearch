(function(app){
	app.controller('bookController', bookController);
	bookController.$inject = ['$scope', 'bookService', '$rootScope'];

	function bookController($scope, bookService, $rootScope) {
		$rootScope.pageHome = false;
		$scope.pageClass = 'page-books';
		$scope.model = {
			categories: [],
			books: []
		}
		bookService.getCategories($scope.model);

		$scope.getBooks = function(category){
			bookService.getBooks($scope.model, category);
		};









	};
})(angular.module('LibSearch'));