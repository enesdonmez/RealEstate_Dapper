﻿namespace RealEstate_Dapper.UI.Dtos.PopularLocationsDtos
{
    public class ResultPopularLocationDto
    {
        public int LocationID { get; set; }

        public string CityName { get; set; }

        public string ImageUrl { get; set; }

        public int PropertyCount { get; set; }

    }
}
