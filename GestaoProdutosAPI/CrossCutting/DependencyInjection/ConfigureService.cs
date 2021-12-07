using Domain.Interfaces.Service;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;

namespace Api.Crosscutting.DependencyInjection
{
    public class ConfigureService
	{
		public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
		{
			serviceCollection.AddTransient<IProdutoService, ProdutoService>();
			serviceCollection.AddTransient<IFornecedorService, FornecedorService>();
		}
	}
}
