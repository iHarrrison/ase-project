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
    /// Tests that the rectangle command leaves a shape on the canvas
    /// </summary>
    [TestMethod]
    public void Rectangle_Execute_Pass()
    {
        // Given
        var pictureBox = new PictureBox();
        pictureBox.Image = new Bitmap(500, 500);
        var args = new String[] { "20, 50"};
        var drawingPosition = new DrawingPosition(250, 250);
        var rectangle = new GraphicProgrammingLanguage.Commands.Rectangle(args);

        // When
        bool executeResult = rectangle.Execute(pictureBox, drawingPosition);

        // Then
        Assert.IsTrue(executeResult);
    }

    /// <summary>
    /// Tests that no shape is left on the canvas if the parameters are incorrect
    /// </summary>
    [TestMethod]
    public void Rectangle_Execute_Fail()
    {
        // Given
        var pictureBox = new PictureBox();
        var originalImage = pictureBox.Image;
        var args = new String[] { "This is not a number!, 50" };
        var drawingPosition = new DrawingPosition(250, 250);
        var rectangle = new GraphicProgrammingLanguage.Commands.Rectangle(args);
        
        // When
        bool executeResult = rectangle.Execute(pictureBox, drawingPosition);

        // Then
        Assert.IsFalse(executeResult);
    }
}