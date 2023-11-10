﻿using System.Windows.Forms;
using GraphicProgrammingLanguage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestGraphicalProgrammingLanguage
{
    [TestClass]
    public class FillTests
    {
        [TestMethod]
        public void Fill_Execute_Pass()
        {
            // Given
            var pictureBox = new PictureBox();
            var args = new String[] { "on" };
            var drawingPosition = new DrawingPosition(250, 250);

            // When
            Fill.Execute(drawingPosition, args);

            // Then
            Assert.IsTrue(drawingPosition.FillOn);
        }

        [TestMethod]
        public void Fill_Execute_Fail()
        {
            // Given
            var pictureBox = new PictureBox();
            var args = new String[] { "I will neither confirm nor deny if fill is on" };
            var drawingPosition = new DrawingPosition(250, 250);

            // When
            Fill.Execute(drawingPosition, args);

            // Then
            Assert.IsFalse(drawingPosition.FillOn);
        }
    }
}