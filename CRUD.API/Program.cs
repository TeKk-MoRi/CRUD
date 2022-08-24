using Datalayer.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Context
builder.Services.AddDbContext<CRUDContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr"), providerOptions => providerOptions.EnableRetryOnFailure()));
#endregion

#region IOC
Contract.StartUp.Start(builder.Services);
builder.Services.AddMediatR(typeof(Contract.StartUp).Assembly);
#endregion

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
