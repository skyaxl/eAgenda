var tasksgrid = function () {
    var grid = new Grid();
    grid.useGlobalSearch = true;
    grid.usePagination = true;
    grid.itensPerPage = 20;

    var mapNumero = new Map();
    mapNumero.propertyName = 'numero';
    mapNumero.hidden = true;

    var mapTitulo = new Map();
    mapTitulo.propertyName = 'titulo';
    mapTitulo.displayHeadertext = 'Título';

    var mapData = new Map();
    mapData.propertyName = 'dataConclusao';
    mapData.displayHeadertext = 'Data de Conclusão';
    mapData.customFormatColumn = function(value)
    {
        return moment(value).format('DD/MM/YYYY');
    }

    var mapPercentual = new Map();
    mapPercentual.propertyName = 'percentual';
    mapPercentual.displayHeadertext = 'Percentual Concluído';
    mapPercentual.customFormatColumn = function (value) {
        return String.format('<div class="progress"><div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="{0}" aria-valuemin="0" aria-valuemax="100"  style="width: {0}%;">{0}%</div></div>', value);
    }

    var mapPrioridade = new Map();
    mapPrioridade.propertyName = 'prioridade';
    mapPrioridade.displayHeadertext = 'Prioridade';

    var mapItens = new Map();
    mapItens.subLine = true;
    mapItens.propertyName = "itensExecucacao";
    mapItens.displayHeadertext = 'Itens';
    var mapItemTitulo = new Map();
    mapItemTitulo.propertyName = 'titulo';
    mapItemTitulo.displayHeadertext = 'Título';
    var mapItemNumero = new Map();
    mapItemNumero.propertyName = 'numero';
    mapItemNumero.hidden = true;

    var mapItemPercentual = new Map();
    mapItemPercentual.propertyName = 'percentual';
    mapItemPercentual.displayHeadertext = 'Percentual';
    mapItemPercentual.customFormatColumn = mapPercentual.customFormatColumn;
    mapItens.otherMaps.push(mapItemNumero, mapItemTitulo, mapItemPercentual);

    grid.maps.push(mapNumero, mapTitulo, mapPrioridade, mapData, mapPercentual, mapItens);

    return grid;
}();

var itensTasksGrid = function()
{
    var grid = new Grid();
    grid.useGlobalSearch = false;
    grid.usePagination = true;
    grid.itensPerPage = 5;
    grid.hasSubLines = false;
    var mapNumero = new Map();
    mapNumero.propertyName = 'numero';
    mapNumero.hidden = true;

    var mapTitulo = new Map();
    mapTitulo.propertyName = 'titulo';
    mapTitulo.displayHeadertext = 'Título';

    var mapItemTitulo = new Map();
    mapItemTitulo.propertyName = 'titulo';
    mapItemTitulo.displayHeadertext = 'Título';
    var mapItemNumero = new Map();
    mapItemNumero.propertyName = 'numero';
    mapItemNumero.hidden = true;

    var mapItemPercentual = new Map();
    mapItemPercentual.propertyName = 'percentual';
    mapItemPercentual.displayHeadertext = 'Percentual';
    mapItemPercentual.customFormatColumn = function (value) {
        return String.format('<div class="progress"><div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="{0}" aria-valuemin="0" aria-valuemax="100"  style="width: {0}%;">{0}%</div></div>', value);
    }
    grid.maps.push(mapItemNumero, mapItemTitulo, mapItemPercentual);

    return grid;
}();