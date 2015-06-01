angular.module('app', ['AngularDemo.BeerController'])
	.directive('loadingButton', function () {
		return {
			restrict: 'A',
			scope: {
				spin: '='
			},
			link: function (scope, element, attr) {
				$(element).ladda();

				scope.$watch('spin', function (newValue, oldValue) {
					if (newValue) {
						$(element).ladda('start');
					} else {
						$(element).ladda('stop');
					}
				});
				
				
			}
		};
	});