using Domain.Dtos.Fornecedor;
using Domain.Entities;
using Domain.Entities.FornecedorEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Service
{
    public interface IFornecedorService
    {        
        Task<FornecedorDto> Get(int id);
        Task<List<FornecedorDto>> GetAll();
        Task<FornecedorDto> Put(FornecedorDto fornecedor);
        Task<FornecedorDto> Post(FornecedorDto fornecedor);
        Task<bool> Delete(int id);
    }
}
