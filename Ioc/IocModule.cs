using ApiClient;
using Autofac;
using AutoMapper;
using Common.Cache;
using DataAccessLayer.AutoMapperConfig;
using DataAccessLayer.Repositories;
using DataAccessLayer.Uof;
using Microsoft.AspNetCore.Http;
using PointBet.Services.BaseServices;
using System.Net.Http;

namespace Ioc
{
    public class IocModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<AppDbContext>(); //For Unit Tests.
            builder.RegisterType<CacheManager>().As<ICacheManager>().InstancePerLifetimeScope();

            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).AsSelf().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).AsSelf().InstancePerLifetimeScope();

            builder.RegisterType(typeof(Mapper)).As(typeof(IMapper)).AsSelf().InstancePerLifetimeScope();
            builder.RegisterType(typeof(HttpContextAccessor)).As(typeof(IHttpContextAccessor)).AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<AutoMapperConfiguration>().As<IAutoMapperConfiguration>();

            builder.RegisterType<RestClientHelper>().As<IRestClientHelper>();

            builder.RegisterType(typeof(BaseFactory)).As(typeof(IBaseFactory)).AsSelf().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(BaseService<,>)).As(typeof(IBaseService<,>)).AsSelf().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(System.Reflection.Assembly.Load("PointBet.Services"))
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces()
               .InstancePerLifetimeScope();

            base.Load(builder);
        }

    }
}
