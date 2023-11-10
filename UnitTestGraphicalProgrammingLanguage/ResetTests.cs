using System.Windows.Forms;
using GraphicProgrammingLanguage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestGraphicalProgrammingLanguage
{
    [TestClass]
    public class ResetTests
    {
        [TestMethod]
        public void Reset_Execute_Pass()
        {
            // Given
            var pictureBox = new PictureBox();
            var args = new String[] { "200, 200" };
            var drawingPosition = new DrawingPosition(250, 250);

            // When
            Reset.Execute(pictureBox, args, drawingPosition);

            // Then
            Assert.AreEqual(0, drawingPosition.X, 0);
            Assert.AreEqual(0, drawingPosition.Y);
        }
    }
}