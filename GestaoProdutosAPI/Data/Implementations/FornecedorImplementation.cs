using Data.Context;
using Data.Repository;
using Domain.Entities.FornecedorEntity;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Implementations
{
    public class FornecedorImplementation : BaseRepository<Fornecedor>, IFornecedorRepository
    {
        private DbSet<Fornecedor> _dataset;

        public FornecedorImplementation(MyContext context) : base(context)
        {
            //_context = context;
            _dataset = context.Set<Fornecedor>();

        }
    }
}
