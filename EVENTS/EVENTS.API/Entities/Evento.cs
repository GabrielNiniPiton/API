namespace EVENTS.API.Entities
{
    public class Evento
    {
        public Evento(string? titulo, string? descricacao, DateTime dataInicio, DateTime dataFim, string? organizador)
        {
            Titulo = titulo;
            Descricacao = descricacao;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Organizador = organizador;

            DataCriacao = DateTime.Now;
        }

        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descricacao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string? Organizador { get; set; }
        public DateTime DataCriacao { get; set; }

        public void Update(string? titulo, string? descricacao, DateTime dataInicio, DateTime dataFim)
        {
            Titulo = titulo;
            Descricacao = descricacao;
            DataInicio = dataInicio;
            DataFim = dataFim;
        }
    }
}