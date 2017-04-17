(function(app) {
  app.factory('bookService', bookService);
  bookService.$inject = ['$http', '$location', '$rootScope'];

  function bookService($http, $location, $rootScope) {
    var service = {
      addAllBook: addAllBook
    }

    function addAllBook(file) {
      var fd = new FormData();
      fd.set('file', file);
      file.$upload($rootScope.localAddress + 'api/admin/uploadInfo', fd)
        .then(function(data) {
          var a = 0;
        });
    };









    return service;
  };





})(angular.module('LibSearch'));
