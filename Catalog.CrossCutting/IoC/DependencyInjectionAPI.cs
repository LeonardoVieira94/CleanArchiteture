using Catalog.Application.Interfaces;
using Catalog.Application.Mappings;
using Catalog.Application.Services;
using Catalog.Domain.Interfaces;
using Catalog.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.CrossCutting.IoC;

public static class DependencyInjectionAPI
{
    public static IServiceCollection AddCatalogDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        // Registros de Serviços
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped(typeof(IService<>), typeof(Service<>));

        // Registro do UnitOfWork e do Repositório Genérico
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        // Outros serviços compartilhados, como AutoMapper, configuração de contexto do EF, etc.
        services.AddAutoMapper(typeof(DomainToDTOMappingProfile)); // Exemplo de Profile de AutoMapper

        return services;
    }
}
