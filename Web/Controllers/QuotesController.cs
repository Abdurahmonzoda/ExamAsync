using Microsoft.AspNetCore.Mvc;
using Services.Services;
using Domain.Emtities;
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
    [HttpPut]
    public async Task<int> UpdateQuotes(Quotes quote)
    {
        return await _contactService.UpdateQuotes(quote);
    }
    [HttpDelete]
    public async Task<int> DeleteQuotes(int id)
    {
        return await _contactService.DeleteQuotes(id);
    }
    [HttpGet]
    public async Task<List<Quotes>> GetQuotes()
    {
        return await _contactService.GetQuotes();
    }
    [HttpGet("id")]
    public async Task<List<Quotes>> GetQuotesById(int id)
    {
        return await _contactService.GetQuotesById(id);
    }
    [HttpGet("rendom")]
    public async Task<Quotes> GetQuotesRendom()
    {
        return await _contactService.GetQuotesRendom();
    }




}

