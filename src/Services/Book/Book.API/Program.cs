using Book.API.Context;
using Book.API.EventBusConsumer;
using Book.API.Repositories;
using Book.API.Repositories.IRepositories;
using EventBus.Messages.Common;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBookContext, BookContext>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookImageRepository, BookImageRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// COnfigure MassTransit RabbitMQ
builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<BookQuantityConsumer>();

    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(builder.Configuration["RabbitMq:HostUrl"]);
        cfg.ReceiveEndpoint(EventBusConstants.BookQueue, c =>
        {
            c.ConfigureConsumer<BookQuantityConsumer>(ctx);
        });
    });
});

builder.Services.AddMassTransitHostedService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
