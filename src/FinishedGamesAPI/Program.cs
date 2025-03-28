using FinishedGamesAPI.Data;
using FinishedGamesAPI.Models;
using FinishedGamesAPI.Repositories;
using FinishedGamesAPI.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddTransient<IFinishedGamesRepository, FinishedGamesRepository>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("v1/Games", async (CancellationToken cancellationToken, IFinishedGamesRepository repository) 
    =>  Results.Ok(await repository.GetAllAsync(cancellationToken)));

app.MapGet("v1/Games/{id}", async (CancellationToken cancellationToken, IFinishedGamesRepository repository, Guid id) 
    => Results.Ok(await repository.GetByIdAsync(id, cancellationToken)));

app.MapPost("v1/Games", async (CancellationToken cancellationToken, IFinishedGamesRepository repository, Game game)
=> Results.Ok(await repository.CreateAsync(game, cancellationToken))); 

app.MapPut("v1/Games/{id}", async (CancellationToken cancellationToken, IFinishedGamesRepository repository, Guid id, Game game)
    => Results.Ok(await repository.UpdateAsync(id, game, cancellationToken)));

app.MapDelete("v1/Games/{id}", async (CancellationToken cancellationToken, IFinishedGamesRepository repository, Guid id)
    => Results.Ok(await repository.DeleteAsync(id, cancellationToken)));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();

