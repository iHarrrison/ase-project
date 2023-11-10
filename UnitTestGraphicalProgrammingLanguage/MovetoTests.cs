using System.Windows.Forms;
using GraphicProgrammingLanguage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestGraphicalProgrammingLanguage
{
    [TestClass]
    public class MovetoTests
    {
        [TestMethod]
        public void Moveto_Execute_Pass()
        {
            // Given
            var pictureBox = new PictureBox();
            var args = new String[] { "200", "200" };
            var drawingPosition = new DrawingPosition(250, 250);

            // When
            Moveto.Execute(pictureBox, args, drawingPosition);

            // Then
            Assert.IsNotNull(pictureBox.Image);
        }

        [TestMethod]
        public void Moveto_Execute_Fail()
        {
            // Given
            var pictureBox = new PictureBox();
            var args = new String[] { "This is not a number!" };
            var drawingPosition = new DrawingPosition(250, 250);

            // When
            Moveto.Execute(pictureBox, args, drawingPosition);

            // Then
            Assert.IsNull(pictureBox.Image);
        }
    }
}