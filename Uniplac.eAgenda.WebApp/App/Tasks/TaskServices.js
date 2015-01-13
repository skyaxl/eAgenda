var tasksServicesModule = angular.module('eAgenda-tasks-services', ['ngResource']);
tasksServicesModule.factory('TasksRestFull', function ($resource) {
    return $resource('/eAgenda/api/tasks/:id', {}, {
        update: {
            method: 'PUT'
        }
    });
}).factory('TasksService', function (TasksRestFull,dialogs) {
    var temporaryTasks = [];
    return {
        getAll: function (fn) {
            TasksRestFull.query(function (result) {
                temporaryTasks = result.map(function (value) {
                    var tarefa = new Tarefa(value.numero, value.prioridade, value.titulo, value.dataConclusao, [], value.percentual);
                    if (value.itensExecucacao)
                        angular.forEach(value.itensExecucacao, function (item) {
                            var itemTarefa = new ItemTarefa(item.numero, item.titulo, item.percentual);
                            tarefa.adicionarItemExecucao(itemTarefa);
                        });

                    return tarefa;
                });

                fn(temporaryTasks);
            }, function (resultError) {
                dialogs.error('Erro na busca das tarefas', resultError.data.exceptionMessage || resultError.data.message);
            });
        },
        getById: function (id, fn) {
            var tarefa;
            TasksRestFull.get({ id: id }, function (value) {
                tarefa = new Tarefa(value.numero, value.prioridade, value.titulo, value.dataConclusao, [], value.percentual);
                if (value.itensExecucacao)
                    angular.forEach(value.itensExecucacao, function (item) {
                        var itemTarefa = new ItemTarefa(item.numero, item.titulo, item.percentual);
                        tarefa.adicionarItemExecucao(itemTarefa);
                    });
                if (fn) fn(tarefa);
            }, function (resultError) {
                dialogs.error('Erro ao buscar tarefa.', resultError.data.exceptionMessage || resultError.data.message);
            });
        },
        Delete: function (task, fn)
        {
            TasksRestFull.delete({ id: task.numero }, function () { if (fn) fn(); }, function (resultError) {
                dialogs.error('Erro na exclusão da tarefa', resultError.data.exceptionMessage || resultError.data.message);
            });
        },
        Insert: function (task, fn) {
            TasksRestFull.save(task, function () { if (fn) fn(); }, function (resultError) {
                dialogs.error('Erro na inserção da tarefa', resultError.data.exceptionMessage || resultError.data.message);
            });
        },
        Update: function (task, fn) {
            TasksRestFull.update({ id: task.numero }, task, function () { if (fn) fn(); }, function (resultError) {
                dialogs.error('Erro na atualização da tarefa', resultError.data.exceptionMessage || resultError.data.message);
            });
        }
    }
});