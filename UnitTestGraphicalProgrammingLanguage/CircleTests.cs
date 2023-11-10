using System.Windows.Forms;
using GraphicProgrammingLanguage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestGraphicalProgrammingLanguage
{
    [TestClass]
    public class CircleTests
    {
        [TestMethod]
        public void Circle_Execute_Pass()
        {
            // Given
            var pictureBox = new PictureBox();
            var args = new String[] { "200" };
            var drawingPosition = new DrawingPosition(250, 250);

            // When
            Circle.Execute(pictureBox, args, drawingPosition);

            // Then
            Assert.IsNotNull(pictureBox.Image);
        }

        [TestMethod]
        public void Circle_Execute_Fail()
        {
            // Given
            var pictureBox = new PictureBox();
            var args = new String[] { "This is not a number!" };
            var drawingPosition = new DrawingPosition(250, 250);

            // When
            Circle.Execute(pictureBox, args, drawingPosition);

            // Then
            Assert.IsNull(pictureBox.Image);
        }
    }
}