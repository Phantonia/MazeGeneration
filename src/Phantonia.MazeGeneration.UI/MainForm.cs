using Phantonia.Structures;

namespace Phantonia.MazeGeneration.UI;

public sealed partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

        buttonGenerate.Click += OnButtonGenerate;
        pictureboxVisuals.Paint += OnPaint;
    }

    private Graph<int>? graph;

    private int width;
    private int height;

    private void OnButtonGenerate(object? sender, EventArgs e)
    {
        if (!TryGetWidthAndHeight(out width, out height))
        {
            return;
        }

        RectangularGraphProvider graphProvider = new(width, height);

        graph = graphProvider.GenerateGraph();

        pictureboxVisuals.Invalidate();
    }

    private void OnPaint(object? sender, PaintEventArgs e)
    {
        if (graph is not null)
        {
            GraphVisualisation.DrawGraph(graph, width, height, e.Graphics);
        }
    }

    private bool TryGetWidthAndHeight(out int width, out int height)
    {
        if (!int.TryParse(textboxWidth.Text, out width))
        {
            MessageBox.Show($"Width {textboxWidth.Text} is not an integer.", "Error");
            height = 0;
            return false;
        }

        if (!int.TryParse(textboxHeight.Text, out height))
        {
            MessageBox.Show($"Height {textboxHeight.Text} is not an integer.", "Error");
            return false;
        }

        return true;
    }
}

internal static class GraphVisualisation
{
    private static readonly Font valueFont = new("Arial", emSize: 20.0F);
    private static readonly StringFormat valueFormat = new()
    {
        Alignment = StringAlignment.Center,
        LineAlignment = StringAlignment.Center,
    };

    public static void DrawGraph<T>(Graph<T> graph, int width, int height, Graphics graphics)
    {
        for (int i = 0; i < width * height; i++)
        {
            int x = i % width;
            int y = (i - x) / height;

            Rectangle rect = new(100 + x * 100, 50 + y * 100, 60, 60);
            Point center = new(rect.Left + rect.Width / 2, rect.Top + rect.Height / 2);

            graphics.FillEllipse(Brushes.Blue, rect);
            graphics.DrawString(graph.Vertices[i].Value?.ToString(), valueFont, Brushes.White, center, valueFormat);
        }
    }
}
