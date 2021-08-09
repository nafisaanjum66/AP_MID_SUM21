var app = angular.module("myApp", ["ngRoute"]);
app.config(["$routeProvider","$locationProvider",function($routeProvider,$locationProvider) {

    $routeProvider
    .when("/homepage", {
        templateUrl : "views/pages/homepage.html",
        controller: 'homepage'
    })
    .when("/doctor", {
        templateUrl : "views/pages/doctor.html",
        controller: 'doctor'
    })
    .when("/admin", {
        templateUrl : "views/pages/admin.html",
        controller: 'admin'
    })
    .otherwise({
        redirectTo:"/"
    });
      //$locationProvider.html5Mode(true);
      //$locationProvider.hashPrefix('');
      //if(window.history && window.history.pushState){
      //$locationProvider.html5Mode(true);
  //}

}]);
