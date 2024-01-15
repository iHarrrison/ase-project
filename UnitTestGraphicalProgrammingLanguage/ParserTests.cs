using GraphicProgrammingLanguage;

namespace UnitTestGraphicalProgrammingLanguage;

/// <summary>
/// Tests the parser class
/// </summary>
[TestClass]
public class ParserTests
{
    /// <summary>
    /// Tests the parser class will parse valid input as exppected
    /// </summary>
    [TestMethod]
    public void Parse_ValidInput_Pass()
    {
        // Given
        var input = "rectangle 10, 20";

        // When
        var result = Parser.Parse(input);

        // Then
        Assert.AreEqual("rectangle", result[0].Command);
        Assert.AreEqual("10, 20", result[0].Arguments);
    }

    /// <summary>
    /// Tests the parser class will return the false bool if the attempted parse fails due to syntax error
    /// </summary>
    [TestMethod]
    public void TryParseExpression_InvalidInput_Fail()
    {
        // Given
        var invalidInput = "this is not a command";

        // When
        var result = Parser.TryParseExpression(invalidInput, out _);

        // Then
        Assert.IsFalse(result);
    }
}