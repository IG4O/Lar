using LarAPP.src.DTOs.TelefoneDTO;

namespace LarAPP.src.DTOs.PessoaDTO
{

    public record PessoaDTO(int Id, string Nome, string CPF, DateTime? DataNascimento, bool Ativo, IEnumerable<CreateTelefoneDTO> Telefones);
    public record CreatePessoaDTO(string Nome, string CPF, DateTime? DataNascimento, bool Ativo = true);
    public record UpdatePessoaDTO(int Id, string Nome, string CPF, DateTime? DataNascimento, bool Ativo);
}
