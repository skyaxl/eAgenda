function Despesa(numero, descricao, categoria, data, valor, formaPagamento) {
    this.numero = numero;
    this.descricao = descricao;
    this.categoria = categoria;
    this.data = moment(data).toDate();
    this.valor = valor;
    this.formaPagamento = formaPagamento;
};

var expensesgrid = function () {
    var grid = new Grid();
    grid.useGlobalSearch = true;
    grid.usePagination = true;
    grid.itensPerPage = 20;
    grid.hasSubLines = false;
    var mapNumero = new Map();
    mapNumero.propertyName = 'numero';
    mapNumero.hidden = true;

    var mapTitulo = new Map();
    mapTitulo.propertyName = 'descricao';
    mapTitulo.displayHeadertext = 'Descrição';

    var mapData = new Map();
    mapData.propertyName = 'data';
    mapData.displayHeadertext = 'Data de Pagamento';
    mapData.customFormatColumn = function (value) {
        return moment(value).format('DD/MM/YYYY');
    }

    var mapCategoria = new Map();
    mapCategoria.propertyName = 'categoria';
    mapCategoria.displayHeadertext = 'Categoria';

    var mapValor = new Map();
    mapValor.propertyName = 'valor';
    mapValor.displayHeadertext = 'Valor';

    var mapFormaPag = new Map();
    mapFormaPag.propertyName = 'formaPagamento';
    mapFormaPag.displayHeadertext = 'Forma de Pagamento';

    grid.maps.push(mapNumero, mapTitulo, mapCategoria, mapData,mapValor, mapFormaPag);

    return grid;
}();