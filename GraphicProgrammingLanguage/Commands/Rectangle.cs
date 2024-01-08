﻿namespace GraphicProgrammingLanguage.Commands;

using Model;

/// <summary>
/// Enables the ability to draw rectangles on the canvas
/// </summary>
public class Rectangle : AbstractGPLCommand
{
    public override int ExpectedArgumentsCount => 2;

    public Rectangle(params object[] args) => Arguments = $"{args[0]}".Split(',', Constants.ArgumentSplitFlags);

    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition)
    {
        if (!(Parser.TryParseIntExpression(Arguments[0], out int width) && Parser.TryParseIntExpression(Arguments[1], out int height)))
        {
            return false;
        }

        using (Graphics g = Graphics.FromImage(pictureBox.Image))
        {
            if (drawingPosition.FillOn)
            {
                g.FillRectangle(new SolidBrush(drawingPosition.PenColor), drawingPosition.X, drawingPosition.Y, width, height);
            }
            else
            {
                g.DrawRectangle(new Pen(drawingPosition.PenColor), drawingPosition.X, drawingPosition.Y, width, height);
            }
        }

        return true;
    }
}