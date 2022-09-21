using Microsoft.AspNetCore.Mvc;
using Services.Services;
using Domain.Emtities;
using Domain.Wrapper; 
namespace Quote.Controllers;

[ApiController]
[Route("[controller]")]
public class QuotesController
{

    private QuotesServices _contactService;
    public QuotesController()
    {
        _contactService = new QuotesServices();
    }
    [HttpPost("AddQuote")]
    public async Task<Response<Quotes>> AddQuotes(Quotes quote)
    {
        return await _contactService.AddQuotes(quote);
    }
    [HttpPut("UpdateQuote")]
    public async Task<Response<string>> UpdateQuotes(Quotes quote)
    {
        return await _contactService.UpdateQuotes(quote);
    }
    [HttpDelete("DeleteQuote")]
    public async Task<Response<string>> DeleteQuotes(int id)
    {
        return await _contactService.DeleteQuotes(id);
    }
    [HttpGet("GetAllQuotes")]
    public async Task<Response< List<Quotes> > > GetQuotes()
    {
      return await _contactService.GetQuotes();
    }
    [HttpGet("GetQuotesById")]
    public async Task<Response<Quotes>> GetQuotesById(int id)
    {
      return await _contactService.GetQuotesById(id);
    }
    [HttpGet("GetQuotesWithCategoryName")]
    public async Task<Response<List<QuotesDto>>> GetQuotesWithCategoryName(int id)
    {
       return await _contactService.GetQuotesWithCategoryName(id);
    }
    [HttpGet("GetRendomQuote")]
    public async Task<Response<Quotes>> GetQuotesRendom()
    {
       return  await _contactService.GetQuotesRendom();
    }




}

