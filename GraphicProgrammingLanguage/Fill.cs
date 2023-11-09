using System;
using System.Drawing;
using System.Windows.Forms;
public static class Fill
    {
    public static void Execute(DrawingPosition drawingPosition, string[] args)
    {
        if (args.Length <1)
        {
            MessageBox.Show("The fill command expects one argument (on/off)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
        }

        string fillArg = args[0].ToLower();

        if (fillArg == "on")
        {
            drawingPosition.FillOn = true;
        }
        else if (fillArg == "off")
        {
            drawingPosition.FillOn = false;
        }
        else
        {
            MessageBox.Show("Invalid argument for Fill command (use 'on' or 'off').", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
}
