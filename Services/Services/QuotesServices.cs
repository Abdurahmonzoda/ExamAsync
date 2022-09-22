using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Emtities;
using Dapper;
using Domain.Wrapper;

namespace Services.Services
{
    public class QuotesServices
    {

        private DataContext.DataContext _context;
        public QuotesServices(DataContext.DataContext context)
        {
            _context = context;
        }
   
      
        
        public async Task<Response<Quotes> >UpdateQuotes(Quotes quote)
        {
            using var connection = _context.CreateConnection();
                string sql = $"UPDATE  quotes SET author = '{quote.Author}', quotesText = '{quote.QuotesText}' WHERE id = '{quote.Id}'";
                try
                { 
                var response = await connection.ExecuteAsync(sql);
                return new Response<Quotes>(quote);
                }
                catch (Exception ex)
                {
                    return new Response<Quotes>(System.Net.HttpStatusCode.InternalServerError,ex.Message);
                }
            }
        public async Task< Response<string>> DeleteQuotes(int id)
        {
            using var connection = _context.CreateConnection();
           
                string sql = $"DELETE FROM quotes WHERE id = '{id}'";
                try
                {
                    var response = await connection.ExecuteAsync(sql);
                    return new Response<string>("Success");
                }
                catch (Exception ex)
                {
                    return new Response<string>($"Very bad error : {ex.Message}");
                }
            }
        public async Task<Response<List< Quotes>>> GetQuotes()
        {
            using var connection = _context.CreateConnection();
                var sql = $"SELECT * FROM quotes";
                try
                {
                    var list = await connection.QueryAsync<Quotes>(sql);
                    return new Response<List<Quotes>>(list.ToList());

                }
                catch (Exception ex)
                {
                   return new Response<List<Quotes>>(System.Net.HttpStatusCode.InternalServerError,ex.Message) ;
                }
        }
        public async Task<Response<Quotes>> GetQuotesById(int id)
        {
            using var connection = _context.CreateConnection();
                var sql = $"SELECT * FROM quotes  where quotes.id = {id};";
                try
                {
                    var list = await connection.QuerySingleAsync<Quotes>(sql);
                    return new Response<Quotes>(list);
                }
                catch (Exception ex)
                {
                   return new Response<Quotes>(System.Net.HttpStatusCode.InternalServerError,ex.Message);
                }
            }
        public async Task<Response<List<QuotesDto>>> GetQuotesWithCategoryName(int id)
        {
            var connection = _context.CreateConnection();
                var sql = $"SELECT quotes.id , quotes.author , quotes.quotestext , category.name as Category   FROM quotes JOIN category ON quotes.categoryid = category.id where quotes.categoryid = {id};";
                try
                {
                    var list = await connection.QueryAsync<QuotesDto > (sql);
                    return new Response<List<QuotesDto>>(list.ToList());
                }
                catch (Exception ex)
                {
                    return new Response<List<QuotesDto>>(System.Net.HttpStatusCode.InternalServerError,ex.Message) ;
                }
        }
        public async Task<Response< Quotes>> GetQuotesRendom()
        {
            var connection = _context.CreateConnection();
                var sql = $"select * from Quotes order by random() limit 1 ;";
                try
                {
                    var list = await connection.QuerySingleAsync<Quotes>(sql);
                   return new Response<Quotes>(list);
                }
                catch (Exception ex)
                {
                    return new Response<Quotes>(System.Net.HttpStatusCode.InternalServerError,ex.Message);
                }
            }

        public async Task<Response <Quotes>> AddQuotes(Quotes quote)
        {
            var connection = _context.CreateConnection();
                string sql = $"INSERT INTO Quotes (author , quotestext , categoryid) VALUES (@Author,@QuotesText,@CategoryId) RETURNING id";
                try
                {
                    var response = await connection.ExecuteScalarAsync<int>(sql , new { quote.Author, quote.QuotesText , quote.CategoryId });
                    quote.Id = response;
                    return new Response<Quotes>(quote);
                }
                catch (Exception ex)
                {
                    return new Response<Quotes>(System.Net.HttpStatusCode.InternalServerError, ex.Message); 
                }
            }

    }
}
