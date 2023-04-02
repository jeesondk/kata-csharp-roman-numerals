using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using number_converter;
using number_converter_api.Dto;

namespace number_converter_api.Controllers;

[ApiController]
[Route("[controller]")]
public class ToRomanController : Controller
{
    private readonly INumberConverter _numberConverter;

    public ToRomanController(INumberConverter numberConverter)
    {
        _numberConverter = numberConverter;
    }
    
    [HttpPost(Name = "ToRoman")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RomanNumeral))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult ToRoman(ArabicNumber i)
    {
        var convert = new Func<int, string>(i => _numberConverter.ToRoman(i));
        
        return Ok(new RomanNumeral(convert.Invoke(i.value)));
    }
}