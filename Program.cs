using AppBugaoMotoFVLE.Components;
using AppBugaoMotoFVLE.Components.Models;
using AppBugaoMotoFVLE.Configs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<Conexao>();
builder.Services.AddSingleton<FornecedorDAO>();

// ✅ Registro do ClienteDAO
builder.Services.AddScoped<ClienteDAO>();

builder.Services.AddScoped<ProdutoDAO>(); // ✅ ADICIONE ESTA LINHA
builder.Services.AddScoped<ServicoDAO>(); // ✅ ADICIONE ESTA LINHA


// builder.Services.AddScoped<ProdutoDAO>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
