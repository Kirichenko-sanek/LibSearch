(function() {
  window.angular.module('LibSearch', ['ngRoute', 'ngCookies', 'oi.file', 'LocalStorageModule', 'ngAria'/*, 'ngAnimate', 'ngMaterial', 'ngProgress'*/])
    .config(config)
    .run(run);

  config.$inject = ['$routeProvider', '$locationProvider'];
  run.$inject = ['localStorageService', '$http', '$rootScope'];

  function config($routeProvider, $locationProvider) {
    $locationProvider.html5Mode(true);
    $locationProvider.hashPrefix('!');
    $routeProvider
      .when('/', {
        templateUrl: "app/home/home.html",
        controller: "homeController"
      })
      .when("/login", {
        templateUrl: "app/login/login.html",
        controller: "logInController"
      });
  };


  function run(localStorageService, $http, $rootScope) {
    //$rootScope.localAddress = '/libsearchapi/';
    $rootScope.localAddress = 'http://localhost:60669/';
    var aut = localStorageService.get('authorizationData');
    if (aut !== null) {
      $http.defaults.headers.common['Authorization'] = 'Bearer ' + aut.token;
      $http.post($rootScope.localAddress + 'api/account/userInSystem')
        .then(
          function(data) {
            $rootScope.userLog = data.data;
            $rootScope.userNameLog = aut.userName;
          })
        .catch(function(result) {
          console.log('Result: ', result);
        })
        .finally(function() {
          console.log('Finally');
        });
    } else {
      $rootScope.userLog = null;
    }
  };




})();
