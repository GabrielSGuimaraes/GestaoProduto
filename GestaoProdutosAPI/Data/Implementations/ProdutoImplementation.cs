using Data.Context;
using Data.Repository;
using Domain.Dtos;
using Domain.Dtos.Produto;
using Domain.Entities;
using Domain.Interfaces.Repository;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class ProdutoImplementation : BaseRepository<Produto>, IProdutoRepository
    {
        private DbSet<Produto> _dataset;
        

        public ProdutoImplementation(MyContext context) : base(context)
        {
            //_context = context;
            _dataset = context.Set<Produto>();
            
        }

        public async Task<List<Produto>> SelectAllAsync()
        {
            var query = _dataset.Include(f => f.Fornecedor);
            return await query.ToListAsync();
        }

        public async Task<Produto> SelectAsyncById(int id)
        {
            var result = await _dataset.Include(f => f.Fornecedor).FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        

        public async Task<List<Produto>> SelectWithPaginate(ProdutoFilterRequestDto dto, int skip, int take)
        {           

            var query =  _dataset.Include(f => f.Fornecedor).AsQueryable();

            if (dto.Descricao != null)
                query = query.Where(x => x.Descricao.Contains(dto.Descricao));

            if (dto.Id > 0)
                query = query.Where(x => x.Id.Equals(dto.Id));

            if (dto.FornecedorId > 0)
                query = query.Where(x => x.FornecedorId.Equals(dto.FornecedorId));

            query = query.Where(x => x.Situacao == dto.Situacao);
            

            return await query.AsNoTracking().OrderBy(p=> p.Id).Skip(skip).Take(take).ToListAsync();
        }
    }
}
