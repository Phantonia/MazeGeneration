using System.Collections.Immutable;
using System.Diagnostics;

namespace Phantonia.MazeGeneration.UI;

public sealed partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

        buttonGenerate.Click += OnButtonGenerate;
        pictureboxVisuals.Paint += OnPaint;
    }

    private ImmutableArray<Wall>? walls;

    private int width;
    private int height;

    private void OnButtonGenerate(object? sender, EventArgs e)
    {
        if (!TryGetWidthAndHeight(out width, out height))
        {
            return;
        }

        walls = new MazeGenerator(width, height).GenerateMazeAsWalls();

        pictureboxVisuals.Invalidate();
    }

    private void OnPaint(object? sender, PaintEventArgs e)
    {
        const float X0 = 10.0F;
        const float Y0 = 10.0F;
        const float Length = 20.0F;

        using Pen wallPen = new(Color.Black, width: 4.0F);

        e.Graphics.DrawRectangle(wallPen, new Rectangle((int)X0, (int)Y0, (int)(Length * width), (int)(Length * height)));

        if (this.walls is ImmutableArray<Wall> walls)
        {
            foreach (Wall wall in walls)
            {
                float xw = X0 + Length * (wall.LowerCellIndex % width);
                float yw = Y0 + Length * MathF.Floor(wall.LowerCellIndex / width);

                if (wall.HigherCellIndex == wall.LowerCellIndex + 1) // vertical wall
                {
                    PointF p0 = new(xw, yw);
                    PointF p1 = new(xw, yw + Length);

                    e.Graphics.DrawLine(wallPen, p0, p1);
                }
                else
                {
                    Debug.Assert(wall.HigherCellIndex == wall.LowerCellIndex + width);

                    PointF p0 = new(xw, yw);
                    PointF p1 = new(xw + Length, yw);

                    e.Graphics.DrawLine(wallPen, p0, p1);
                }
            }
        }
    }

    private bool TryGetWidthAndHeight(out int width, out int height)
    {
        if (!int.TryParse(textboxWidth.Text, out width))
        {
            MessageBox.Show($"Width '{textboxWidth.Text}' is not an integer.", "Error");
            height = 0;
            return false;
        }

        if (!int.TryParse(textboxHeight.Text, out height))
        {
            MessageBox.Show($"Height '{textboxHeight.Text}' is not an integer.", "Error");
            return false;
        }

        return true;
    }
}
