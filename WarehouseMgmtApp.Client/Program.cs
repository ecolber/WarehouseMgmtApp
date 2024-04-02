using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WarehouseMgmtApp.Client.Auth;

var builder = WebAssemblyHostBuilder.CreateDefault(args);



builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationAuth>();
builder.Services.AddAuthorizationCore();



await builder.Build().RunAsync();
