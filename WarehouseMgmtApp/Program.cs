
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WarehouseMgmtApp.Client.Auth;
using WarehouseMgmtApp.Client.Services;
using WarehouseMgmtApp.Components;




var builder = WebApplication.CreateBuilder(args);




// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<ProductTypeService>();
builder.Services.AddScoped<MetricUnitService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<UserService>();





HttpClient client = new();
client.BaseAddress = new("http://www.warehouseapi.somee.com/api/");
builder.Services.AddSingleton<HttpClient>(client);


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(WarehouseMgmtApp.Client._Imports).Assembly);

app.Run();
