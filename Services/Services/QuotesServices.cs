using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Emtities;
using Dapper;

namespace Services.Services
{
    public class QuotesServices
    {

        private string _connectionString;
        public QuotesServices()
        {
            _connectionString = "Server = 127.0.0.1; Port = 5433; Database = Quotes; User Id = postgres; Password = 45sD67ghone;";
        }

        public async Task<int> UpdateQuotes(Quotes quote)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                string sql = $"UPDATE  quotes SET author = '{quote.Author}', quotesText = '{quote.QuotesText}' WHERE id = '{quote.Id}'";
                var response = await connection.ExecuteAsync(sql);
                return response;
            }
        }
        public async Task<int> DeleteQuotes(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                string sql = $"DELETE FROM quotes WHERE id = '{id}'";
                var response = await connection.ExecuteAsync(sql);
                return response;
            }
        }
        public async Task<List<Quotes>> GetQuotes()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                var sql = $"SELECT * FROM quotes";
                var list = await connection.QueryAsync<Quotes>(sql);
                return list.ToList();
            }
        }

        public async Task<List<Quotes>> GetQuotesById(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                var sql = $"SELECT * FROM quotes JOIN category ON quotes.categoryid = category.id where quotes.categoryid = {id};";
                var list = await connection.QueryAsync<Quotes>(sql);
                return list.ToList();
            }
        }
        public async Task<Quotes> GetQuotesRendom()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                var sql = $"select * from Quotes order by random() limit 1 ;";
                var list = await connection.QuerySingleAsync<Quotes>(sql);
                return list;
            }
        }

    }
}
