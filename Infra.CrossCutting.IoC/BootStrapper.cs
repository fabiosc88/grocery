using Application;
using Application.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Services;
using Infra.Data.Repositories;
using SimpleInjector;

namespace Infra.CrossCutting.IoC
{
    /// <summary>
    /// Inversion Control
    /// </summary>
    public static class BootStrapper
    {
        /// <summary>
        ///Register dependecies
        /// </summary>
        /// <param name="container">Container SimpleInjector</param>
        public static void Resolve(Container container)
        {
            //Lifestyle.Scoped = Instância única para o Request. A cada request, terá uma nova instância, ou seja, a instância irá existir durante todo o tempo do request.
            RegisterDependenceApplication(container);
            RegisterDependenceServiceDomain(container);
            RegisterDependenceRepository(container);
        }

        #region Metodos Privados

        /// <summary>
        /// Register Appalication dependencies
        /// </summary>
        /// <param name="container">Container do SimpleInjector</param>
        private static void RegisterDependenceApplication(Container container)
        {
            //Specifics classes
            container.Register<ICategoryAppService, CategoryAppService>(Lifestyle.Scoped);
            container.Register<IProductAppService, ProductAppService>(Lifestyle.Scoped);
        }

        /// <summary>
        /// Register Domain dependencies
        /// </summary>
        /// <param name="container">Container do SimpleInjector</param>
        private static void RegisterDependenceServiceDomain(Container container)
        {
            //Generic Class
            container.Register(typeof(IBaseService<>), typeof(BaseService<>), Lifestyle.Scoped);

            //Classes específicas
            container.Register<ICategoryService, CategoryService>(Lifestyle.Scoped);
            container.Register<IProductService, ProductService>(Lifestyle.Scoped);
        }

        /// <summary>
        /// Register Respository dependencies
        /// </summary>
        /// <param name="container">Container do SimpleInjector</param>
        private static void RegisterDependenceRepository(Container container)
        {
            //Classe genérica
            container.Register(typeof(IBaseRepository<>), typeof(BaseRepository<>), Lifestyle.Scoped);

            //Classes específicas
            container.Register<ICategoryRepository, CategoryRepository>(Lifestyle.Scoped);
            container.Register<IProductRepository, ProductRepository>(Lifestyle.Scoped);
        }

        #endregion Metodos Privados
    }
}
