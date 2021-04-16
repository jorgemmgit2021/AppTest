    /// <reference path="../../Scripts/js/Module.js" />
    /// <reference path="../../Scripts/angular.js" />
    /// <reference path="../../Scripts/toaster.min.js" />
    /// <reference path="../../Scripts/angular.min.js" />
    /// <reference path="../../Scripts/angular-animate.js" />

var app;

(function () {
    app = angular.module("ModuloCursos", ['ngAnimate', 'toaster']);
})();
app.controller("CursosController", function ($scope, CursosService, toaster, $window) {
    $scope.OperType = 1;
    GetAll();
    modalidades();
    paises();
    function GetAll() {
        var promiseGet = CursosService.getAll();
        promiseGet.then(function (pl) { $scope.Cursos = pl.data },
            function (errorPl) {
                $log.error('Some Error in Getting Records.', errorPl);
            });
    }
        
    function ClearModels() {
        $scope.Id_Curso = 0;
        $scope.Descripcion = "";
        $scope.Id_Modalidad = 0;
        $scope.Costo = 0;
        $scope.Id_Pais = 0;
        $scope.Id_Ciudad = 0;
        $scope.Direccion = "";
    }

    $scope.save = function () {
        var Curso = {
            Id_Curso: $scope.Id_Curso,
            Descripcion: $scope.Descripcion,
            Id_Modalidad: $scope.Id_Modalidad,
            Costo: $scope.Costo,
            Id_Pais: $scope.Id_Pais,
            Id_Ciudad: $scope.Id_Ciudad,
            Direccion: $scope.Direccion
        };
        if ($scope.OperType === 1) {
            var promisePost = CursosService.post(Curso);
            promisePost.then(function (pl) {
                $scope.Id_Curso = pl.data.Id_Curso;
                $scope.pop(1, "Registro de curso completo");
                GetAll();
                ClearModels();
            }, function (err) {
                $scope.pop(2,`Error durante el proceso ${err}`);
            });
        } else {
            Curso.Id = $scope.Id;
            var promisePut = CursosService.put($scope.Id_Curso, Curso);
            promisePut.then(function (pl) {
                $scope.Message = "Actualizacion completa";
                $scope.pop(1, $scope.Message);
                GetAll();
                ClearModels();
            }, function (err) {
                $scope.pop(2, `Error durante el proceso ${err}`);
            });
        }
    };

    $scope.get = function (Curso) {
        var promiseGetSingle = CursosService.get(Curso.Id_Curso);
        promiseGetSingle.then(function (pl) {
            var res = pl.data;
            $scope.Id_Curso = res.Id_Curso;
            $scope.Descripcion = res.Descripcion;
            $scope.Id_Modalidad = res.Id_Modalidad;
            $scope.Costo = res.Costo;
            $scope.Id_Pais = res.Id_Pais;
            $scope.Id_Ciudad = res.Id_Ciudad;
            $scope.Direccion = res.Direccion;
            $scope.ciudades(res.Id_Pais);
        },
            function (errorPl) {
                $scope.pop(2, `Error durante el proceso ${errPl}`);
            });
    }

    $scope.delete = function (Curso) {
        var promiseDelete = CursosService.delete(Curso.Id_Curso);
        promiseDelete.then(function (pl) {
            $scope.Message = "Registro eliminado";
            $scope.pop(3, $scope.Message);
            GetAll();
            ClearModels();
        }, function (err) {
            $scope.pop(2, `Error durante el proceso ${err}`);
        });
    }

    $scope.pop = function (type, msg) {
        switch (type) {
            case 1: { toaster.success({ title: "Notificacion Ok", body: `${msg}`});break; }
            case 2: { toaster.error("Error en el proceso", `${msg}`); break; }
            case 3: { toaster.pop({ type: 'wait', title: "Notificacion", body: `${msg}` }); break; }
        }              
    }

    function modalidades(id){
        var promiseGet = CursosService.getModalidades();
        promiseGet.then(function (pl) { $scope.Modalidades = pl.data },
            function (errorPl) {
                $log.error('Some Error in Getting Records Modalidades.', errorPl);
            });        
    }
    function paises(){
        var promiseGet = CursosService.getPaises();
        promiseGet.then(function (pl) { $scope.Paises = pl.data },
            function (errorPl) {
                $log.error('Some Error in Getting Records Paises.', errorPl);
            });        
    }
    $scope.ciudades=function (id){
        var promiseGet = CursosService.getCiudades(id);
        promiseGet.then(function (pl) { $scope.Ciudades = pl.data },
            function (errorPl) {
                $log.error('Some Error in Getting Records Ciudades.', errorPl);
            });
    }
});