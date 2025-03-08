using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Neosoft_Ankita_Khokale_04March2025.Data;
using Neosoft_Ankita_Khokale_04March2025.Models;

namespace Neosoft_Ankita_Khokale_04March2025.Repository
{
    public class CountryRepository
    {
        private readonly DbHelper _dbHelper;

        public CountryRepository(DbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<Country> GetCountries()
        {
            DataTable dt = _dbHelper.ExecuteStoredProcedure("stp_Country_GetAll");
            List<Country> countries = new List<Country>();

            foreach (DataRow row in dt.Rows)
            {
                countries.Add(new Country
                {
                    Row_Id = Convert.ToInt32(row["Row_Id"]),
                    CountryName = row["CountryName"].ToString()
                });
            }
            return countries;
        }

   /*     public void AddCountry(Country country)
        {
            SqlParameter[] parameters = { new SqlParameter("@CountryName", country.CountryName) };
            _dbHelper.ExecuteStoredProcedure("stp_Country_Insert", parameters);
        }

        public void DeleteCountry(int id)
        {
            SqlParameter[] parameters = { new SqlParameter("@CountryId", id) };
            _dbHelper.ExecuteStoredProcedure("stp_Country_Delete", parameters);
        }*/
    }
}