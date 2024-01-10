using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicProgrammingLanguage.Commands;
using GraphicProgrammingLanguage.Model;

namespace UnitTestGraphicalProgrammingLanguage
{
    /// <summary>
    /// Tests the Fill class
    /// </summary>
    [TestClass]
    public class FillTests
    {
        /// <summary>
        /// Tests to see if the Fill bool behaves as expected when receiving the "on" argument
        /// </summary>
        [TestMethod]
        public void Fill_Execute_Pass()
        {
            // Given
            var pictureBox = new PictureBox();
            var commandInfo = new CommandInfo { Command = "fill", Arguments = "1" };
            var drawingPosition = new DrawingPosition(250, 250);
            var fill = new Fill(commandInfo);

            // When
            bool executeResult = fill.Execute(pictureBox, drawingPosition);

            // Then
            Assert.IsTrue(executeResult);
        }

        /// <summary>
        /// Tests to see the behaviour is as expected when an invalid argument is passed for this command
        /// </summary>
        [TestMethod]
        public void Fill_Execute_Fail()
        {
            // Given
            var pictureBox = new PictureBox();
            var commandInfo = new CommandInfo { Command = "fill", Arguments = "Who's Phil?" };
            var drawingPosition = new DrawingPosition(250, 250);
            var fill = new Fill(commandInfo);

            // When
            bool executeResult = fill.Execute(pictureBox, drawingPosition);

            // Then
            Assert.IsFalse(executeResult);
        }
    }
}