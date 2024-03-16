using AntonDream.Components;
using AntonDream.Services.IServices;
using AntonDream.Services;
using Blazored.Modal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents()
    .AddInteractiveServerComponents(); ;

builder.Services.AddBlazoredModal();

builder.Services.AddScoped<IDreamService, DreamService>();
builder.Services.AddHttpClient<IDreamService, DreamService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7262/");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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
    .AddInteractiveWebAssemblyRenderMode();

app.Run();
