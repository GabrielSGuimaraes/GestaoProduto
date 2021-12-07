using Domain.Dtos;
using Domain.Dtos.Produto;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        //Task<bool> Inactivate(int Id);
        Task<List<Produto>> SelectWithPaginate(ProdutoFilterRequestDto dto, int skip, int take);
        Task<List<Produto>> SelectAllAsync();
        Task<Produto> SelectAsyncById(int id);
    }
}
