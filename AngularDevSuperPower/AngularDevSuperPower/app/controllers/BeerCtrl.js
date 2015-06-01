angular.module('AngularDemo.BeerController', [])
    .controller('BeerCtrl', ['$scope', '$http', function ($scope, $http) {

    	$scope.model = {};

    	$scope.states = {
    		showBeerForm: false,
			isAdding: false
    	};

    	$scope.new = {
    		Beer: {}
    	};
        $http.get('/Beer/IndexVM').success(function (data) {
            $scope.model = data;
        });

        $scope.showBeerForm = function (show) {
        	$scope.states.showBeerForm = show;
        };

        $scope.addBeer = function () {
        	$scope.states.isAdding = true;
        	$http.post('/Beer/Edit', $scope.new.Beer).success(function (data) {
        		$scope.states.isAdding = false;
        		$scope.model.Beers.push(data);
        		$scope.showBeerForm(false);
        		$scope.new.Beer = {};
        	});
        };

    }]);