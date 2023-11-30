using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ProdutoApi.AutoMapper;
using Produtos.Domain.Entities;
using Produtos.Domain.Repositories.Interfaces;
using Produtos.Domain.Services;
using Produtos.Domain.Services.Interfaces;
using Produtos.Domain.Validador;
using Produtos.Infra.Data;
using Produtos.Infra.Repositories;
using System;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

var connectString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ProdutoContext>(opt => opt.UseSqlServer(connectString));

//builder.Services.AddDbContext<ProdutoContext>(opt => opt.UseInMemoryDatabase("PRODUTOSTORE"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//Services
builder.Services.AddTransient<IProdutoService, ProdutoService>();

//Infra
builder.Services.AddScoped<ProdutoContext, ProdutoContext>();
builder.Services.AddTransient<IValidator<Produto>, ProdutoValidador>();
builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();

builder.Services.AddAutoMapper(typeof(ConfigurationMapping));


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
