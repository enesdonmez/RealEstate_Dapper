﻿namespace RealEstate_Dapper.Api.Dtos.EmployeeDtos
{
    public class CreateEmployeeDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}