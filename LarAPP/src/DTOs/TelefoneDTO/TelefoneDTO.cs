using LarAPP.src.Entities;

namespace LarAPP.src.DTOs.TelefoneDTO
{
    public record CreateTelefoneDTO(
        string Numero,
        TipoTelefone Tipo
    );

    public record TelefoneDTO(
        int Id,
        string Numero,
        TipoTelefone Tipo
    );
    //public record UpdateTelefoneDTO(int Id, int PessoaId, string Numero, string Tipo);
}
