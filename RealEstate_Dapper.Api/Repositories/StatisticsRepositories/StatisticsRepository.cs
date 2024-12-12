using Dapper;
using RealEstate_Dapper.Api.Models.DapperContext;

namespace RealEstate_Dapper.Api.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly Context _context;

        public StatisticsRepository(Context context)
        {
            _context = context;
        }

        public  int ActiveCategoryCount()
        {
            string query = "Select Count(*) from Category where CategoryStatus = 1";
            using (var connect = _context.CreateConnection())
            {
                var value = connect.QueryFirstOrDefault<int>(query);
                return value;
            }
        }

        public int ActiveEmployeeCount()
        {
            string query = "Select Count(*) from Employee where Status = 1";
            using (var connect = _context.CreateConnection())
            {
                var value = connect.QueryFirstOrDefault<int>(query);
                return value;
            }
        }

        public int ApartmentCount()
        {
            string query = "Select Count(*) from Product where ProductCategory = 4";
            using (var connect = _context.CreateConnection())
            {
                var value = connect.QueryFirstOrDefault<int>(query);
                return value;
            }
        }

        public decimal AverageProductPriceByRent()
        {
            string query = "Select Avg(Price) from Product where Type = 'Kiralık' ";
            using (var connect = _context.CreateConnection())
            {
                var value = connect.QueryFirstOrDefault<decimal>(query);
                return value;
            }
        }

        public decimal AverageProductPriceBySale()
        {
            string query = "Select Avg(Price) from Product where Type = 'Satılık' ";
            using (var connect = _context.CreateConnection())
            {
                var value = connect.QueryFirstOrDefault<decimal>(query);
                return value;
            }
        }

        public int AverageRoomCount()
        {
            string query = "Select Avg(RoomCount) from ProductDetails";
            using (var connect = _context.CreateConnection())
            {
                var value = connect.QueryFirstOrDefault<int>(query);
                return value;
            }
        }

        public int CategoryCount()
        {
            string query = "Select Count(*) from Category";
            using (var connect = _context.CreateConnection())
            {
                var value = connect.QueryFirstOrDefault<int>(query);
                return value;
            }
        }

        public string CategoryNameByMaxProductCount()
        {
            string query = "Select top(1) c.CategoryName , Count(*) as toplam_adet  from Product p inner join Category c on p.ProductCategory = c.CategoryID group by c.CategoryName  order by COUNT(*) desc";
            using (var connect = _context.CreateConnection())
            {
                var value = connect.QueryFirstOrDefault<string>(query);
                return value;
            }
        }

        public string CityNameByMaxProductCount()
        {
            string query = "Select top(1) City , Count(*) as toplam_adet  from Product group by City order by COUNT(*) desc";
            using (var connect = _context.CreateConnection())
            {
                var value = connect.QueryFirstOrDefault<string>(query);
                return value;
            }
        }

        public int DifferentCityCount()
        {
            string query = "Select Count(Distinct(City)) from Product";
            using (var connect = _context.CreateConnection())
            {
                var value = connect.QueryFirstOrDefault<int>(query);
                return value;
            }
        }

        public string EmployeeNameByMaxProductCount()
        {
            string query = "Select top(1) Name , Count(*) as toplam_adet  from Product inner join Employee on Product.EmployeeID = Employee.EmployeeID group by Name order by COUNT(*) desc";
            using (var connect = _context.CreateConnection())
            {
                var value = connect.QueryFirstOrDefault<string>(query);
                return value;
            }
        }

        public decimal LastProductPrice()
        {
            string query = "Select top(1) Price from Product order by ProductID desc";
            using (var connect = _context.CreateConnection())
            {
                var value = connect.QueryFirstOrDefault<decimal>(query);
                return value;
            }
        }

        public string NewestBuildingYear()
        {
            string query = "Select max(BuildYear) Price from ProductDetails";
            using (var connect = _context.CreateConnection())
            {
                var value = connect.QueryFirstOrDefault<string>(query);
                return value;
            }
        }

        public string OldestBuildingYear()
        {
            string query = "Select min(BuildYear) from ProductDetails";
            using (var connect = _context.CreateConnection())
            {
                var value = connect.QueryFirstOrDefault<string>(query);
                return value;
            }
        }

        public int PasiveCategoryCount()
        {
            string query = "Select Count(*) from Category where CategoryStatus = 0";
            using (var connect = _context.CreateConnection())
            {
                var value = connect.QueryFirstOrDefault<int>(query);
                return value;
            }
        }

        public int ProductCount()
        {
            string query = "Select Count(*) from Product";
            using (var connect = _context.CreateConnection())
            {
                var value = connect.QueryFirstOrDefault<int>(query);
                return value;
            }
        }
    }
}
