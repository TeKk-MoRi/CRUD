using CRUD.UI.Data;
using Datalayer.Context;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

#region Context
builder.Services.AddDbContext<CRUDContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr"), providerOptions => providerOptions.EnableRetryOnFailure()));
#endregion

#region IOC
Contract.StartUp.Start(builder.Services);
builder.Services.AddMediatR(typeof(Contract.StartUp).Assembly);
#endregion
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
