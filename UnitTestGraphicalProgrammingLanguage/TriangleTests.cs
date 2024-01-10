using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicProgrammingLanguage.Commands;
using GraphicProgrammingLanguage.Model;
using System.Drawing;

namespace UnitTestGraphicalProgrammingLanguage
{
    /// <summary>
    /// Tests Triangle command
    /// </summary>
    [TestClass]
    public class TriangleTests
    {
        /// <summary>
        /// Tests that the triangle command execute function returns true when a
        /// valid arguments is passed
        /// </summary>
        [TestMethod]
        public void Triangle_Execute_Pass()
        {
            // Given
            var pictureBox = new PictureBox();
            pictureBox.Image = new Bitmap(500, 500);
            var commandInfo = new CommandInfo { Command = "triangle", Arguments = "50" };
            var drawingPosition = new DrawingPosition(250, 250);
            var triangle = new Triangle(commandInfo);

            // When
            bool executeResult = triangle.Execute(pictureBox, drawingPosition);

            // Then
            Assert.IsTrue(executeResult);
        }

        /// <summary>
        /// Tests that the triangle command execute function returns false when an
        /// invalid argument is passed
        /// </summary>
        [TestMethod]
        public void Triangle_Execute_Fail()
        {
            // Given
            var pictureBox = new PictureBox();
            pictureBox.Image = new Bitmap(500, 500);
            var commandInfo = new CommandInfo { Command = "triangle", Arguments = "nae triangles here" };
            var drawingPosition = new DrawingPosition(250, 250);
            var triangle = new Triangle(commandInfo);

            // When
            bool executeResult = triangle.Execute(pictureBox, drawingPosition);

            // Then
            Assert.IsFalse(executeResult);
        }
    }
}