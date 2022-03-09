using System.Collections.Immutable;
using System.Diagnostics;

namespace Phantonia.MazeGeneration.UI;

public sealed partial class MainForm : Form
{
    private static readonly Random Rng = new();

    public MainForm()
    {
        InitializeComponent();

        buttonGenerate.Click += OnButtonGenerate;
        buttonRandomSeed.Click += OnButtonRandomSeed;
        pictureboxVisuals.Paint += OnPaint;
    }

    private ImmutableArray<Wall>? walls;

    private int width;
    private int height;
    private int? seed;

    private void OnButtonGenerate(object? sender, EventArgs e)
    {
        if (!TryGetWidthAndHeight(out width, out height, out seed))
        {
            return;
        }

        MazeGenerator generator;

        if (seed is null)
        {
            generator = new MazeGenerator(width, height);
        }
        else
        {
            generator = new MazeGenerator(width, height, (int)seed);
        }

        walls = generator.GenerateMazeAsWalls();

        pictureboxVisuals.Invalidate();
    }

    private void OnButtonRandomSeed(object? sender, EventArgs e)
    {
        textboxSeed.Text = Rng.Next().ToString();
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

                    e.Graphics.DrawLine(wallPen, p0, p1);
                }
                else // vertical domino = horizontal wall
                {
                    Debug.Assert(wall.HigherCellIndex == wall.LowerCellIndex + width);

                    yw += length;

                    PointF p0 = new(xw, yw);
                    PointF p1 = new(xw + length, yw);

                    e.Graphics.DrawLine(wallPen, p0, p1);
                }
            }
        }
    }

    private bool TryGetWidthAndHeight(out int width, out int height, out int? seed)
    {
        if (!int.TryParse(textboxWidth.Text, out width))
        {
            MessageBox.Show($"Width '{textboxWidth.Text}' is not an integer.", "Error");
            height = 0;
            seed = null;
            return false;
        }

        if (!int.TryParse(textboxHeight.Text, out height))
        {
            MessageBox.Show($"Height '{textboxHeight.Text}' is not an integer.", "Error");
            seed = null;
            return false;
        }

        if (textboxSeed.Text == "")
        {
            seed = null;
            return true;
        }

        if (!int.TryParse(textboxSeed.Text, out int localSeed))
        {
            seed = null;
            return false;
        }

        seed = localSeed;
        return true;
    }
}
