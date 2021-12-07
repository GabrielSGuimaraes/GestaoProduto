using Data.Context;
using Data.Implementations;
using Data.Repository;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Crosscutting.DependencyInjection
{
    public class ConfigureRepository {
        public static void ConfigureDependenciesRepository (IServiceCollection serviceCollection, IConfiguration configuration) {
            serviceCollection.AddScoped(typeof (IRepository<>), typeof (BaseRepository<>));
            serviceCollection.AddScoped<IProdutoRepository, ProdutoImplementation> ();
            serviceCollection.AddScoped<IFornecedorRepository, FornecedorImplementation>();

            //SQLSERVER
            serviceCollection.AddDbContext<MyContext>(
                 options => options.UseSqlServer(configuration.GetConnectionString("SQLConnection"))
            ); 
        }
    }
}
