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
        /// Tests to see if the clear command executes... can't really test much more meaningful than this, as it does not take parameters.
        /// </summary>
        [TestMethod]
        public void Clear_Execute_Pass()
        {
            // Given
            var pictureBox = new PictureBox();
            var drawingPosition = new DrawingPosition(250, 250);
            var commandInfo = new CommandInfo { Command = "clear" };
            var clear = new Clear(commandInfo);

            // When
            bool executeResult = clear.Execute(pictureBox, drawingPosition);

            // Then
            Assert.IsTrue(executeResult);
        }
    }
}