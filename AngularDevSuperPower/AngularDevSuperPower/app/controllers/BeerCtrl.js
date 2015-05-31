angular.module('AngularDemo.BeerController', [])
    .controller('BeerCtrl', ['$scope', '$http', function ($scope, $http) {

        $scope.model = {};
        $http.get('/Beer/IndexVM').success(function (data) {
            $scope.model = data;
        });
    }]);