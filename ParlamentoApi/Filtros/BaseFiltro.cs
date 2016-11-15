using System;
using System.Linq.Expressions;

namespace ParlamentoApi.Filtros
{
    public abstract class BaseFiltro<TEntidade>
    {
        public string ordenarPor { get; set; } = null;
        public int deslocamento { get; set; } = -1;
        public int limite { get; set; } = -1;

        public abstract Expression<Func<TEntidade, bool>> Condicoes();
    }
}