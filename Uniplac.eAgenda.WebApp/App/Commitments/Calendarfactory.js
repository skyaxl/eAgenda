eAgendaApp.factory('calendarConfig', function () {
    return function (eventos, $scope) {
        return {
            calendar: {
                height: 600,
                header: {
                    left: 'prev,next today',
                    center: 'title',
                    right: 'month,agendaWeek,agendaDay'
                },
                editable: true,
                lang: 'pt-br',
                defaultView: 'agendaWeek',
                eventRender: $scope.eventRender,
                events: $scope[eventos],
                eventDrop: $scope.onDrop,
                eventResize: $scope.onDrop,
                eventClick: $scope.clickEvent,
            }
        }
    }
});