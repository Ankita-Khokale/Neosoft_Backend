using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Neosoft_Ankita_Khokale_04March2025.Data;
using Neosoft_Ankita_Khokale_04March2025.Models;

namespace Neosoft_Ankita_Khokale_04March2025.Repository
{
    public class CityRepository
    {
        private readonly DbHelper _dbHelper;

        public CityRepository(DbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<City> GetCities()
        {
            DataTable dt = _dbHelper.ExecuteStoredProcedure("stp_City_GetAll");
            List<City> cities = new List<City>();

            foreach (DataRow row in dt.Rows)
            {
                cities.Add(new City
                {
                    Row_Id = Convert.ToInt32(row["Row_Id"]),
                    StateId = Convert.ToInt32(row["StateId"]),
                    CityName = row["CityName"].ToString()
                });
            }
            return cities;
        }

        public List<City> GetCitiesByStateId(int stateId)
        {
            SqlParameter[] parameters = { new SqlParameter("@StateId", stateId) };
            DataTable dt = _dbHelper.ExecuteStoredProcedure("stp_City_GetByStateId", parameters);
            List<City> cities = new List<City>();

            foreach (DataRow row in dt.Rows)
            {
                cities.Add(new City
                {
                    Row_Id = Convert.ToInt32(row["Row_Id"]),
                    StateId = Convert.ToInt32(row["StateId"]),
                    CityName = row["CityName"].ToString()
                });
            }
            return cities;
        }

 /*       public void AddCity(City city)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@StateId", city.StateId),
                new SqlParameter("@CityName", city.CityName)
            };
            _dbHelper.ExecuteStoredProcedure("stp_City_Insert", parameters);
        }

        public void DeleteCity(int id)
        {
            SqlParameter[] parameters = { new SqlParameter("@CityId", id) };
            _dbHelper.ExecuteStoredProcedure("stp_City_Delete", parameters);
        }*/
    }
}