using RealEstate_Dapper.Api.Models.DapperContext;
using RealEstate_Dapper.Api.Repositories.AppUserRepositories;
using RealEstate_Dapper.Api.Repositories.BottomGridRepositories;
using RealEstate_Dapper.Api.Repositories.CategoryRepository;
using RealEstate_Dapper.Api.Repositories.ContactRepositories;
using RealEstate_Dapper.Api.Repositories.EmployeeRepositories;
using RealEstate_Dapper.Api.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories;
using RealEstate_Dapper.Api.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductsRepositories;
using RealEstate_Dapper.Api.Repositories.EstateAgentRepositories.DashboardRepositories.MessageRepositories;
using RealEstate_Dapper.Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticRepositories;
using RealEstate_Dapper.Api.Repositories.PopularLocationRepositories;
using RealEstate_Dapper.Api.Repositories.ProductImagesRepositories;
using RealEstate_Dapper.Api.Repositories.ProductRepository;
using RealEstate_Dapper.Api.Repositories.PropertyAmenityRepositories;
using RealEstate_Dapper.Api.Repositories.ServiceRepository;
using RealEstate_Dapper.Api.Repositories.StatisticsRepositories;
using RealEstate_Dapper.Api.Repositories.SubFeatureRepositories;
using RealEstate_Dapper.Api.Repositories.TestimonialRepositories;
using RealEstate_Dapper.Api.Repositories.ToDoListRepositories;
using RealEstate_Dapper.Api.Repositories.WhoWeAreRepository;

namespace RealEstate_Dapper.Api.Containers
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddTransient<Context>();

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IWhoWeAreDetailRepository, WhoWeAreDetailRepository>();
            services.AddTransient<IServiceRepository, ServiceRepository>();
            services.AddTransient<IBottomGridRepository, BottomGridRepository>();
            services.AddTransient<IPopularLocationRepository, PopularLocationRepository>();
            services.AddTransient<IStatisticsRepository, StatisticsRepository>();
            services.AddTransient<ITestimonialRepository, TestimonialRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IToDoListRepository, ToDoListRepository>();
            services.AddTransient<IStatisticRepository, StatisticRepository>();
            services.AddTransient<IChartRepository, ChartRepository>();
            services.AddTransient<ILastProductsRepository, LastProductsRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();
            services.AddTransient<IProductImageRepository, ProductImageRepository>();
            services.AddTransient<IAppUserRepository, AppUserRepository>();
            services.AddTransient<IPropertyAmenityRepository, PropertyAmenityRepository>();
            services.AddTransient<ISubFeatureRepository, SubFeatureRepository>();
        }
    }
}
