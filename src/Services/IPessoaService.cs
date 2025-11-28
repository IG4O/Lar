using ProjetoLar.src.DTOs.PessoaDTO;

namespace ProjetoLar.src.Services
{
    public interface IPessoaService
    {
        Task<IEnumerable<PessoaDTO>> GetAll();
        Task<PessoaDTO> GetById(int id);
        Task<PessoaDTO> Create(CreatePessoaDTO dto);
        Task Update(int id, UpdatePessoaDTO dto);
        Task Delete(int id);
    }
}
