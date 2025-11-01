using AppCore.UnitOfWork;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using InfraStructure.Config;
using InfraStructure.DataBase;
using InfraStructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")), ServiceLifetime.Scoped);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
         builder =>
         {
             builder.AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader();
         });
});
builder.Services.AddDbContextPool<AppDbContext>(c => c.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));
builder.Services.AddHttpClient();
//config autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new AutofacModule(builder.Configuration.GetConnectionString("DbConnection"))));
Host.CreateDefaultBuilder(args).UseServiceProviderFactory(new AutofacServiceProviderFactory());
var autofac = new ContainerBuilder();
autofac.RegisterModule(new AutofacModule(builder.Configuration.GetConnectionString("DbConnection")));
// end config autofac
builder.Services.AddHttpContextAccessor();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
