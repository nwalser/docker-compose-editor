using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.FluentUI.AspNetCore.Components;
using MudBlazor.Services;
using Sapphire.App.Components.Components;
using Sapphire.App.Services;
using App = Sapphire.App.Components.App;

var builder = WebApplication.CreateBuilder(args);
var webRuntime = Convert.ToBoolean(Environment.GetEnvironmentVariable("WEB"));

builder.WebHost.UseElectron(args);
builder.Services.AddElectron();

builder.Services.AddMudServices();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddFluentUIComponents();

builder.Services.AddSingleton(new TimeZoneService());
builder.Services.AddSingleton(new EditorState());

var app = builder.Build();

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

if (!webRuntime)
{
    await app.StartAsync();

    var options = new BrowserWindowOptions()
    {
        Title = "Sapphire",
        MinHeight = 800,
        MinWidth = 1200,
        Frame = false,
    };
    var window = await Electron.WindowManager.CreateWindowAsync(options);
    await window.WebContents.Session.ClearCacheAsync();

    app.WaitForShutdown();
}
else
{
    app.Run();
}
