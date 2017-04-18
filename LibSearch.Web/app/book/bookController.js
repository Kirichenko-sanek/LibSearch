(function(app){
	app.controller('bookController', bookController);
	bookController.$inject = ['$scope', 'bookService'];

	function bookController($scope, bookService) {
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