using VoucherManagement.Command.Interfaces;
using VoucherManagement.Command.Services;
using VoucherManagement.DatabaseContext;
using VoucherManagement.Queries.Interfaces;
using VoucherManagement.Queries.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<VoucherContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
    .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors();
});

// Register our services
builder.Services.AddScoped<ICreateVoucher, CreateVoucher>();
builder.Services.AddScoped<IListVouchers, ListVouchers>();
builder.Services.AddScoped<IValidateVoucher, ValidateVoucher>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<VoucherContext>();
    context.Database.Migrate();
}

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
