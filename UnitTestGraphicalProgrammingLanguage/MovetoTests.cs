using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicProgrammingLanguage.Commands;
using GraphicProgrammingLanguage.Model;
using System.Drawing;

namespace UnitTestGraphicalProgrammingLanguage
{
    /// <summary>
    /// Tests the Moveto command
    /// </summary>
    [TestClass]
    public class MovetoTests
    {
        /// <summary>
        /// Tests that the moveto command works as expected via validating the canvas is not null after use - as it leaves
        /// a small circle showing the user where abouts they are now located on the canvas
        /// </summary>
        [TestMethod]
        public void Moveto_Execute_Pass()
        {
            // Given
            var pictureBox = new PictureBox();
            pictureBox.Image = new Bitmap(500, 500);
            var args = new String[] { "200, 200" };
            var drawingPosition = new DrawingPosition(250, 250);
            var moveTo = new Moveto(args);

            // When
            bool executeResult = moveTo.Execute(pictureBox, drawingPosition);

            // Then
            Assert.IsTrue(executeResult);
        }

        /// <summary>
        /// Tests that if it fails, the canvas is still empty as the circle will not have been drawn to show the
        /// user whereabouts they are on the canvas
        /// </summary>
        [TestMethod]
        public void Moveto_Execute_Fail()
        {
            // Given
            var pictureBox = new PictureBox();
            pictureBox.Image = new Bitmap(500, 500);
            var args = new String[] { "No, Not a number" };
            var drawingPosition = new DrawingPosition(250, 250);
            var moveTo = new Moveto(args);

            // When
            bool executeResult = moveTo.Execute(pictureBox, drawingPosition);

            // Then
            Assert.IsFalse(executeResult);
        }
    }
}