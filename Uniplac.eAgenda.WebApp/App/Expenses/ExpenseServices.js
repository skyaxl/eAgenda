var ExpensesServicesModule = angular.module('eAgenda-expenses-services', ['ngResource']);
ExpensesServicesModule.factory('ExpensesRestFull', function ($resource) {
    return $resource('/eAgenda/api/expenses/:id', {}, {
        update: {
            method: 'PUT'
        }
    });
}).factory('ExpensesService', function (ExpensesRestFull, dialogs) {
    var temporaryExpenses = [];
    return {
        getAll: function (fn) {
            ExpensesRestFull.query(function (result) {
                temporaryExpenses = result.map(function (value) {
                    var despesa = new Despesa(value.numero, value.descricao, value.categoria, value.data, value.valor, value.formaPagamento);
                    return despesa;
                });

                fn(temporaryExpenses);
            }, function (resultError) {
                dialogs.error('Erro na busca das despesas', resultError.data.exceptionMessage || resultError.data.message);
            });
        },
        getById: function (id, fn) {
            ExpensesRestFull.get({ id: id }, function (value) {
                var despesa = new Despesa(value.numero, value.descricao, value.categoria, value.data, value.valor, value.formaPagamento);
                if (fn) fn(despesa);
            }, function (resultError) {
                dialogs.error('Erro na busca da despesa', resultError.data.exceptionMessage || resultError.data.message);
            });
        },
        Delete: function (expense, fn) {
            ExpensesRestFull.delete({ id: expense.numero }, function () { if (fn) fn(); }, function (resultError) {
                dialogs.error('Erro na exclusão da despesa', resultError.data.exceptionMessage || resultError.data.message);
            });
        },
        Insert: function (expense, fn) {
            ExpensesRestFull.save(expense, function () { if (fn) fn(); }, function (resultError) {
                dialogs.error('Erro na inserção da despesa', resultError.data.exceptionMessage || resultError.data.exceptionMessage || resultError.data.message);
            });
        },
        Update: function (expense, fn) {
            ExpensesRestFull.update({ id: expense.numero }, expense, function () { if (fn) fn(); }, function (resultError) {
                dialogs.error('Erro na edição da despesa', resultError.data.exceptionMessage || resultError.data.message);
            });
        }
    }
});