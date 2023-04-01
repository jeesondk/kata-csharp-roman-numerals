using FluentAssertions;
using number_converter_api.Controllers;

namespace number_converter_api_tests;

public class ToRomanControllerTests
{
    private ToRomanController _toRomanController;


    public ToRomanControllerTests()
    {
        _toRomanController = new ToRomanController();
    }
    
    [Fact]
    public void CanInitController()
    {
        _toRomanController.Should().NotBeNull().And.BeOfType<ToRomanController>();
    }
}