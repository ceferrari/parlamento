namespace ParlamentoDominio.Entidades.Senado
{
    public class Votacao
    {
        public int CodigoSessao { get; set; }
        public int CodigoMateria { get; set; }
        public string Data { get; set; }
        public string HoraInicio { get; set; }
        public string IndicadorVotacaoSecreta { get; set; }
        public string DescricaoVotacao { get; set; }
        public string DescricaoResultado { get; set; }
        public string TotalVotosSim { get; set; }
        public string TotalVotosNao { get; set; }
        public string TotalVotosAbstencao { get; set; }
    }
}