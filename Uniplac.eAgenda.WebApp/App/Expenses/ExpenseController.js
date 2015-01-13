eAgendaApp.controller('expensesController', function ($scope, $state, $window, dialogs, ExpensesService) {
    $scope.expenses = [];

    $scope.refresh = function () {
        ExpensesService.getAll(function (array) {
            $scope.expenses = array;
        });
    }
    $scope.refresh();

    $scope.DespesaAtual = !$scope.DespesaAtual ? null : $scope.DespesaAtual;

    $scope.cancelEditOrUpdate = function () {
        $state.go('expenses.main');
    };

    $scope.VerifyModel = function () {
        if (!$scope.DespesaAtual)
            $scope.cancelEditOrUpdate();
    }

    $scope.AddDespesa = function () {
        $scope.DespesaAtual = new Despesa(0, '', '', new Date(), '0.0', '');
        $state.go('expenses.add');
    };

    $scope.EditarDespesa = function () {
        $scope.DespesaAtual = $scope.options.activeRowObject;

        if (!$scope.DespesaAtual) {
            dialogs.error("Selecione uma Despesa", "Selecione uma Despesa.", {});

            return;
        }

        ExpensesService.getById($scope.DespesaAtual.numero, function (despesa) {
            $scope.DespesaAtual = despesa;
            $state.go('expenses.add');
        });
    };

    $scope.options = expensesgrid;

    $scope.saveExpense = function () {
        if ($scope.DespesaAtual.numero == 0) {
            ExpensesService.Insert($scope.DespesaAtual, function () {
                $scope.refresh();
                $scope.cancelEditOrUpdate();
            });
        }
        if ($scope.DespesaAtual.numero != 0) {
            ExpensesService.Update($scope.DespesaAtual, function () {
                $scope.cancelEditOrUpdate();

                $scope.refresh();
            });
        }
    }

    $scope.RemoverDespesa = function () {
        $scope.DespesaAtual = $scope.options.activeRowObject;

        if (!$scope.DespesaAtual) {
            dialogs.error("Confirmação de exclusão", "Selecione uma Despesa.", {});
            return;
        }
        var deleteDialog = dialogs.confirm("Confirmação de exclusão", "Você deseja realmente excluir esta Despesa?", { size: 'md' });
        deleteDialog.result.then(function () {
            ExpensesService.Delete($scope.DespesaAtual, function () {
                $scope.expenses.removeElement($scope.DespesaAtual);
            });
        }, function (btn) { });
    };
});