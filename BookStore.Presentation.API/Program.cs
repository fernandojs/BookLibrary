using BookStore.Repository;
using BookStore.Repository.Interfaces;
using BookStore.Service.BusinessLogic;
using BookStore.Service.BusinessLogic.Events.Interfaces;
using BookStore.Service.BusinessLogic.Infra;
using BookStore.Service.BusinessLogic.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("LocalhostDevelopment",
        builder => builder.WithOrigins("https://localhost:7082")  
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowCredentials());
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<IBookRepository, BookRepository>(provider =>{  return new BookRepository(connectionString);});
builder.Services.AddScoped<IBookStoreService, BookStoreService>();
builder.Services.AddScoped<IEventBus, KafkaEventBus>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseCors("LocalhostDevelopment");

app.Run();

