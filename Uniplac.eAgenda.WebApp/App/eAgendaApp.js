var eAgendaApp = angular.module('eAgendaApp', ['ui.router', 'ndd-ng-grid', 'dialogs.main', 'pascalprecht.translate', 'eAgenda-tasks-services', 'eAgenda-commitment-services', 'eAgenda-expenses-services', 'ui.calendar']);

eAgendaApp.config(function ($stateProvider, $urlRouterProvider, $translateProvider) {
    $stateProvider.state('home', {
        url: '/home',
        templateUrl: 'Home/HomeTemplate.html',
        controller: 'HomeController'
    });
    var tasksTState = {
        url: '/tasks',
        template: '<ui-view/>',
        controller: 'TasksController',
        abstract: true,
        redirectTo: 'tasks.main',
    };

    var commitmentsState = {
        url: '/commitments',
        template: '<ui-view/>',
        controller: 'CommitmentsController',
        abstract: true,
        redirectTo: 'expenses.main',
    };

    $stateProvider.state('commitments', commitmentsState);

    $stateProvider.state('commitments.main', {
        url: '/main',
        templateUrl: 'Commitments/CommitmentsTemplate.html',
        parent: commitmentsState
    });

    $stateProvider.state('commitments.add', {
        url: '/add',
        templateUrl: 'Commitments/CommitmentAddTemplate.html',
        parent: commitmentsState
    });

    $stateProvider.state('tasks', tasksTState);
    $stateProvider.state('tasks.main', {
        url: '/main',
        templateUrl: 'Tasks/TasksTemplate.html',
        parent: tasksTState
    });

    $stateProvider.state('tasks.add', {
        url: '/add',
        templateUrl: 'Tasks/TasksAddTemplate.html',
        parent: tasksTState
    });

    tasksTState.childsStates = ['tasks.main', 'tasks.add'];

    var expensesState = {
        url: '/expenses',
        template: '<ui-view/>',
        controller: 'expensesController',
        abstract: true,
        redirectTo: 'expenses.main',
    };
    $stateProvider.state('expenses', expensesState);

    $stateProvider.state('expenses.main', {
        url: '/main',
        templateUrl: 'Expenses/ExpenseTemplate.html',
        parent: expensesState
    });

    $stateProvider.state('expenses.add', {
        url: '/add',
        templateUrl: 'Expenses/ExpenseAddTemplate.html',
        parent: expensesState
    });

    $translateProvider.translations('pt-BR', {
        DIALOGS_YES: 'Sim',
        DIALOGS_NO: 'Não',
        DIALOGS_CLOSE: 'Fechar'
    }).use('pt-BR');

    $urlRouterProvider.when('/tasks', '/tasks/main');
    $urlRouterProvider.when('/commitments', '/commitments/main');

    $urlRouterProvider.otherwise('/home');
});

eAgendaApp.run(function ($rootScope, $state) {
    $rootScope.state = $state;

    $rootScope.$on('$stateChangeSuccess', function (event, toState, toParams, fromState, fromParams) {
        $state.previous = fromState;
    });

    $state.back = function () {
        $state.go(findState($state.previous, $state.$current.self));
    }

    $rootScope.todayMinFormat = function () { return moment().subtract('minutes', 1).format('YYYY-MM-DDTHH:mm'); }
});

function findState(previus, current) {
    if ((previus.parent == null || previus.parent == undefined) && previus.abstract && previus.childsStates)
        return previus.childsStates[0];

    if (previus.abstract && previus.parent)
        return findState(current.parent, current);

    return previus.abstract ? findState(current.parent, current) : previus;
}

eAgendaApp.controller('HomeController', function ($scope) {
});