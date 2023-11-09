using System;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace GraphicProgrammingLanguage
{
    public partial class Canvas : Form
    {
        private DrawingPosition drawingPosition;
        public Canvas()
        {
            InitializeComponent();
            runButton.Click += runButton_Click;

            drawingPosition = new DrawingPosition(0, 0);
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            string enteredCommand = commandTextBox.Text;
            string[] commands = enteredCommand.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            // loops over and treats each command as unique, allowing the multi-line functionality.
            foreach (var command in commands)
            {
                CommandParser parser = new CommandParser(pictureBox, command);

                // Switch statement to go through all expected commands and call the appropriate classes.

                switch (parser.Command.ToLower())
                {
                    case "rectangle":
                        Rectangle.Execute(pictureBox, parser.Args, drawingPosition);
                        break;

                    case "circle":
                        Circle.Execute(pictureBox, parser.Args, drawingPosition);
                        break;

                    case "triangle":
                        Triangle.Execute(pictureBox, parser.Args, drawingPosition);
                        break;

                    case "moveto":
                        Moveto.Execute(pictureBox, parser.Args, drawingPosition);
                        break;

                    case "drawto":
                        Drawto.Execute(pictureBox, parser.Args, drawingPosition);
                        break;

                    case "pen":
                        CanvasPen.Execute(pictureBox, parser.Args, drawingPosition);
                        break;

                    case "fill":
                        Fill.Execute(drawingPosition, parser.Args);
                        break;

                    case "clear":
                        Clear.Execute(pictureBox, parser.Args, drawingPosition);
                        break;

                    case "reset":
                        Reset.Execute(pictureBox, parser.Args, drawingPosition);
                        break;

                    // default if none of the commands are called by the user - error handles inside the switch statement instead of each class!
                    default:
                        MessageBox.Show($"Command '{parser.Command}' not recognized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                }
            } 
        }

    }
}
