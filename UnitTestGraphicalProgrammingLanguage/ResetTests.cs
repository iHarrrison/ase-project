using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicProgrammingLanguage.Commands;
using GraphicProgrammingLanguage.Model;
using System.Drawing;

namespace UnitTestGraphicalProgrammingLanguage
{
    /// <summary>
    /// Tests the reset command
    /// </summary>
    [TestClass]
    public class ResetTests
    {
        /// <summary>
        /// Tests that when the reset command is entered, the drawing position resets back to 0,0, as expected.
        /// </summary>
        [TestMethod]
        public void Reset_Execute_Pass()
        {
            // Given
            var pictureBox = new PictureBox();
            pictureBox.Image = new Bitmap(500, 500);
            var drawingPosition = new DrawingPosition(250, 250);
            var commandInfo = new CommandInfo { Command = "clear" };
            var reset = new Reset(commandInfo);

            // When
            reset.Execute(pictureBox, drawingPosition);

            // Then
            Assert.AreEqual(0, drawingPosition.X);
            Assert.AreEqual(0, drawingPosition.Y);
        }
    }
}