using LarAPP.src.Entities;

namespace LarAPP.src.Entities
{
    public enum TipoTelefone { Celular, Residencial, Comercial }

    public class Telefone
    {
        public int Id { get; set; }
        public TipoTelefone Tipo { get; set; }
        public string Numero { get; set; }

        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}
