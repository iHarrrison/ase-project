using System.Windows.Forms;
using GraphicProgrammingLanguage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestGraphicalProgrammingLanguage
{
    [TestClass]
    public class CommandParserTests
    {
        [TestMethod]
        public void CommandParser_Parses_Command_With_Arguments()
        {
            // Given
            var pictureBox = new PictureBox();
            var enteredCommand = "drawto 200 200";

            // When
            var commandParser = new CommandParser(pictureBox, enteredCommand);

            // Then
            Assert.AreEqual("drawto", commandParser.Command);
            CollectionAssert.AreEqual(new[] { "200", "200" }, commandParser.Args);
        }

        [TestMethod]
        public void CommandParser_Parses_Empty_Command()
        {
            // Given
            var pictureBox = new PictureBox();
            var enteredCommand = "";

            // When
            var commandParser = new CommandParser(pictureBox, enteredCommand);

            // Then
            Assert.AreEqual("", commandParser.Command);
            CollectionAssert.AreEqual(Array.Empty<string>(), commandParser.Args);
        }
    }
}