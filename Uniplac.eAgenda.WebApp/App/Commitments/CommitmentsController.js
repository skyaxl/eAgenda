eAgendaApp.controller('CommitmentsController', function($scope, $compile, uiCalendarConfig, dialogs, $state, calendarConfig, CommitmentsService) {


    $scope.compromissoAtual = null;
    $scope.commitments = [];

    $scope.refresh = function()
    {
        CommitmentsService.getAll(function(commitments) {
            $scope.commitments.clear();
            commitments = commitments.map(function(value) { return new CompromissoViewModel(value); });
            $scope.commitments.pushArray(commitments);
        });
    };
    $scope.eventRender = function(event, element, view)
    {
        event = new CompromissoViewModel(event.model);
        element.attr({ 'tooltip': event.toString(), 'tooltip-append-to-body': true });

        if (view.name == "agendaDay" || view.name == 'agendaWeek')
        {
            $compile(element)($scope);
            return;
        }

        element.text(event.toString());
        $compile(element)($scope);
    };

    $scope.AddCompromisso = function()
    {
        $scope.compromissoAtual = new Compromisso(0, '', '', '', '', false);
        $scope.compromissoAtual = new CompromissoViewModel($scope.compromissoAtual);
        $state.go('commitments.add');
    };

    $scope.VerifyModel = function()
    {
        if (!$scope.compromissoAtual)
        {
            $scope.cancelEditOrUpdate();
        }
    };
    $scope.cancelEditOrUpdate = function()
    {
        $state.go('commitments.main');
    };

    $scope.EditaCompromisso = function()
    {
        $scope.compromissoAtual.start = $scope.compromissoAtual.start._isAMomentObject ? $scope.compromissoAtual.start.local().toDate() : $scope.compromissoAtual.start;
        $scope.compromissoAtual.end = !$scope.compromissoAtual.end ? null : ($scope.compromissoAtual.end._isAMomentObject ? $scope.compromissoAtual.end.local().toDate() : $scope.compromissoAtual.end);
        $state.go('commitments.add');
    };
    $scope.RemoverCompromisso = function()
    {
        $scope.tryGetCompromissoAtual();

        dialogs.confirm('Confirmação de Exclusão', 'Você deseja realmente excluir este compromisso?').result.then(function() {
            CommitmentsService.Delete($scope.compromissoAtual.model, function() {
                $scope.refresh();
            });
        });
    };
    $scope.tryGetCompromissoAtual = function()
    {
        try
        {
            if (!$scope.compromissoAtual)
            {
                throw Error('Selecione um compromisso');
            }
        } catch (e)
        {
            dialogs.error('Selecione um compromisso', e.message);
            throw e;
        }
    };
    $scope.saveCommitment = function()
    {
        $scope.tryGetCompromissoAtual();

        if (!$scope.compromissoAtual)
        {
            dialogs.error('Selecione um compromisso', 'Selecione um compromisso');
            return;
        }

        var saveDialog = dialogs.confirm("Confirmação de adição", String.format("Você deseja realmente {0} este item?", $scope.compromissoAtual.model.numero == 0 ? 'adicionar' : 'alterar'), { size: 'md' });
        saveDialog.result.then(function() {
            $scope.compromissoAtual.refreshModel();
            if ($scope.compromissoAtual.model.numero == 0)
            {
                CommitmentsService.Insert($scope.compromissoAtual.model, function() {
                    $state.go('commitments.main');
                    $scope.refresh();
                });
                return;
            }
            CommitmentsService.Update($scope.compromissoAtual.model, function() {
                $state.go('commitments.main');
            });
        }, function(btn) {
        });
    };

    $scope.clickEvent = function(event)
    {
        $scope.compromissoAtual = new CompromissoViewModel(new Compromisso());
        $scope.compromissoAtual.initializeByCalendar(event);
    };
    $scope.renderCalender = function(calendar)
    {
        if (uiCalendarConfig.calendars[calendar])
        {
            uiCalendarConfig.calendars[calendar].fullCalendar('render');
        }
    };

    $scope.onDrop = function(event, delta, revertFunc, jsevent)
    {
        var editDialog = dialogs.confirm("Confirmação de alteração", "Você deseja realmente alterar este item?", { size: 'md' });
        editDialog.result.then(function() {
            $scope.compromissoAtual = new CompromissoViewModel(new Compromisso());
            $scope.compromissoAtual.initializeByCalendar(event);
            $scope.compromissoAtual.refreshModel();
            CommitmentsService.Update($scope.compromissoAtual.model, function() {
                $scope.refresh();
            });
        }, function(btn) {
            if (btn == "no")
            {
                revertFunc();
            }
        });
    };

    $scope.eventSources = [];

    $scope.config = calendarConfig('commitments', $scope);
    $scope.refresh();
});