angular.module("umbraco").controller("FeatureBlock.Controller", function ($scope, entityResource) {

    var vm = this;

    $scope.loadBoxSvg = function (box) {

        entityResource.getById(box.sVGIcon[0].mediaKey, "Media")
            .then(function (ent) {
                box.ImageUrl = ent.metaData.MediaPath;
            });      
    }



});