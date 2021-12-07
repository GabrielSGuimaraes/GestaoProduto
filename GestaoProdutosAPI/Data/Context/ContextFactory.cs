using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            //Criar Migrações
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();            

            return new MyContext(optionsBuilder.Options);
            
        }
    }
}
