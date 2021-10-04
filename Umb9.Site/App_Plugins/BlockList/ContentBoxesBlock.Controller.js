angular.module("umbraco").controller("ContentBoxesBlock.Controller", function ($scope, entityResource) {

    $scope.loadBoxImage = function (box) {

        entityResource.getById(box.coverImage[0].mediaKey, "Media")
            .then(function (ent) {
                box.ImageUrl = ent.metaData.MediaPath;
            });
    }



});