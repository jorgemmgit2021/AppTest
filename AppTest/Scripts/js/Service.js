    /// <reference path="../../Scripts/js/Module.js" />
    /// <reference path="../../Scripts/js/Controller.js" />
    /// <reference path="../../Scripts/angular.js" />
    /// <reference path="../../Scripts/angular.min.js" />
    /// <reference path="../../Scripts/angular-animate.js" />

var defaultUrl = "https://localhost:44320/Home";
app.service("CursosService", function ($http) {
    this.post = function (Curso) {
        var request = $http({
            method: "post",
            url: `${defaultUrl}/Set`,
            data: Curso
        });
        return request;
    }

    this.put = function (ID, Curso) {
        var request = $http({
            method: "put",
            url: defaultUrl + "/Set",
            data: Curso
        });
        return request;
    }

    this.getAll = function () {
        return $http.get(`${defaultUrl}/ListIndex`);
    };

    this.get = function (id) {
        return $http.get(`${defaultUrl}/ItemSearch/${id}`);
    }

    this.delete = function (Id) {
        var request = $http({
            method: "post",
            url: `${defaultUrl}/Delete/${Id}`
        });
        return request;
    }

    this.getModalidades = function() {
        return $http.get(`${defaultUrl}/GetCatalogosModalidades`)
    }
    this.getPaises = function(){
        return $http.get(`${defaultUrl}/GetCatalogosPaises`)
    }
    this.getCiudades = function (id){
        return $http.get(`${defaultUrl}/GetCatalogosCiudades/${id}`)
    }
});  