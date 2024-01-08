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
        /// Tests that when the triangle receives the correct commands, it executes on the canvas as expected
        /// </summary>
        [TestMethod]
        public void Triangle_Execute_Pass()
        {
            // Given
            var pictureBox = new PictureBox();
            pictureBox.Image = new Bitmap(500, 500);
            var args = new String[] { "200" };
            var drawingPosition = new DrawingPosition(250, 250);
            var triangle = new Triangle(args);

            // When
            bool executeResult = triangle.Execute(pictureBox, drawingPosition);

            // Then
            Assert.IsTrue(executeResult);
        }

        /// <summary>
        /// Tests that when the triangle does not receive the correct commands, it does not execute on the canvas
        /// </summary>
        [TestMethod]
        public void Triangle_Execute_Fail()
        {
            // Given
            var pictureBox = new PictureBox();
            pictureBox.Image = new Bitmap(500, 500);
            var args = new String[] { "This is not a number!" };
            var drawingPosition = new DrawingPosition(250, 250);
            var triangle = new Triangle(args);

            // When
            bool executeResult = triangle.Execute(pictureBox, drawingPosition);

            // Then
            Assert.IsFalse(executeResult);
        }
    }
}