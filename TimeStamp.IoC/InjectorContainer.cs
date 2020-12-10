using Microsoft.Extensions.DependencyInjection;
using TimeStamp.Application.Apps;
using TimeStamp.Application.Interfaces;
using TimeStamp.Infrastructure.Data.Interfaces.ServicesExternal;
using TimeStamp.Infrastructure.Data.Repositories.ServicesExternal;

namespace TimeStamp.IoC
{
    public class InjectorContainer
    {
        public IServiceCollection GetScope(IServiceCollection interfaceService)
        {
            #region Apps

            interfaceService.AddScoped(typeof(IAuthenticationApp), typeof(AuthenticationApp));
            interfaceService.AddScoped(typeof(IHackerNewsApp), typeof(HackerNewsApp));

            #endregion

            #region Data / Repositories

            interfaceService.AddScoped(typeof(IHackerNewsRepository), typeof(HackerNewsRepository));

            #endregion

            return interfaceService;
        }
    }
}
