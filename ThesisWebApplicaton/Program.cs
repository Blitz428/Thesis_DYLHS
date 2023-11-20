using Thesis.Repository;
using ThesisApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<IngredientDatabaseSettings>(
    builder.Configuration.GetSection("DrinksDatabase"));

builder.Services.Configure<IngredientDatabaseSettings>(
    builder.Configuration.GetSection("IngredientsDatabase"));

builder.Services.Configure<RatingDatabaseSettings>(
    builder.Configuration.GetSection("RatingsDatabase"));

builder.Services.Configure<UserDatabaseSettings>(
    builder.Configuration.GetSection("UsersDatabase"));

builder.Services.AddSingleton<DrinksService>();

builder.Services.AddSingleton<IngredientsService>();

builder.Services.AddSingleton<RatingsService>();

builder.Services.AddSingleton<UsersService>();


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
