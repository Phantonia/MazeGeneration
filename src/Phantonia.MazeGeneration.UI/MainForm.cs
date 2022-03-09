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
        const int Margin = 20;

        float length = (float)Math.Min(pictureboxVisuals.Width - 2 * Margin, pictureboxVisuals.Height - 2 * Margin) / Math.Max(width, height);
        
        using Pen wallPen = new(Color.White, width: 4.0F);

        e.Graphics.Clear(Color.FromArgb(31, 31, 31));

        e.Graphics.DrawRectangle(wallPen, new Rectangle(x: Margin, y: Margin, (int)(length * width), (int)(length * height)));

        if (this.walls is ImmutableArray<Wall> walls)
        {
            foreach (Wall wall in walls)
            {
                float xw = Margin + length * (wall.LowerCellIndex % width);
                float yw = Margin + length * MathF.Floor(wall.LowerCellIndex / width);

                if (wall.HigherCellIndex == wall.LowerCellIndex + 1) // horizontal domino = vertical wall
                {
                    xw += length;

                    PointF p0 = new(xw, yw);
                    PointF p1 = new(xw, yw + length);

                    Debug.WriteLine($"Vertical wall: {wall.LowerCellIndex} to {wall.HigherCellIndex}; Points {p0} to {p1}");

                    e.Graphics.DrawLine(wallPen, p0, p1);
                }
                else // vertical domino = horizontal wall
                {
                    Debug.Assert(wall.HigherCellIndex == wall.LowerCellIndex + width);

                    yw += length;

                    PointF p0 = new(xw, yw);
                    PointF p1 = new(xw + length, yw);

                    Debug.WriteLine($"Horizontal wall: {wall.LowerCellIndex} to {wall.HigherCellIndex}; Points {p0} to {p1}");

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
