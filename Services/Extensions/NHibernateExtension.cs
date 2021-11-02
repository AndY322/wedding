using System;
using System.Linq;
using DomainModel.Mappings;
using FluentNHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Mapping.Providers;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Services.Repository;
using Services.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Services.Extensions
{
    public static class NHibernateExtension
    {
        public static IServiceCollection AddNHibernate(this IServiceCollection services, string connectionString)
        {
            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString).ShowSql())
                .Mappings(m =>m.FluentMappings.AddFromAssemblyOf<UserMap>(t => t.Namespace.StartsWith("DomainModel.Mappings"))) 
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true)) 
                .BuildSessionFactory(); 
 
            services.AddSingleton(sessionFactory);
            services.AddScoped(factory => sessionFactory.OpenSession());
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISurveyService, SurveyService>();
            services.AddScoped<IAlcoholService, AlcoholService>();
            services.AddScoped<IOvernightStayLookupService, OvernightStayLookupService>();

            return services;
        }
        
        public static FluentMappingsContainer AddFromAssemblyOf<T>(
            this FluentMappingsContainer mappings,
            Predicate<Type> where)
        {
            if (where == null)
                return mappings.AddFromAssemblyOf<T>();

            var mappingClasses = typeof(T).Assembly.GetExportedTypes()
                .Where(x => (typeof(IMappingProvider).IsAssignableFrom(x)
                             || typeof(IExternalComponentMappingProvider).IsAssignableFrom(x))
                            && where(x));

            foreach (var type in mappingClasses)
            {
                mappings.Add(type);
            }

            return mappings;
        }
    }
}