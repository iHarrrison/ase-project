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
        /// Tests that the move to command returns a true execute bool if supplied with valid arguments
        [TestMethod]
        public void Moveto_Execute_Pass()
        {
            // Given
            var pictureBox = new PictureBox();
            pictureBox.Image = new Bitmap(500, 500);
            var commandInfo = new CommandInfo { Command = "moveto", Arguments = "50, 50" };
            var drawingPosition = new DrawingPosition(250, 250);
            var moveTo = new Moveto(commandInfo);

            // When
            bool executeResult = moveTo.Execute(pictureBox, drawingPosition);

            // Then
            Assert.IsTrue(executeResult);
        }

        /// <summary>
        /// Tests that the move to command returns a false execute bool if supplied with invalid arguments
        /// </summary>
        [TestMethod]
        public void Moveto_Execute_Fail()
        {
            // Given
            var pictureBox = new PictureBox();
            pictureBox.Image = new Bitmap(500, 500);
            var commandInfo = new CommandInfo{ Command = "moveto", Arguments = "0, valid argument" };
            var drawingPosition = new DrawingPosition(250, 250);
            var moveTo = new Moveto(commandInfo);

            // When
            bool executeResult = moveTo.Execute(pictureBox, drawingPosition);

            // Then
            Assert.IsFalse(executeResult);
        }
    }
}