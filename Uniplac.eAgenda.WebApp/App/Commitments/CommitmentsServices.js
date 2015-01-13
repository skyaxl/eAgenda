var tasksServicesModule = angular.module('eAgenda-commitment-services', ['ngResource', 'dialogs.main']);
tasksServicesModule.factory('CommitmentsRestFull', function ($resource) {
    return $resource('/eAgenda/api/commitments/:id', {}, {
        update: {
            method: 'PUT'
        }
    });
}).factory('CommitmentsService', function (CommitmentsRestFull, dialogs) {
    var temporaryTasks = [];
    return {
        getAll: function (fn) {
            CommitmentsRestFull.query(function (result) {
                temporaryTasks = result.map(function (value) {
                    var compromisso = new Compromisso();
                    compromisso.initialize(value);
                    return compromisso;
                });

                fn(temporaryTasks);
            }, function (resultError) {
                dialogs.error('Erro na busca dos compromissos', resultError.data.exceptionMessage || resultError.data.message);
            });
        },
        getById: function (id, fn) {
            CommitmentsRestFull.get({ id: id }, function (value) {
                var compromisso = new Compromisso();
                compromisso.initialize(value);
                if (fn) fn(compromisso);
            }, function (resultError) {
                dialogs.error('Erro na inserção do compromisso', resultError.data.exceptionMessage || resultError.data.message);
            });
        },
        Delete: function (commitment, fn) {
            CommitmentsRestFull.delete({ id: commitment.numero }, function () { if (fn) fn(); }, function (resultError) {
                dialogs.error('Erro na inserção do compromisso', resultError.data.exceptionMessage || resultError.data.message);
            });
        },
        Insert: function (commitment, fn) {
            CommitmentsRestFull.save(commitment, function () { if (fn) fn(); }, function (resultError) {
                dialogs.error('Erro na inserção do compromisso', resultError.data.exceptionMessage || resultError.data.message);
            });
        },
        Update: function (commitment, fn) {
            CommitmentsRestFull.update({ id: commitment.numero }, commitment, function () { if (fn) fn(); }, function (resultError) {
                dialogs.error('Erro na alteração do compromisso', resultError.data.exceptionMessage || resultError.data.message);
            });
        }
    }
});