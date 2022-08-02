using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SavuDiary;
using SavuDiary.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddDataServices();
builder.Services.AddCommonUIServices();
builder.Services.AddSingleton(typeof(SavuDiary.Client.Components.ToasterServices), typeof(SavuDiary.Client.Components.ToasterServices));
var app= builder.Build();
await app.RunAsync();
