namespace LarAPP.src.DTOs.TelefoneDTO
{
    public record TelefoneDTO(int Id, string Numero, string Tipo);
    public record CreateTelefoneDTO(int PessoaId, string Numero, string Tipo);
    public record UpdateTelefoneDTO(int Id, int PessoaId, string Numero, string Tipo);
}
