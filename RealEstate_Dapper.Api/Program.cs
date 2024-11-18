using RealEstate_Dapper.Api.Models.DapperContext;
using RealEstate_Dapper.Api.Repositories.BottomGridRepositories;
using RealEstate_Dapper.Api.Repositories.CategoryRepository;
using RealEstate_Dapper.Api.Repositories.PopularLocationRepositories;
using RealEstate_Dapper.Api.Repositories.ProductRepository;
using RealEstate_Dapper.Api.Repositories.ServiceRepository;
using RealEstate_Dapper.Api.Repositories.TestimonialRepositories;
using RealEstate_Dapper.Api.Repositories.WhoWeAreRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<Context>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IWhoWeAreDetailRepository, WhoWeAreDetailRepository>();
builder.Services.AddTransient<IServiceRepository, ServiceRepository>();
builder.Services.AddTransient<IBottomGridRepository, BottomGridRepository>();
builder.Services.AddTransient<IPopularLocationRepository, PopularLocationRepository>();
builder.Services.AddTransient<ITestimonialRepository, TestimonialRepository>();
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

app.Run();