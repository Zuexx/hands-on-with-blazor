using HandsOnWithBlazor.Client;
using HandsOnWithBlazor.Client.Services;
using HandsOnWithBlazor.Client.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton(typeof(SimpleStateContainerService<>), typeof(SimpleStateContainerService<>));

await builder.Build().RunAsync();
