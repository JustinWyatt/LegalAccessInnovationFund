var app = angular.module("app", ['ui.tinymce']);

app.controller("formController", ['$scope', '$http', function ($scope, $http) {



    $scope.tinymceOptions = {
        onChange: function (e) {
            // put logic here for keypress and cut/paste changes
        },
        inline: false,
        plugins: 'advlist autolink link image lists charmap print preview',
        skin: 'lightgray',
        theme: 'advanced',
        height: 500
    };


    $scope.campaign = {
        Title: '',
        Goal: 0,
        Picture: '',
        DonationLevels: [

        ]
    }

    $scope.hide = true;
    $scope.confirmed = false;

    $http.get('campaign/currentcampaign').then(function (result) {

        $scope.campaign = result.data;

    });

    $scope.newDonationLevel = function () {

        if ($scope.donationModel) {

            $scope.campaign.DonationLevels.push($scope.donationModel);
            $scope.donationModel = {};
        }

    }

    $scope.campaign.Picture = "http://www.bestfact.net/wp-content/uploads/2014/05/Bestfact-JL-Carli-Conference-La-Defense-3112_original.jpg";

    $scope.submitForm = function () {
        $scope.confirmed = true;

        $http.post('/campaign/startcampaign').then(function (id) {
            $scope.campaign = {};
            $scope.id = id;
        });
    }
}]);