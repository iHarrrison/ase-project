using System;
using System.Windows.Forms;

namespace GraphicProgrammingLanguage
{
    public partial class Canvas : Form
    {
        public Canvas()
        {
            InitializeComponent();
            runButton.Click += runButton_Click;
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            string enteredCommand = commandTextBox.Text;
            CommandParser parser = new CommandParser(pictureBox, enteredCommand);

            // Switch statement to go through all expected commands and call the appropriate classes.
            // TODO Add error handling so if it is not an expected command, it does not break.

            switch (parser.Command.ToLower())
            {
                case "rectangle":
                    RectangleCommand.Execute(pictureBox, parser.Args);
                    break;
                    // TODO add more commands.
            }
        }

    }
}
