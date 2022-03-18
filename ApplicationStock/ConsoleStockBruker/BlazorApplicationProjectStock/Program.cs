using AutoMapper;
using BlazorApplicationProjectStock;
using BlazorApplicationProjectStock.Map;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Windows;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var mapperConfiguration = new MapperConfiguration(configuration =>
{
    configuration.AddProfile(new TdoMapper());
});

var mapper = mapperConfiguration.CreateMapper();

builder.Services.AddSingleton(mapper);

var Mapper = new Mapper(mapperConfiguration);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();


