using RealEstate_Dapper.Api.Hubs;
using RealEstate_Dapper.Api.Models.DapperContext;
using RealEstate_Dapper.Api.Repositories.BottomGridRepositories;
using RealEstate_Dapper.Api.Repositories.CategoryRepository;
using RealEstate_Dapper.Api.Repositories.ContactRepositories;
using RealEstate_Dapper.Api.Repositories.EmployeeRepositories;
using RealEstate_Dapper.Api.Repositories.PopularLocationRepositories;
using RealEstate_Dapper.Api.Repositories.ProductRepository;
using RealEstate_Dapper.Api.Repositories.ServiceRepository;
using RealEstate_Dapper.Api.Repositories.StatisticsRepositories;
using RealEstate_Dapper.Api.Repositories.TestimonialRepositories;
using RealEstate_Dapper.Api.Repositories.ToDoListRepositories;
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
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IStatisticsRepository, StatisticsRepository>();
builder.Services.AddTransient<IContactRepository, ContactRepository>();
builder.Services.AddTransient<IToDoListRepository, ToDoListRepository>();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials();

    });
});

builder.Services.AddHttpClient();
builder.Services.AddSignalR();

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

app.UseCors("CorsPolicy");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<SignalRHub>("/signalrhub");
// Localhost:1234/signalrhub

app.Run();