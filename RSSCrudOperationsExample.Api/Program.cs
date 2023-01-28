using RSSCrudOperationsExample.Business.Extentions;
using RSSCrudOperationsExample.Domain.Extentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApiDbContext(builder.Configuration.GetConnectionString("DevelopmentConnection"));
builder.Services.AddIdentity();
builder.Services.AddMapper();
builder.Services.AddJwtBearerAuthentication(builder.Configuration);

builder.Services.AddRepositories();
builder.Services.AddServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.Run();
