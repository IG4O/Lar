using LarAPP.src.DTOs.PessoaDTO;
using LarAPP.src.DTOs.TelefoneDTO;
using LarAPP.src.Entities;
using LarAPP.src.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LarAPP.src.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IRepository<Pessoa> _repository;

        public PessoaService(IRepository<Pessoa> repository)
        {
            _repository = repository;
        }
        
        public async Task<IEnumerable<PessoaDTO>> GetAll()
        {
            var pessoas = await _repository.GetAll();

            return pessoas.Select(p => new PessoaDTO(
                Id: p.Id,
                Nome: p.Nome,
                CPF: p.CPF,                
                DataNascimento: p.DataNascimento,
                Ativo: p.Ativo,
                Telefones: p.Telefones.Select(t => new TelefoneDTO(t.Id, t.Numero, t.Tipo)).ToList()
            ));
        }
      
        public async Task<PessoaDTO> GetById(int id)
        {
            var pessoa = await _repository.GetById(id);
            if (pessoa == null)
                return null;

            return new PessoaDTO(
                Id: pessoa.Id,
                Nome: pessoa.Nome,
                CPF: pessoa.CPF,                
                DataNascimento: pessoa.DataNascimento,
                Ativo: pessoa.Ativo,
                Telefones: pessoa.Telefones.Select(t => new TelefoneDTO(t.Id, t.Numero, t.Tipo)).ToList()
            );
        }
      
        public async Task<PessoaDTO> Create(CreatePessoaDTO dto)
        {
            var pessoaEntity = new Pessoa
            {
                Nome = dto.Nome,
                CPF = dto.CPF,                
                DataNascimento = dto.DataNascimento,
                Ativo = dto.Ativo,
                Telefones = dto.Telefones?.Select(t => new Telefone
                {
                    Numero = t.Numero,
                    Tipo = t.Tipo,
                }).ToList()
            };

            await _repository.Add(pessoaEntity.Id);

            return new PessoaDTO(
                Id: pessoaEntity.Id,
                Nome: pessoaEntity.Nome,
                CPF: pessoaEntity.CPF,                
                DataNascimento: pessoaEntity.DataNascimento,
                Ativo: pessoaEntity.Ativo,
                Telefones: pessoaEntity.Telefones.Select(t => new TelefoneDTO(t.Id, t.Numero, t.Tipo)).ToList()
            );
        }

        
        public async Task Update(int id, UpdatePessoaDTO dto)
        {
            var pessoa = await _repository.GetById(id);
            if (pessoa == null)
                throw new Exception("Pessoa não encontrada.");

            pessoa.Nome = dto.Nome;
            pessoa.CPF = dto.CPF;            
            pessoa.DataNascimento = dto.DataNascimento;
            pessoa.Ativo = dto.Ativo;

            await _repository.Update(pessoa);
        }

        
        public async Task Delete(int id)
        {
            var pessoa = await _repository.GetById(id);
            if (pessoa == null)
                throw new Exception("Pessoa não encontrada.");

            await _repository.Delete(pessoa.Id);
        }
    }
}
