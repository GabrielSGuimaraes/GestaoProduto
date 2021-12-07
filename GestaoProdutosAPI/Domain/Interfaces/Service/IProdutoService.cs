using Domain.Dtos;
using Domain.Dtos.Produto;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Service
{
    public interface IProdutoService
    {
        Task<ProdutoResponseDto> Inactivate(int Id);
        Task<List<ProdutoResponseDto>> GetWithPaginate(ProdutoFilterRequestDto dto, int skip, int take);
        Task<ProdutoResponseDto> Get(int id);
        Task<List<ProdutoResponseDto>> GetAll();
        Task<ProdutoResponseDto> Put(ProdutoRequestDto produto);
        Task<ProdutoResponseDto> Post(ProdutoRequestDto produto);
        Task<bool> Delete(int id);
    }
}
