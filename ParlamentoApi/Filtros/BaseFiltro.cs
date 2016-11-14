using System;
using System.Linq;
using System.Linq.Expressions;

namespace ParlamentoApi.Filtros
{
    public abstract class BaseFiltro<TEntidade>
    {
        public string ordenarPor { get; set; } = null;
        public string ordem { get; set; } = "asc";
        public int deslocamento { get; set; } = -1;
        public int limite { get; set; } = -1;

        public abstract Expression<Func<TEntidade, bool>> Condicoes();
        //public abstract Expression<Func<TEntidade, string>> OrdenacaoString();
        //public abstract Expression<Func<TEntidade, int>> OrdenacaoInt();
        //public abstract Expression<Func<TEntidade, long>> OrdenacaoLong();
        //public abstract Expression<Func<TEntidade, DateTime>> OrdenacaoDateTime();

        public Expression<Func<TEntidade, dynamic>> Ordenacao<dynamic>()
        {
            if (ordenarPor == null)
            {
                return null;
            }

            //var param = Expression.Parameter(typeof(Senador));
            //return Expression.Lambda<Func<Senador, TChave>>(Expression.Convert(Expression.Property(param, ordenarPor), typeof(object)), param);

            var paramExp = Expression.Parameter(typeof(TEntidade));
            var propExp = Expression.PropertyOrField(paramExp, ordenarPor);
            var convertedExp = Expression.Convert(propExp, propExp.Type);
            var keySelectorExp = Expression.Lambda<Func<TEntidade, dynamic>>(convertedExp, paramExp);

            return keySelectorExp;
        }
    }
}