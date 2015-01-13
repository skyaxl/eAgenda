function Compromisso(numero, assunto, local, dataInicio, dataTermino, diaInteiro)
{
    this.numero = numero;
    this.assunto = assunto;
    this.local = local;
    this.dataInicio = dataInicio;
    this.dataTermino = diaInteiro ? null : dataTermino;
    this.diaInteiro = diaInteiro;

    this.initialize = function(base)
    {
        for (prop in base)
        {
            this[prop] = base[prop];
        }
    };
}

Compromisso.prototype.toString = function()
{
    return String.format("Nº: {0} - {1}", this.numero, this.assunto);
};

function CompromissoViewModel(compromisso)
{
    this.id = compromisso.numero;
    this.start = moment(compromisso.dataInicio).toDate();
    this.end = compromisso.dataTermino == null || !compromisso.dataTermino ? null : moment(compromisso.dataTermino).toDate();
    this.title = compromisso.assunto;
    this.allDay = compromisso.diaInteiro;
    this.place = compromisso.local;
    this.toString = function()
    {
        var dateFormat = 'DD/MM HH:mm';
        var endString = !this.end ? '' : ('Até ' + (this.end._isAMomentObject ? this.end.format(dateFormat) : moment(this.end).format(dateFormat)));

        return String.format('{0} {1} {2} local: {3}', this.title, (this.start._isAMomentObject ? this.start.local().format(dateFormat) : moment(this.start).local().format(dateFormat)), endString, this.place);
    };
    this.model = compromisso || new Compromisso();

    this.initializeByCalendar = function(baseEvent)
    {
        for (prop in baseEvent)
        {
            this[prop] = baseEvent[prop];
        }
    };
    this.refreshModel = function()
    {
        this.model.numero = this.id;
        this.model.assunto = this.title;
        this.model.local = this.place;
        if (this.end)
        {
            this.end = this.end._isAMomentObject ? this.end : moment(this.end);
            this.model.dataTermino = this.end.format();
        } else
        {
            this.model.dataTermino = null;
        }

        this.start = this.start._isAMomentObject ? this.start : moment(this.start);
        this.model.dataInicio = this.start.format();
        this.model.diaInteiro = this.allDay;
    };
}