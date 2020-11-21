using Blazorise;
using Blazorise.Bootstrap;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using System.Threading;
using System.Threading.Tasks;

namespace TodoApp.Tests.bUnit
{
    public static class TestServiceProviderExtensions
    {
        public static void AddBlazoriseServices(this TestServiceProvider services)
        {
            services.AddSingleton<IClassProvider>(new BootstrapClassProvider());
            services.AddSingleton<IStyleProvider>(new BootstrapStyleProvider());
            services.AddSingleton<IJSRunner>(new BootstrapJSRunner(new MockJSRuntime()));
            services.AddSingleton<IJSRuntime>(new MockJSRuntime());
            services.AddSingleton<IComponentMapper>(new ComponentMapper());
            services.AddSingleton<IThemeGenerator>(new BootstrapThemeGenerator());
            services.AddSingleton<IIconProvider>(new MockIconProvider());
            services.AddSingleton<BlazoriseOptions>(new BlazoriseOptions());
        }

        class MockJSRuntime : IJSRuntime
        {
            public ValueTask<TValue> InvokeAsync<TValue>(string identifier, object[] args)
            {
                return new ValueTask<TValue>();
            }

            public ValueTask<TValue> InvokeAsync<TValue>(string identifier, CancellationToken cancellationToken, object[] args)
            {
                return new ValueTask<TValue>();
            }
        }

        class MockIconProvider : IIconProvider
        {
            public bool IconNameAsContent => false;

            public string GetIconName(IconName name)
            {
                return string.Empty;
            }

            public string GetIconName(string customName)
            {
                return string.Empty;
            }

            public string Icon(object name, IconStyle iconStyle)
            {
                return string.Empty;
            }

            public void SetIconName(IconName name, string newName)
            {
            }
        }
    }
}