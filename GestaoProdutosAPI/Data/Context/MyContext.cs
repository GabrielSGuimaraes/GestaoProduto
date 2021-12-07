using Data.Mapping;
using Domain.Entities;
using Domain.Entities.FornecedorEntity;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class MyContext : DbContext
	{
        #region "DbSets"
        
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Produto> Produto { get; set; }    

        #endregion

        public MyContext(DbContextOptions<MyContext> options) : base(options)
		{
			//Database.Migrate();
		}

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Fornecedor>(new FornecedorMap().Configure);
            modelBuilder.Entity<Produto>(new ProdutoMap().Configure);
            

        }
	}
}
