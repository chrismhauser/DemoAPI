using Data.DataAccess;
using Data.Handlers;
using Data.Services;
using Data.Services.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddTransient<IPolicyService, PolicyService>();
builder.Services.AddTransient<ICarrierService, CarrierService>();
builder.Services.AddTransient<IPolicyTypeService, PolicyTypeService>();
builder.Services.AddTransient<IPolicyStatusService, PolicyStatusService>();
builder.Services.AddTransient<IPaymentTermService, PaymentTermService>();
builder.Services.AddMediatR(typeof(DataContext).Assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

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
