﻿namespace RealEstate_Dapper.Api.Dtos.PopularLocationsDtos
{
    public class UpdatePopularLocationDto
    {
        public int LocationID { get; set; }

        public string CityName { get; set; }

        public string ImageUrl { get; set; }
    }
}
