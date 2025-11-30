using LarAPP.src.DTOs.TelefoneDTO;

namespace LarAPP.src.DTOs.PessoaDTO
{

    public record CreatePessoaDTO(
    string Nome,
    string CPF,    
    DateTime? DataNascimento,
    bool Ativo = true,
    IList<CreateTelefoneDTO>? Telefones = null
);

    public record PessoaDTO(
        int Id,
        string Nome,
        string CPF,        
        DateTime? DataNascimento,
        bool Ativo,
        IEnumerable<TelefoneDTO.TelefoneDTO> Telefones
    );

    public record UpdatePessoaDTO(
        int Id,
        string Nome,
        string CPF,        
        DateTime? DataNascimento,
        bool Ativo
    );

}
