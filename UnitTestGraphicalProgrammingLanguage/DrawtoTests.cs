using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicProgrammingLanguage.Commands;
using GraphicProgrammingLanguage.Model;
using System.Drawing;

namespace UnitTestGraphicalProgrammingLanguage
{
    /// <summary>
    /// Tests the Drawto command
    /// </summary>
    [TestClass]
    public class DrawtoTests
    {
        /// <summary>
        /// Tests to see if the drawto command correctly applies a line to the canvas
        /// </summary>
        [TestMethod]
        public void Drawto_Execute_Pass()
        {
            // Given
            var pictureBox = new PictureBox();
            pictureBox.Image = new Bitmap(500, 500);
            var commandInfo = new CommandInfo { Command = "drawto", Arguments = "50,50" };
            var drawingPosition = new DrawingPosition(250, 250);
            var drawTo = new Drawto(commandInfo);

            // When
            bool executeResult = drawTo.Execute(pictureBox, drawingPosition);

            // Then
            Assert.IsTrue(executeResult);
        }

        /// <summary>
        /// Tests to make sure that if an invalid argument is passed, the execute fails as expected.
        /// </summary>
        [TestMethod]
        public void Drawto_Execute_Fail()
        {
            // Given
            var pictureBox = new PictureBox();
            pictureBox.Image = new Bitmap(500, 500);
            var commandInfo = new CommandInfo { Command = "drawto", Arguments = "these are, not arguments" };
            var drawingPosition = new DrawingPosition(250, 250);
            var drawTo = new Drawto(commandInfo);

            // When
            bool executeResult = drawTo.Execute(pictureBox, drawingPosition);

            // Then
            Assert.IsFalse(executeResult);
        }
    }
}