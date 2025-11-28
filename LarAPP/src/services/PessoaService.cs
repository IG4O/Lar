using AutoMapper;
using LarAPP.src.DTOs.PessoaDTO;
using LarAPP.src.Entities;
using LarAPP.src.Repositories;

namespace LarAPP.src.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IRepository<Pessoa> _repo;
        private readonly IMapper _mapper;


        public PessoaService(IRepository<Pessoa> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<IEnumerable<PessoaDTO>> GetAll() => _mapper.Map<IEnumerable<PessoaDTO>>(await _repo.GetAll());
        public async Task<PessoaDTO> GetById(int id) => _mapper.Map<PessoaDTO>(await _repo.GetById(id));
        public async Task<PessoaDTO> Create(CreatePessoaDTO dto)
        {
            var entity = _mapper.Map<Pessoa>(dto);
            var created = await _repo.Create(entity);
            return _mapper.Map<PessoaDTO>(created);
        }
        public async Task Update(int id, UpdatePessoaDTO dto)
        {
            if (id != dto.Id) throw new ArgumentException("Id mismatch");
            var entity = _mapper.Map<Pessoa>(dto);
            await _repo.Update(entity);
        }
        public async Task Delete(int id) => await _repo.Delete(id);
    }
}
