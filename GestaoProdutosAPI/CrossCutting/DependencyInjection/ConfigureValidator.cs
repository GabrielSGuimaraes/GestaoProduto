using GestaoProdutos.Validators;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureValidator
    {
        public static void ConfigureDependencies(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<FornecedorValidator>();
            serviceCollection.AddScoped<ProdutoValidator>();

        }
    }
}
