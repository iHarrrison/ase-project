using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicProgrammingLanguage.Commands;
using GraphicProgrammingLanguage.Model;

namespace UnitTestGraphicalProgrammingLanguage
{
    /// <summary>
    /// Tests the clear command
    /// </summary>
    [TestClass]
    public class ClearTests
    {
        /// <summary>
        /// Tests to see if the clear command behaves as expected when it executes
        /// </summary>
        [TestMethod]
        public void Clear_Execute_Pass()
        {
            // Given
            var pictureBox = new PictureBox();
            var args = new String[] { "200" };
            var drawingPosition = new DrawingPosition(250, 250);
            var clear = new Clear();

            // When
            bool executeResult = clear.Execute(pictureBox, drawingPosition);

            // Then
            Assert.IsTrue(executeResult);
        }

        /// <summary>
        /// Tests to make sure that if something is drawn after the clear command, it performs correctly. Showcases clear does not prevent the
        /// image from being drawn on even after it has been used.
        /// </summary>
        [TestMethod]
        public void Clear_Execute_Fail()
        {
            // Given
            var pictureBox = new PictureBox();
            var args = new String[] { "200" };
            var drawingPosition = new DrawingPosition(250, 250);
            var triangle = new Triangle(args);
            var clear = new Clear();

            // When
            clear.Execute(pictureBox, drawingPosition);
            triangle.Execute(pictureBox, drawingPosition);

            // Then
            Assert.IsNotNull(pictureBox.Image);
        }
    }
}