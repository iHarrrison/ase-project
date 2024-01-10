using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicProgrammingLanguage.Commands;
using GraphicProgrammingLanguage.Model;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace UnitTestGraphicalProgrammingLanguage;

/// <summary>
/// Tests the Rectangle command
/// </summary>
[TestClass]
public class RectangleTests
{
    /// <summary>
    /// Tests that the rectangle command execute function returns true when a
    /// valid arguments is passed
    /// </summary>
    [TestMethod]
    public void Rectangle_Execute_Pass()
    {
        // Given
        var pictureBox = new PictureBox();
        pictureBox.Image = new Bitmap(500, 500);
        var commandInfo = new CommandInfo { Command = "rectangle", Arguments = "50, 50" };
        var drawingPosition = new DrawingPosition(250, 250);
        var rectangle = new GraphicProgrammingLanguage.Commands.Rectangle(commandInfo);

        // When
        bool executeResult = rectangle.Execute(pictureBox, drawingPosition);

        // Then
        Assert.IsTrue(executeResult);
    }

    /// <summary>
    /// Tests that the rectangle command execute function returns false when an
    /// invalid argument is passed
    /// </summary>
    [TestMethod]
    public void Rectangle_Execute_Fail()
    {
        // Given
        var pictureBox = new PictureBox();
        pictureBox.Image = new Bitmap(500, 500);
        var commandInfo = new CommandInfo { Command = "rectangle", Arguments = "0, rectangle here" };
        var drawingPosition = new DrawingPosition(250, 250);
        var rectangle = new GraphicProgrammingLanguage.Commands.Rectangle(commandInfo);

        // When
        bool executeResult = rectangle.Execute(pictureBox, drawingPosition);

        // Then
        Assert.IsFalse(executeResult);
    }
}