namespace GraphicProgrammingLanguage;

using Commands;
using Factory;
using Model;

public partial class Canvas : Form
{
    private DrawingPosition _drawingPosition;

    public Canvas()
    {
        InitializeComponent();
        _drawingPosition = new DrawingPosition(0, 0);
        pictureBox.Image ??= new Bitmap(pictureBox.Width, pictureBox.Height);
    }

    /// <summary>
    /// Handles the event of clicking the save button, which will allow the user to store commands in the text box to a text file
    /// </summary>
    private void saveButton_Click(object sender, EventArgs e)
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "Text Files|*.txt";
        saveFileDialog.Title = "Save Commands File";

        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    writer.Write(commandTextBox.Text);
                }

                MessageBox.Show("Commands saved successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving commands: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    /// <summary>
    /// Handles the event of clicking the load button, which will allow users to load a text file of commands into the text box
    /// </summary>
    private void loadButton_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Text Files|*.txt";
        openFileDialog.Title = "Open Commands File";

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                {
                    commandTextBox.Text = reader.ReadToEnd();
                }

                MessageBox.Show("Commands loaded successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading commands: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    /// <summary>
    /// Handles the event of clicking the run button, providing the ability to exectue the commands and draw shapes on the canvas
    /// </summary>
    private void runButton_Click(object sender, EventArgs e)
    {
        GlobalDataList.Instance.ClearData();
        foreach (IGPLCommand command in CommandFactory.CreateCommandList(Parser.Parse(commandTextBox.Text)))
        {
            command.Execute(pictureBox, _drawingPosition);
        }
        pictureBox.Refresh();
    }

}
