using CMS.Web.Components;
using CMS.Data.Repositories;
using CMS.UseCases.DataInterfaces;
using CMS.UseCases.UseCaseInterfaces;
using Microsoft.EntityFrameworkCore;

using CMS.UseCases.UseCases;
using CMS.Data.Context;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddDbContext<CMSDBContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


//Repository Dependencies
builder.Services.AddScoped<ICustomerRepository,CustomerRepository>();

//UseCase Dependencies
builder.Services.AddScoped<ICustomerUseCase,CustomerUseCase>();
builder.Services.AddScoped<ICustomerValidator,CustomerValidator>();


var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    using var context = scope.ServiceProvider.GetRequiredService<CMSDBContext>();
    context.Database.Migrate();
}

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
