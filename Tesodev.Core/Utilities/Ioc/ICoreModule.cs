using Microsoft.Extensions.DependencyInjection;

namespace Tesodev.Core.Utilities.Ioc
{
    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}
