using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicProgrammingLanguage.Commands;
using GraphicProgrammingLanguage.Model;
using System.Drawing;

namespace UnitTestGraphicalProgrammingLanguage;
    
/// <summary>
/// Test class for the AssignVariable class.
/// </summary>
[TestClass]
public class AssignVariableTests
{
    /// <summary>
    /// Tests the execution of the AssignVariable command with valid input.
    /// </summary>
    [TestMethod]
    public void Execute_AssignVariableWithValidInput_Pass()
    {
        // Given
        CommandInfo assignVariableCommand = new CommandInfo
        {
            Command = "var",
            Arguments = "x = 42"
        };

        AssignVariable assignVariable = new AssignVariable(assignVariableCommand);

        // When
        bool result = assignVariable.Execute(null, null);

        // Then
        Assert.IsTrue(result);
        Assert.AreEqual(42, GlobalDataList.Instance.Variables["x"]);
    }

    /// <summary>
    /// Tests the validation of the AssignVariable command.
    /// </summary>
    [TestMethod]
    public void IsValid_AssignVariableWithValidInput_Pass()
    {
        // Given
        CommandInfo assignVariableCommand = new CommandInfo
        {
            Command = "var",
            Arguments = "x = 42"
        };

        AssignVariable assignVariable = new AssignVariable(assignVariableCommand);

        // When
        bool isValid = assignVariable.IsValid();

        // Assert
        Assert.IsTrue(isValid);
    }
}