(function(app) {
  app.factory('bookService', bookService);
  bookService.$inject = ['$http', '$location', '$rootScope'];

  function bookService($http, $location, $rootScope) {
    var service = {
      addAllBook: addAllBook,
      getCategories: getCategories,
      getBooks: getBooks
    }

    function addAllBook(file) {
      var fd = new FormData();
      fd.set('file', file);
      file.$upload($rootScope.localAddress + 'api/admin/uploadInfo', fd)
        .then(function(data) {
          var a = 0;
        });
    };

    function getCategories(model) {
      $http.get($rootScope.localAddress + 'api/account/getCategories')
        .then(function(data) {
          model.categories = data.data;
        })
        .catch(function(result) {
          if (status === 401) {
            $location.path('/login');
          }
          console.log('Result: ', result);
        })
        .finally(function() {
          console.log('Finally');
        });
    };

    function getBooks(model, category) {
      $http.post($rootScope.localAddress + 'api/account/getBooks', '"' + category + '"')
        .then(function(data) {
          model.books = data.data;
        })
        .catch(function(result) {
          if (status === 401) {
            $location.path('/login');
          }
          console.log('Result: ', result);
        })
        .finally(function() {
          console.log('Finally');
        });
    }









    return service;
  };





})(angular.module('LibSearch'));
