using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.eAgenda.Dominio.CompromissoModule;

namespace Uniplac.eAgenda.Infraestrutura.Dao.CompromissoModule
{
    public class CompromissoDao : ICompromissoRepository
    {
        #region Queries Compromisso

        private const string SqlInsereCompromisso =
           @"INSERT INTO [TBCompromisso]
                (
                    [Assunto],       
                    [Local],             
                    [DataInicio],                    
                    [DataTermino],    
                    [DiaInteiro]                    
                )
            VALUES
                (
                    {0}Assunto,       
                    {0}Local,             
                    {0}DataInicio,                    
                    {0}DataTermino,    
                    {0}DiaInteiro
                )";

        private const string SqlAtualizaCompromisso =
            @" UPDATE [TBCompromisso]
                    SET 
                    [Assunto] = {0}Assunto,
                    [Local]=        {0}Local,
                    [DataInicio]=   {0}DataInicio,              
                    [DataTermino]=  {0}DataTermino,
                    [DiaInteiro] =   {0}DiaInteiro   

                    WHERE [Numero] = {0}Numero";

        private const string SqlExcluiCompromisso =
            @"DELETE FROM [TBCompromisso] 
                    WHERE [Numero] = {0}Numero";

        private const string SqlSelecionaTodosCompromissos =
            @"SELECT 
                    [Numero],
                    [Assunto],       
                    [Local],             
                    [DataInicio],                    
                    [DataTermino],    
                    [DiaInteiro]   
              FROM
                    [TBCompromisso]";     

        private const string SqlSelecionaCompromissoPorNumero =
           @"SELECT 
                    [Numero],
                    [Assunto],       
                    [Local],             
                    [DataInicio],                    
                    [DataTermino],    
                    [DiaInteiro]   
              FROM
                    [TBCompromisso]

             WHERE  [Numero] = {0}Numero";

        #endregion
        
        public Compromisso AdicionarCompromisso(Compromisso compromisso)
        {
            compromisso.Numero = Db.Insert(SqlInsereCompromisso, GetParametros(compromisso));

            return compromisso;
        }

        public void AtualizarCompromisso(Compromisso compromissoAtualizado)
        {
            Db.Update(SqlAtualizaCompromisso, GetParametros(compromissoAtualizado));
        }

        public void ExcluirCompromisso(Compromisso compromissoEncontrado)
        {
            Db.Delete(SqlExcluiCompromisso, GetParametros(compromissoEncontrado));
        }

        public Compromisso SelecionarCompromissoPorNumero(int numero)
        {
            return Db.Get(SqlSelecionaCompromissoPorNumero, Converter, new object[] { "Numero", numero });
        }

        public List<Compromisso> SelecionarTodosCompromissos()
        {
            return Db.GetAll(SqlSelecionaTodosCompromissos, Converter);
        }

        #region métodos privados
        private Compromisso Converter(IDataReader reader)
        {
            Compromisso compromisso = new Compromisso();
            compromisso.Numero = Convert.ToInt32(reader["Numero"]);
            compromisso.Assunto = Convert.ToString(reader["Assunto"]);
            compromisso.Local = Convert.ToString(reader["Local"]);
            compromisso.DataInicio = Convert.ToDateTime(reader["DataInicio"]);
            compromisso.DataTermino = reader["DataTermino"] as DateTime?;
            compromisso.DiaInteiro = Convert.ToBoolean(reader["DiaInteiro"]);

            return compromisso;
        }

        private object[] GetParametros(Compromisso compromisso)
        {
            return new Object[]
            {
                "Assunto", compromisso.Assunto, 
                "DataInicio", compromisso.DataInicio, 
                "DataTermino", compromisso.DataTermino, 
                "DiaInteiro", compromisso.DiaInteiro, 
                "Local", compromisso.Local,                 
                "Numero", compromisso.Numero
            };
        }

        #endregion
    }
}
