using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Neosoft_Ankita_Khokale_04March2025.Data;
using Neosoft_Ankita_Khokale_04March2025.Models;

namespace Neosoft_Ankita_Khokale_04March2025.Repository
{
    public class StateRepository
    {
        private readonly DbHelper _dbHelper;

        public StateRepository(DbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<State> GetStates()
        {
            DataTable dt = _dbHelper.ExecuteStoredProcedure("stp_State_GetAll");
            List<State> states = new List<State>();

            foreach (DataRow row in dt.Rows)
            {
                states.Add(new State
                {
                    Row_Id = Convert.ToInt32(row["Row_Id"]),
                    CountryId = Convert.ToInt32(row["CountryId"]),
                    StateName = row["StateName"].ToString()
                });
            }
            return states;
        }

        public List<State> GetStatesByCountryId(int countryId)
        {
            SqlParameter[] parameters = { new SqlParameter("@CountryId", countryId) };
            DataTable dt = _dbHelper.ExecuteStoredProcedure("stp_State_GetByCountryId", parameters);
            List<State> states = new List<State>();

            foreach (DataRow row in dt.Rows)
            {
                states.Add(new State
                {
                    Row_Id = Convert.ToInt32(row["Row_Id"]),
                    CountryId = Convert.ToInt32(row["CountryId"]),
                    StateName = row["StateName"].ToString()
                });
            }
            return states;
        }

/*        public void AddState(State state)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@CountryId", state.CountryId),
                new SqlParameter("@StateName", state.StateName)
            };
            _dbHelper.ExecuteStoredProcedure("stp_State_Insert", parameters);
        }

        public void DeleteState(int id)
        {
            SqlParameter[] parameters = { new SqlParameter("@StateId", id) };
            _dbHelper.ExecuteStoredProcedure("stp_State_Delete", parameters);
        }*/
    }
}