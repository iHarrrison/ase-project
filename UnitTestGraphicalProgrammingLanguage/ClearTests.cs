using System.Windows.Forms;
using GraphicProgrammingLanguage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestGraphicalProgrammingLanguage
{
    [TestClass]
    public class ClearTests
    {
        [TestMethod]
        public void Clear_Execute_Pass()
        {
            // Given
            var pictureBox = new PictureBox();
            var args = new String[] { "200" };
            var drawingPosition = new DrawingPosition(250, 250);

            // When
            Triangle.Execute(pictureBox, args, drawingPosition);
            Clear.Execute(pictureBox, args, drawingPosition);

            // Then
            Assert.IsNull(pictureBox.Image);
        }

        [TestMethod]
        public void Clear_Execute_Fail()
        {
            // Given
            var pictureBox = new PictureBox();
            var args = new String[] { "200" };
            var drawingPosition = new DrawingPosition(250, 250);

            // When
            Clear.Execute(pictureBox, args, drawingPosition);
            Triangle.Execute(pictureBox, args, drawingPosition);

            // Then
            Assert.IsNotNull(pictureBox.Image);
        }
    }
}