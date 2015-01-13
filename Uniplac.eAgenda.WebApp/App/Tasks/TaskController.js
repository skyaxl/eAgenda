eAgendaApp.controller('TasksController', function ($scope, $state, $window, dialogs, TasksService) {
    $scope.tasks = [];

    $scope.refresh = function () {
        TasksService.getAll(function (array) {
            $scope.tasks = array;
        });
    }
    $scope.refresh();

    $scope.TarefaAtual = !$scope.TarefaAtual ? null : $scope.TarefaAtual;
    $scope.ItemExecucaoAtual = new ItemTarefa(0, null, 0);

    $scope.AddTarefa = function () {
        $scope.TarefaAtual = new Tarefa(0, 0, '', '', [], 0);
        $state.go('tasks.add');
    };

    $scope.EditarTarefa = function () {
        $scope.TarefaAtual = $scope.options.activeRowObject;

        if (!$scope.TarefaAtual) {
            alert('selecione uma tarefa');
            return;
        }

        $scope.getTaskById($scope.TarefaAtual, function () {
            $state.go('tasks.add');
        });
    };

    $scope.NovoItem = function () {
        $scope.ItemExecucaoAtual = new ItemTarefa(0, null, 0);
    }
    $scope.RecauculaPorcentagem = function (datasource) {
        angular.forEach(datasource, function (item) {
            if (item.itensExecucacao.length != 0)
                item.cauculaPercentual();
        });
    };

    $scope.options = tasksgrid;
    $scope.optionsItemsTasks = itensTasksGrid;
    $scope.onSelectItem = function (value) {
        $scope.ItemExecucaoAtual = value;
    }

    $scope.saveTask = function () {

        if ($scope.TarefaAtual.itensExecucacao.length == 0) {
            dialogs.error('Erro na inserção da tarefa', 'A tarefa deve possuir ao menos um item de execução').result.then(function () {

                document.getElementById('tituloItem').focus();

            });
            return;
        }



        if ($scope.TarefaAtual.numero == 0) {
            TasksService.Insert($scope.TarefaAtual, function () { $state.go('tasks.main'); });
        }
        if ($scope.TarefaAtual.numero != 0) {
            TasksService.Update($scope.TarefaAtual, function () { $state.go('tasks.main'); });
        }
    }

    $scope.getTaskById = function (data, fn) {
        TasksService.getById(data.numero, function (task) {
            data.itensExecucacao = [];
            for (var i = 0; i < task.itensExecucacao.length; i++) {
                data.adicionarItemExecucao(task.itensExecucacao[i]);
            }
            if (fn)
                fn();
        });
    }

    $scope.beforecollapse = function (data) {
        $scope.getTaskById(data);
    }

    $scope.RemoverItem = function () {
        if (!$scope.ItemExecucaoAtual) {
            dialogs.error("Confirmação de exclusão", "Selecione uma item de execução.", {});
            return;
        }

        var deleteDialog = dialogs.confirm("Confirmação de exclusão", "Você deseja realmente excluir este item?", { size: 'md' });
        deleteDialog.result.then(function () {
            $scope.TarefaAtual.itensExecucacao.splice($scope.tasks.indexOf($scope.ItemExecucaoAtual), 1);
        }, function (btn) { });
    }

    $scope.RemoverTarefa = function () {
        $scope.TarefaAtual = $scope.options.activeRowObject;

        if (!$scope.TarefaAtual) {
            dialogs.error("Confirmação de exclusão", "Selecione uma tarefa.", {});
            return;
        }
        var deleteDialog = dialogs.confirm("Confirmação de exclusão", "Você deseja realmente excluir esta tarefa?", { size: 'md' });
        deleteDialog.result.then(function () {
            TasksService.Delete($scope.TarefaAtual, function () {
                $scope.tasks.splice($scope.tasks.indexOf($scope.TarefaAtual), 1);
            });
        }, function (btn) { });
    };
});