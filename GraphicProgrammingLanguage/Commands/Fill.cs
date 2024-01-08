﻿namespace GraphicProgrammingLanguage.Commands;

using Model;
public class Fill : AbstractGPLCommand
{
    public override int ExpectedArgumentsCount => 1;

    public Fill(CommandInfo commandInfo) => Arguments = new[] { commandInfo.Arguments };

    public override bool Execute(PictureBox pictureBox, DrawingPosition drawingPosition)
    {
        if (!Parser.TryParseIntExpression(Arguments[0], out int isOn))
        {
            return false;
        }
        drawingPosition.FillOn = Convert.ToBoolean(isOn);
        return true;
    }
}
