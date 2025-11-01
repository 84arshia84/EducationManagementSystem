using AppCore.UnitOfWork;
using ApplicationService.Services.User;
using Autofac;
using InfraStructure.Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Config
{
    public class AutofacModule:Module
    {
        private readonly string _connectionString;
        public AutofacModule(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void Load(ContainerBuilder builder)
        {
            // Register repositories
            builder.RegisterAssemblyTypes(typeof(UserRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .WithParameter("connectionString", _connectionString)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            // Register services
            builder.RegisterAssemblyTypes(typeof(UserService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            // Register the UnitOfWork
            builder.RegisterType<UnitOfWork.UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

        }
    }
}
