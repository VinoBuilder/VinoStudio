using Microsoft.Extensions.DependencyInjection;
using VinoGameClient.Base;
using VinoStudioApp.Services;
using VinoStudioCore.Stores;

namespace VinoGameClient
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCommonServices(this IServiceCollection collection)
        {
            collection
                .AddSingleton<TakesStore>()
                .AddSingleton<TimelineStore>()
                .AddSingleton<TakeService>()
                .AddSingleton<TimelineService>()
                .AddTransient<MainWindowViewModel>();
        }
    }
}
