using Thesis.Repository;
using ThesisApi.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<DrinkDatabaseSettings>(
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
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
