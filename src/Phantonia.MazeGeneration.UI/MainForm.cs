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

    private void OnButtonGenerate(object? sender, EventArgs e)
    {
        width = (int)updownWidth.Value;
        height = (int)updownHeight.Value;
        int? seed;

        if (int.TryParse(textboxSeed.Text, out int givenSeed))
        {
            seed = givenSeed;
        }
        else
        {
            seed = null;
            textboxSeed.Text = "";
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

        walls = generator.GenerateMazeAsWalls((int)updownCycleNumber.Value);

        pictureboxVisuals.Invalidate();
    }

    private void OnButtonRandomSeed(object? sender, EventArgs e)
    {
        int seed = Rng.Next();
        textboxSeed.Text = seed.ToString();
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
                    yw -= 2.0F;

                    PointF p0 = new(xw, yw);
                    PointF p1 = new(xw, yw + length + 4.0F);

                    e.Graphics.DrawLine(wallPen, p0, p1);
                }
                else // vertical domino = horizontal wall
                {
                    Debug.Assert(wall.HigherCellIndex == wall.LowerCellIndex + width);

                    yw += length;
                    xw -= 2.0F;

                    PointF p0 = new(xw, yw);
                    PointF p1 = new(xw + length + 4.0F, yw);

                    e.Graphics.DrawLine(wallPen, p0, p1);
                }
            }
        }
    }
}
