using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Api.Data;
using PokemonReviewApp.Api.Features.Category;
using PokemonReviewApp.Api.Features.Country;
using PokemonReviewApp.Api.Features.Pokemons;

var builder = WebApplication.CreateBuilder(args);
{
	builder.Services.AddControllers();
	builder.Services.AddTransient<Seed>();

	builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
	builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
	builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
	builder.Services.AddScoped<ICountryRepository, CountryRepository>();


	builder.Services.AddEndpointsApiExplorer();
	builder.Services.AddSwaggerGen();
	builder.Services.AddDbContext<DataContext>(o =>
	{
		o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
	});
}

var app = builder.Build();
{

	if (args.Length == 1 && args[0].ToLower() == "seeddata")
		SeedData(app);

	void SeedData(IHost app)
	{
		var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

		using (var scope = scopedFactory.CreateScope())
		{
			var service = scope.ServiceProvider.GetService<Seed>();
			service.SeedDataContext();
		}
	}


	if (app.Environment.IsDevelopment())
	{
		app.UseSwagger();
		app.UseSwaggerUI();
	}

	app.UseHttpsRedirection();
	app.UseAuthorization();
	app.MapControllers();
	app.Run();
}