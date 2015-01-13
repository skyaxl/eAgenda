function Map() {
    this.propertyName = null;
    this.otherMaps = new Array();
    this.innerPropertyName = null;
    this.isInnerProperty = false;
    this.subLine = false;
    this.editable = false;
    this.sortable = false;
    this.displayHeadertext = this.propertyName;
    this.innerPropertyDisplayHeaderText = null;
    this.hidden = false;
    this.reverse = false;
}

Map.prototype.customFormatColumn = function (value) {
    if (value === undefined || value === null) {
        return '';
    }

    return value.toString();
};

Map.prototype.getInnerPropertyDisplayHeadertext = function (map) {
    return map.innerPropertyDisplayHeaderText == null ? map.innerPropertyName : map.innerPropertyDisplayHeaderText;
};

Map.prototype.getDisplayHeaderText = function (map) {
    return map.displayHeadertext == null ? map.propertyName : map.displayHeadertext;
};

function Grid() {
    this.maps = new Array();
    this.groupable = true;
    this.hasSubLines = true;
    this.activeRowIndex = -1;
    this.activeRowObject = null;
    this.orderBy = this.maps[0] == undefined ? null : this.maps[0].propertyName;
    this.reverse = false;
    this.usePagination = false;
    this.useGlobalSearch = false;
    this.itensPerPage = 20;
}

Grid.prototype.setActiveRow = function (index, dataSource, event, callback) {
    this.activeRowIndex = index;
    this.activeRowObject = dataSource[index];
    $('#grid tr').removeClass('selected');
    $(event.currentTarget).addClass('selected');
    if (callback) {
        callback(this.activeRowObject);
    }
};

angular.module("ndd-ng-grid", ['ui.bootstrap', 'ngSanitize']).directive('nddGrid', function () {

    var result = {
        templateUrl: '../Scripts/templates/grid.html',
        scope: { dataSource: "=datasource", datasourceMap: '=options', refreshFunction: "=refresh", externPageChange: "=changepage", selectionChange: '=onselect', ongridload: "=", beforecollapse: "=" },
        controller: function ($scope) {
            $scope.currentPage = 1;
            $scope.totalPages = 1;
            $scope.globalSearch = '';

            if ($scope.ongridload) {
                $scope.ongridload($scope.dataSource);
            }

            $scope.pageChanged = function () {
                if ($scope.externPageChange !== undefined && angular.isFunction($scope.externPageChange)) {
                    $scope.externPageChange($scope.currentPage, $scope.dataSource.length, $scope.datasourceMap.itensPerPage);
                }
            };
            $scope.paginationFilter = function (ele) {
                var index = $scope.dataSource.indexOf(ele) + 1;

                if (!$scope.datasourceMap.usePagination) {
                    return true;
                }

                var firstCondition = (index <= $scope.currentPage * $scope.datasourceMap.itensPerPage && index > ($scope.currentPage - 1) * $scope.datasourceMap.itensPerPage);
                return firstCondition;
            };
            $scope.collapse = function (event, data)
            {
                var ele = angular.element(event.currentTarget);
                var collaped = ele.hasClass('collapsed');
                !collaped ? ele.addClass('collapsed') : ele.removeClass('collapsed');
                if ($scope.beforecollapse && !collaped)
                    $scope.beforecollapse(data);

                return false;
            };
        },

    };

    return result;

}).filter('to_trusted', function ($sce) {
    return function (text) {
        return $sce.trustAsHtml(text);
    };
});

angular.firstOrDefault = function (array, func) {
    if (!angular.isArray(array)) {
        throw new Error('This object parset to first or default not is an array');
    }

    for (var i = 0; i < array.length; i++) {
        if (func(array[i]) == true) {
            return array[i];
        }
    }
    return null;
};