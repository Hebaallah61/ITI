using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Diagnostics;
using task1;
using task1.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddHttpClient<ITrainee, TraineeDB>(
    client => client.BaseAddress = new Uri("https://localhost:7095/"));

builder.Services.AddHttpClient<ITrack, TrackDB>(
    client => client.BaseAddress = new Uri("https://localhost:7095/"));
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
