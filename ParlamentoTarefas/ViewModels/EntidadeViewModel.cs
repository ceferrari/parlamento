using System;

namespace ParlamentoTarefas.ViewModels
{
    public class EntidadeViewModel
    {
        public int Codigo1 { get; set; }
        public int Codigo2 { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
    }
}
