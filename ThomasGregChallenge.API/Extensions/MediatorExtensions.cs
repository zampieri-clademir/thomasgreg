using MediatR;
using SimpleInjector;
using System.Diagnostics.CodeAnalysis;
using ThomasGregChallenge.API.Behaviours;

namespace ThomasGregChallenge.API.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class MediatorExtensions
    {
        public static void AddMediator(this IServiceCollection services, Container container)
        {
            container.RegisterSingleton<IMediator, Mediator>();
            container.Register(() => new ServiceFactory(container.GetInstance), Lifestyle.Singleton);

            RegisterAssembly(container, "ThomasGregChallenge.Application");

            container.Collection.Register(typeof(IPipelineBehavior<,>), new[]
            {
                typeof(ValidationPipeline<,>)
            });
        }

        private static void RegisterAssembly(Container container, string assemblyPath)
        {
            var assembly = AppDomain.CurrentDomain.Load(assemblyPath);

            container.Register(typeof(IRequestHandler<,>), assembly);
            container.Register(typeof(IRequestHandler<>), assembly);
        }
    }
}
