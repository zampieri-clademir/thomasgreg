namespace ThomasGregChallenge.Domain.Entidades.Logradouro
{
    public class LogradouroVO
    {
        public int Id { get; set; }
        public long ClienteId { get; set; }
        public string Descricao { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Pais { get; set; }
        public string Complemento { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
