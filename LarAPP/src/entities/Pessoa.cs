using LarAPP.src.Entities;

namespace LarAPP.src.Entities
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }        
        public DateTime? DataNascimento { get; set; }
        public bool Ativo { get; set; } = true;


        public required IList<Telefone> Telefones { get; set; }
    }
}
