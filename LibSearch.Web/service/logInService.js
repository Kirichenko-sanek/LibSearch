(function(app) {
  app.factory('logInService', logInService);
  logInService.$inject = ['$http', '$location', '$rootScope', 'localStorageService'];

  function logInService($http, $location, $rootScope, localStorageService) {
    var service = {
      login: login
    }

    function login(model) {
      model.error = '';
      var aut = "grant_type=password&username=" + model.email + "&password=" + model.password;
      $http.post($rootScope.localAddress + 'token', aut)
        .then(function(data) {
          localStorageService.set('authorizationData', {
            token: data.data.access_token,
            userName: model.email
          });
          $http.defaults.headers.common['Authorization'] = 'Bearer ' + data.data.access_token;
          $http.post($rootScope.localAddress + 'api/account/userInSystem')
            .then(
              function(data) {
                $rootScope.userLog = data.data;
                if (data.data === 'Admin') {
                  $location.path('/admin');
                } else {
                  $location.path('/home');
                }

              })
            .catch(function(result) {
              console.log('Result: ', result);
            })
            .finally(function() {
              console.log('Finally');
            });
        })
        .catch(function(result) {
          model.error = result.data.error_description;
          $location.path('/login');
          console.log('Result: ', result);
        })
        .finally(function() {
          console.log('Finally');
        });
    }
    return service;
  }
})(angular.module('LibSearch'));
