using Microsoft.EntityFrameworkCore;
using Todo.Domain.Handlers;
using Todo.Domain.Infra.Context;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Infra.Repositories;
using Todo.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependencia DbContext
builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
//builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlite();

builder.Services.AddTransient<IToDoRepository, TodoRepository>();
builder.Services.AddTransient<ToDoHandler, ToDoHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting()
    .UseAuthentication()
    .UseAuthorization()
    .UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader())
    .UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

app.MapControllers();

app.Run();
