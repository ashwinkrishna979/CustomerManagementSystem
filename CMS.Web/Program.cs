using CMS.Web.Components;
using CMS.Data.Repositories;
using CMS.UseCases.DataInterfaces;
using CMS.UseCases.UseCaseInterfaces;
using CMS.UseCases.UseCases;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//Repository Dependencies
builder.Services.AddScoped<ICustomerRepository,HardcodedDataRepository>();

//UseCase Dependencies
builder.Services.AddScoped<ICustomerUseCase,CustomerUseCase>();

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
    .AddInteractiveServerRenderMode();

app.Run();
