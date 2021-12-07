using AutoMapper;
using Domain.Dtos.Fornecedor;
using Domain.Entities;
using Domain.Entities.FornecedorEntity;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class FornecedorService : IFornecedorService
    {

        private readonly IFornecedorRepository _repository;
        private readonly IMapper _mapper;

        public FornecedorService(IFornecedorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<FornecedorDto> Get(int id)
        {
            var fornecedor = await _repository.SelectAsync(id);
            var fornecedorDto = _mapper.Map<FornecedorDto>(fornecedor);
            return fornecedorDto;
        }

        public async Task<List<FornecedorDto>> GetAll()
        {
            var listfornecedor = await _repository.SelectAsync();
            var listFornecedorDto = _mapper.Map<List<FornecedorDto>>(listfornecedor);
            return listFornecedorDto;
        }

        public async Task<FornecedorDto> Post(FornecedorDto dto)
        {
            var fornecedor = Fornecedor.Create(dto);
            var response = await _repository.InsertAsync(fornecedor);
            return _mapper.Map<FornecedorDto>(response);
        }

        public async Task<FornecedorDto> Put(FornecedorDto dto)
        {
            var fornecedor = await _repository.SelectAsync(dto.Id);
            fornecedor.SetDescricao(dto.Descricao);
            fornecedor.SetCNPJ(dto.CNPJ);           

            var response = await _repository.UpdateAsync(fornecedor);
            return _mapper.Map<FornecedorDto>(response);
        }
    }
}
