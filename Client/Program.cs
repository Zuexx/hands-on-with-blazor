using HandsOnWithBlazor.Client;
using HandsOnWithBlazor.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using HandsOnWithBlazor.Client.AuthProviders;
using Microsoft.AspNetCore.Components.Authorization;
using HandsOnWithBlazor.Client.Handlers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient(
    "HandsOnWithBlazor.ServerAPI",
    client =>
        client.BaseAddress =
            new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<JwtAuthorizationMessageHandler>();

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("HandsOnWithBlazor.ServerAPI"));

builder.Services.AddSingleton(typeof(SimpleStateContainerService<>), typeof(SimpleStateContainerService<>));
builder.Services.AddScoped<AuthenticationStateProvider,JwtAuthenticationStateProvider>();
builder.Services.AddTransient<JwtAuthorizationMessageHandler>();

builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();
