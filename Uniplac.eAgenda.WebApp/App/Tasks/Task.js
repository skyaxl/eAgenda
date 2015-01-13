function Tarefa(numero, prioridade, titulo, dataConclusao, itensExecucacao, percentual) {
    this.numero = numero;
    this.prioridade = prioridade;
    this.titulo = titulo;
    this.dataConclusao = dataConclusao;
    this.itensExecucacao = itensExecucacao ? itensExecucacao : [];
    this.percentual = percentual;
    var self = this;

    this.adicionarItemExecucao = function (item) {
        self.itensExecucacao.push(item);
        self.cauculaPercentual();
    }
    this.removeItemExecucao = function (item) {
        self.itensExecucacao.splice(self.itensExecucacao.indexOf(item), 1);
        self.cauculaPercentual();
    }

    this.cauculaPercentual = function () {
        var percentualCalculado = 0;
        var percentualTotal = 100 * self.itensExecucacao.length;

        for (var i = 0; i < self.itensExecucacao.length; i++)
        {
            var item = self.itensExecucacao[i];
            percentualCalculado += item.percentual;
        }

        percentualCalculado = percentualCalculado * 100 / percentualTotal;
        self.percentual = percentualCalculado;
    }
}

function ItemTarefa(numero, titulo, percentual) {
    this.numero = numero;
    this.titulo = titulo;
    this.percentual = percentual;
    var self = this;

    this.EstaFechada = function () { return self.percentual == 100; }
}

ItemTarefa.prototype.toString = function()
{
    return String.format('Numero: {0}, Titulo: {1}, Percentual: {2}', this.numero, this.titulo, this.percentual);
}