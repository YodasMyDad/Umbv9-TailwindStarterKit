angular.module("umbraco").controller("HeroBlock.Controller", function ($scope, entityResource) {

    var vm = this;

    vm.imageUrl = null;

    function loadImage(mediaItem) {
        if (mediaItem != "") {
            entityResource.getById(mediaItem.mediaKey, "Media").then(function (ent) {
                vm.imageUrl = ent.metaData.MediaPath;
            });
        } else {
            vm.imageUrl = null;
        }        
    }

    loadImage($scope.block.data.backgroundImage[0]);

    $scope.$watch("block.data.backgroundImage", function (newValue, oldValue) {
        if (newValue === oldValue) return;
        loadImage(newValue[0]);
    });

    //$scope.$watch('block.settingsData', function (oldVal, newVal) {
    //    $scope.blockbgcolor = $scope.block.settingsData.backgroundColor !== null && $scope.block.settingsData.backgroundColor.label !== undefined ? $scope.block.settingsData.backgroundColor.label + '-200' : 'white';
    //}, true);

});