using AutoMapper;
using Domain.Dtos;
using Domain.Dtos.Produto;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ProdutoService : IProdutoService
    {

        private readonly IProdutoRepository _repository;
        private readonly IFornecedorRepository _repositoryFornecedor;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository repository, IFornecedorRepository repositoryFornecedor, IMapper mapper)
        {
            _repository = repository;
            _repositoryFornecedor = repositoryFornecedor;
            _mapper = mapper;
        }
        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<ProdutoResponseDto> Get(int id)
        {
            var produto = await _repository.SelectAsyncById(id);
            var produtoDto = _mapper.Map<ProdutoResponseDto>(produto);
            return produtoDto;
        }

        public async Task<List<ProdutoResponseDto>> GetAll()
        {
            var listproduto = await _repository.SelectAllAsync();
            var listProdutoDto = _mapper.Map<List<ProdutoResponseDto>>(listproduto);
            return listProdutoDto;
        }

        public async Task<List<ProdutoResponseDto>> GetWithPaginate(ProdutoFilterRequestDto dto, int skip, int take)
        {
            var listproduto = await _repository.SelectWithPaginate(dto,skip,take);
            var listProdutoDto = _mapper.Map<List<ProdutoResponseDto>>(listproduto);
            return listProdutoDto;
        }

        public async Task<ProdutoResponseDto> Inactivate(int Id)
        {
            var produto = await _repository.SelectAsync(Id);

            produto.SetSituacao(false);

            var response = await _repository.UpdateAsync(produto);
            return _mapper.Map<ProdutoResponseDto>(response); 
        }

        public async Task<ProdutoResponseDto> Post(ProdutoRequestDto dto)
        {
            try
            {                
                var produto = Produto.Create(dto);
                var response = await _repository.InsertAsync(produto);
                return _mapper.Map<ProdutoResponseDto>(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<ProdutoResponseDto> Put(ProdutoRequestDto dto)
        {
            try
            {
                var produto = await _repository.SelectAsync(dto.Id);
                produto.SetDescricao(dto.Descricao);
                produto.SetDataFabricacao(dto.DataFabricacao);
                produto.SetDataValidade(dto.DataValidade);
                produto.SetFornecedor(dto.FornecedorId);

                var response = await _repository.UpdateAsync(produto);
                return _mapper.Map<ProdutoResponseDto>(response);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
