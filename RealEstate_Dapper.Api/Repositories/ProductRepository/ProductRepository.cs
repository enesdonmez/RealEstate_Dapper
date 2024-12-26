using Dapper;
using RealEstate_Dapper.Api.Dtos.ProductDetailDto;
using RealEstate_Dapper.Api.Dtos.ProductDtos;
using RealEstate_Dapper.Api.Models.DapperContext;

namespace RealEstate_Dapper.Api.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateProduct(CreateProductDto createProductDto)
        {
            string query = "insert into Product (Title,Price,CoverImage,City,District,Address,Descripction,Type,ProductCategory,EmployeeID,DealOfTheDay,AdvertisementDate,ProductStatus) Values(@title,@price,@coverImage,@city,@district,@address,@description,@type,@productCategory,@employeeID,@dealOfTheDay,@advertisementDate,@productStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", createProductDto.Title);
            parameters.Add("@price", createProductDto.Price);
            parameters.Add("@coverImage", createProductDto.CoverImage);
            parameters.Add("@city", createProductDto.City);
            parameters.Add("@district", createProductDto.District);
            parameters.Add("@address", createProductDto.Address);
            parameters.Add("@description", createProductDto.Description);
            parameters.Add("@type", createProductDto.Type);
            parameters.Add("@productCategory", createProductDto.ProductCategory);
            parameters.Add("@employeeID", createProductDto.EmployeeID);
            parameters.Add("@dealOfTheDay", createProductDto.DealOfTheDay);
            parameters.Add("@advertisementDate", createProductDto.AdvertisementDate);
            parameters.Add("@productStatus", true);

            using (var connect = _context.CreateConnection())
            {
                await connect.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "select * from Product";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }

        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            string query = "select ProductID,Title,Price,City,District,CategoryName,CoverImage,Address,Type,DealOfTheDay,SlugUrl from Product inner join Category on Product.ProductCategory = CategoryID";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLastThreeProductWithCategoryDto>> GetLast3ProductAsync()
        {
            string query = "select top(3) ProductID,Title,Price,City,District,ProductCategory,Description,CategoryName,Type,CoverImage,AdvertisementDate from Product inner join Category on Product.ProductCategory = Category.CategoryID order by ProductID desc";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLastThreeProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLastFiveProductWithCategoryDto>> GetLast5ProductAsync()
        {
            string query = "select top(5) ProductID,Title,Price,City,District,ProductCategory,CategoryName,Type,AdvertisementDate from Product inner join Category on Product.ProductCategory = Category.CategoryID order by ProductID desc";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLastFiveProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByFalse(int id)
        {
            string query = "select ProductID,Title,Price,City,District,CategoryName,CoverImage,Address,Type from Product " +
                "inner join Category on Product.ProductCategory = CategoryID " +
                "where EmployeeId = @employeeId and ProductStatus = 0";

            DynamicParameters param = new();
            param.Add("@employeeId", id);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query, param);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByTrue(int id)
        {
            string query = "select ProductID,Title,Price,City,District,CategoryName,CoverImage,Address,Type from Product " +
                "inner join Category on Product.ProductCategory = CategoryID " +
                "where EmployeeId = @employeeId and ProductStatus = 1";

            DynamicParameters param = new();
            param.Add("@employeeId", id);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query, param);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductByDealOfTheDayTrueAsync()
        {
            string query = "select ProductID,Title,Price,City,District,CategoryName,CoverImage,Address,Type,DealOfTheDay from Product inner join Category on Product.ProductCategory = CategoryID and DealOfTheDay = 1";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetProductByIdDto> GetProductById(int id)
        {
            string query = "select ProductID,Title,Price,City,District,CategoryName,CoverImage,Address,Description,Type,DealOfTheDay,AdvertisementDate,SlugUrl from Product inner join Category on Product.ProductCategory = CategoryID where ProductID = @id";

            DynamicParameters param = new();
            param.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetProductByIdDto>(query, param);
                return values.FirstOrDefault();
            }
        }

        public async Task<GetProductDetailByIdDto> GetProductDetailById(int id)
        {
            string query = "select * from ProductDetails where ProductID = @id";

            DynamicParameters param = new();
            param.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetProductDetailByIdDto>(query, param);
                return values.FirstOrDefault();
            }
        }

        public async Task ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            var query = "Update Product set DealOfTheDay = 0 where ProductID = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            var query = "Update Product set DealOfTheDay = 1 where ProductID = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultProductWithSearchListDto>> ResultProductWithSearchList(string searchKeyValue, int propertyCategoryId, string city)
        {
            string query = $"select * from product where Title like '%{searchKeyValue}%' and ProductCategory = @propertyCategoryId and City = @city";

            DynamicParameters param = new();
            param.Add("@propertyCategoryId", propertyCategoryId);
            param.Add("@city", city);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithSearchListDto>(query, param);
                return values.ToList();
            }
        }
    }
}
