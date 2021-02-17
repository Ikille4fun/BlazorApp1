using BlazorApp1.Client.Components.Services;
using BlazorApp1.Shared;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorApp1.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services
                .AddScoped<IAccountService, AccountService>()
                .AddScoped<IHttpService, HttpService>()
                .AddScoped<ILocalStorageService, LocalStorageService>();

            // default configure http client
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            // custom configure http client
            //builder.Services.AddScoped(x =>
            //{
            //    var apiUrl = new Uri(builder.Configuration["apiUrl"]);

            //    // use backend if "backend" is "true" in appsetting.json
            //    if (builder.Configuration["Backend"] == "true")
            //    {
            //        var backendHandler = BackendHandler(x.GetService<ILocalStorageService>());
            //        return new HttpClient(backendHandler) { BaseAddress = apiUrl };
            //    }

            //    return new HttpClient() { BaseAddress = apiUrl };
            //});

            var host = builder.Build();

            var accountService = host.Services.GetRequiredService<IAccountService>();
            await accountService.Initialize();

            await builder.Build().RunAsync();
        }
    }
}
