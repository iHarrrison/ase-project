using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicProgrammingLanguage.Commands;
using GraphicProgrammingLanguage.Model;
using System.Drawing;

namespace UnitTestGraphicalProgrammingLanguage
{
    /// <summary>
    /// To test functionality of the Circle command
    /// </summary>
    [TestClass]
    public class CircleTests
    {
        /// <summary>
        /// Does the circle successfully execute as expected
        /// </summary>
        [TestMethod]
        public void Circle_Execute_Pass()
        {
            // Given
            var pictureBox = new PictureBox();
            pictureBox.Image = new Bitmap(500, 500);
            var args = new String[] { "200" };
            var drawingPosition = new DrawingPosition(250, 250);
            var circle = new Circle(args);

            // When
            bool executeResult = circle.Execute(pictureBox, drawingPosition);

            // Then
            Assert.IsTrue(executeResult);
        }

        /// <summary>
        /// Does the circle fail to execute as expected
        /// </summary>
        [TestMethod]
        public void Circle_Execute_Fail()
        {
            // Given
            var pictureBox = new PictureBox();
            pictureBox.Image = new Bitmap(500, 500);
            var args = new String[] { "This is not a number!" };
            var drawingPosition = new DrawingPosition(250, 250);
            var circle = new Circle(args);

            // When
            bool executeResult = circle.Execute(pictureBox, drawingPosition);

            // Then
            Assert.IsFalse(executeResult);
        }
    }
}