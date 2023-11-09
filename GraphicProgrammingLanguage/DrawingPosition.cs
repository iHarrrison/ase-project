﻿public class DrawingPosition
{
    public int X { get; set; }
    public int Y { get; set; }

    public Color PenColor { get; set; }

    public bool FillOn { get; set; }

    public DrawingPosition(int x, int y)
    {
        X = x;
        Y = y;


        // Default pen color to black
        PenColor = Color.Black;

        //Default fill status to off
        FillOn = false;

    }
}