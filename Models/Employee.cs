using System;

namespace Neosoft_Ankita_Khokale_04March2025.Models
{
    public class Employee
    {
        public int? Row_Id { get; set; }
        public string? EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CountryId { get; set; }
        public string? CountryName { get; set; } 
        public int StateId { get; set; }
        public string? StateName { get; set; } 
        public int CityId { get; set; }
        public string? CityName { get; set; } 
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public string PanNumber { get; set; }
        public string PassportNumber { get; set; }
        //public string? ProfileImage { get; set; }
        public int Gender { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfJoinee { get; set; }
     
    }
}