using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using number_converter_api.Dto;

namespace number_converter_api.Controllers;

[ApiController]
[Route("[controller]")]
public class ToRomanController : Controller
{
    [HttpPost(Name = "ToRoman")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ToRoman(ArabicNumber i)
    {
        throw new NotImplementedException();
    }
}