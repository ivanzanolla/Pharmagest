using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using Pharmagest.Interface.Database.Poco;
using Pharmagest.Interface.Database.Dao;
using Pharmagest.Entity;
using System.Collections;

namespace Pharmagest.Db.Dao
{
    public class CompanyDao : BaseDataAccess, ICompanyDao
    {

        public IEnumerable<ICompany> GetCompanies()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<Company>("SELECT id Id, country_code CountryCode, name Name, address Address, vat_number Vat, request_time RequestTime FROM company").ToList();
            }
        }

        public ICompany GetCompany(string countryCode, string vat)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var sql = "SELECT id Id, country_code CountryCode, name Name, address Address, vat_number Vat, request_time RequestTime FROM company WHERE country_code = @CountryCode AND vat_number = @Vat";
                return connection.QuerySingleOrDefault<Company>(sql, new { CountryCode = countryCode, Vat = vat });
            }
        }

        public bool IsAlreadySaved(string countryCode, string vat)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT COUNT(1) FROM company WHERE country_code = @CountryCode AND vat_number = @Vat";
                int count = connection.ExecuteScalar<int>(sql, new { CountryCode = countryCode, Vat = vat });
                return count > 0;
            }
        }


        public int InsertCompany(ICompany company)
        {
            var rowsAffacted = 0;
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var sql = @"INSERT INTO company (country_code, name, address, vat_number, request_time) VALUES (@CountryCode, @Name, @Address, @Vat, @RequestTime)";
                rowsAffacted = connection.Execute(sql, company);
            }

            return rowsAffacted;
        }


        public int UpdateCompany(ICompany company)
        {
            var rowsAffacted = 0;
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var sql = @"
                            UPDATE company
                            SET 
                                country_code = @CountryCode, 
                                name = @Name, 
                                address = @Address, 
                                vat_number = @Vat, 
                                request_time = @RequestTime
                            WHERE country_code = @CountryCode AND vat_number = @Vat";
                rowsAffacted = connection.Execute(sql, company);
            }

            return rowsAffacted;
        }





    }
}
