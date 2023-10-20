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
        }
    }
}
